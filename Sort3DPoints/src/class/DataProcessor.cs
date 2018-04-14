using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sort3DPoints
{
    /// <summary>
    /// 数据处理类
    /// </summary>
    public class DataProcessor
    {
        // 结果点集，用于最终输出的（凸壳初始点集）
        private List<IPoint> surplusPoints = null;
        // 剩余点集，全部点 - 凸壳初始点集
        private List<IPoint> remainPoints = null;
        // 中间排序用的排序依据点集
        private List<double> orderByElevation = null; //点到Tin表面的高差
        private List<double> orderByVolume = null; //点到Tin表面三角形的四面体的体积
        private List<double> orderByDistance = null; //点到Tin表面三角形的距离

        #region 构造函数
        public DataProcessor()
        {
            surplusPoints = new List<IPoint>();
            remainPoints = new List<IPoint>();
            orderByElevation = new List<double>();
            orderByVolume = new List<double>();
            orderByDistance = new List<double>();
        }

        #endregion

        #region 属性
        public List<IPoint> SurplusPoints
        {
            get
            {
                return surplusPoints;
            }

            set
            {
                surplusPoints = value;
            }
        }

        public List<IPoint> RemainPoints
        {
            get
            {
                return remainPoints;
            }

            set
            {
                remainPoints = value;
            }
        }

        public List<double> OrderByDistance
        {
            get
            {
                return orderByDistance;
            }

            set
            {
                orderByDistance = value;
            }
        }

        public List<double> OrderByVolume
        {
            get
            {
                return orderByVolume;
            }

            set
            {
                orderByVolume = value;
            }
        }

        public List<double> OrderByElevation
        {
            get
            {
                return orderByElevation;
            }

            set
            {
                orderByElevation = value;
            }
        }
        #endregion

        #region 对外工具

        /// <summary>
        /// 根据图层名选择图层
        /// </summary>
        /// <param name="map"></param>
        /// <param name="layerName"></param>
        /// <returns></returns>
        public ILayer SelectLayerByName(IMap map, string layerName)
        {
            ILayer layer = null;

            // 此循环尚未考虑图层名重复的问题
            // -- 图层较少，暂时不用IEnumLayer来遍历
            for (int i = 0; i < map.LayerCount; i++)
            {
                // 用Equals，比较快
                if (map.Layer[i].Name.Equals(layerName))
                    layer = map.Layer[i];
            }
            return layer;
        }

        /// <summary>
        /// 用IFeatureCursor获取所有点
        /// </summary>
        /// <param name="featureLayer"></param>
        /// <returns></returns>
        public List<IPoint> FeatureLayerToList(IFeatureLayer featureLayer)
        {
            List<IPoint> temp = new List<IPoint>();
            IFeatureClass featureClass = featureLayer.FeatureClass;

            // 以下是用游标获取每一个IFeature.Shape
            IQueryFilter queryFilter = new QueryFilterClass();
            IFeatureCursor featureCursor = featureClass.Search(queryFilter, false);
            IFeature feature = featureCursor.NextFeature();
            while (feature != null)
            {
                temp.Add(feature.Shape as IPoint);
                feature = featureCursor.NextFeature();
            }
            return temp;
            #region GetFeature(i)
            // 以下是用GetFeature(i)获取IFeature.Shape
            // -- 暂不使用 有可能出现OID跳号的问题
            // int featureCount = featureLayer.FeatureClass.FeatureCount(new QueryFilterClass());

            // for (int i = 1; i < featureCount; i++)
            //     temp.Add(featureClass.GetFeature(i).Shape as IPoint);

            #endregion
        }

        /// <summary>
        /// 由List生成IFeatureClass的方法
        /// </summary>
        /// <param name="finalPointsList"></param>
        /// <returns></returns>
        public IFeatureClass ListToFeatureClass(List<IPoint> finalPointsList, string theNewFCName, int pointNum)
        {
            IWorkspaceFactory workspaceFactory = new FileGDBWorkspaceFactoryClass();
            // 测试用，不商业化，写默认目录。
            IFeatureWorkspace featureWorkspace = (workspaceFactory.OpenFromFile(@"C:\Users\C\Documents\ArcGIS\Default.gdb", 0)) as IFeatureWorkspace;
            IFeatureDataset featureDataset = featureWorkspace.OpenFeatureDataset("SortResult");

            // 创建要素类(默认SortResult不存在)
            UID CLSID = new UIDClass() { Value = "esriGeoDatabase.Feature" };
            IFieldsEdit fieldsEdit = new FieldsClass();
            // AddField()反射不出来智能提示
            // CreateGemetryField()方法创建一个Shape字段  (*必须，而OBJECTID则不必须)
            fieldsEdit.AddField(CreateGeometryField());
            
            // 要素类名称不能和要素数据集名称一致
            IFeatureClass featureClass =
                featureDataset.CreateFeatureClass
                (theNewFCName + "FC", fieldsEdit as IFields, CLSID, null, esriFeatureType.esriFTSimple, "Shape", "");

            for (int i = 0; i < pointNum; i++)
            {
                IFeature feature = featureClass.CreateFeature();
                feature.Shape = finalPointsList[i];
                feature.Store();
            }
            return featureClass;
        }

        /// <summary>
        /// 传入Tin, 传入点集, 计算高差最大的点
        /// </summary>
        /// <param name="tin"></param>
        /// <param name="pts"></param>
        /// <returns></returns>
        public IPoint CalcElevationOnce(ITin tin, List<IPoint> pts)
        {
            ITinSurface2 surface = tin as ITinSurface2;

            // 重要：清除排序依据的List
            orderByElevation.Clear();

            foreach (IPoint pt in pts)
            {
                orderByElevation.Add(
                    Math.Abs(
                        surface.GetElevation(pt)
                        -
                        pt.Z
                    )
                );
            }

            return pts[orderByElevation.IndexOf(orderByElevation.Max())];
            // 注意：删除最大点的操作在外部，不应由此处删除
        }

        /// <summary>
        /// 传入Tin, 传入点集, 计算四面体体积最大的点
        /// </summary>
        /// <param name="tin"></param>
        /// <param name="pts"></param>
        /// <returns></returns>
        public IPoint CalcVolumeOnce(ITin tin, List<IPoint> pts)
        {
            // 思考：首先获取ITinTriangle，然后获取四个点生成四面体，然后计算四面体的体积（调用四阶行列式计算方法）
            ITinAdvanced2 tinAdvanced = tin as ITinAdvanced2;

            orderByVolume.Clear();

            for (int i = 0; i < pts.Count; i++)
            {
                IPoint ptemp = pts[i];

                // 获取三角形
                ITinTriangle tinTria = tinAdvanced.FindTriangle(ptemp);
                // 创建四边形
                Tetrahedron tetra = new Tetrahedron(tinTria, ptemp);
                // 获取体积
                orderByVolume.Add(tetra.Volume);
            }
            return pts[orderByVolume.IndexOf(orderByVolume.Max())];
        }

        /// <summary>
        /// 点面距D = H × cos(Slope)，在Tetrahedron里会自动计算
        /// </summary>
        /// <param name="tin"></param>
        /// <param name="pts"></param>
        /// <returns></returns>
        public IPoint CalcDistanceOnce(ITin tin, List<IPoint> pts)
        {
            ITinAdvanced2 tinAdvanced = tin as ITinAdvanced2;

            orderByDistance.Clear();

            foreach (IPoint pt in pts)
            {
                ITinTriangle tinTria = tinAdvanced.FindTriangle(pt);
                Tetrahedron tetra = new Tetrahedron(tinTria, pt);
                orderByDistance.Add(tetra.Height);
            }

            return pts[orderByDistance.IndexOf(orderByDistance.Max())];
        }

        /// <summary>
        /// 使用初始点集构造初始Tin
        /// </summary>
        /// <param name="firstPoints"></param>
        /// <param name="theMapEnvelope"></param>
        /// <returns></returns>
        public ITin CreateFirstTin(List<IPoint> firstPoints, IEnvelope theMapEnvelope)
        {
            ITin tin = new TinClass();
            ITinEdit tinEdit = tin as ITinEdit;
            tinEdit.InitNew(theMapEnvelope);

            foreach (IPoint pt in firstPoints)
            {
                tinEdit.AddPointZ(pt, 0);
            }
            
            tinEdit.SaveAs(@"C:\Users\C\Documents\ArcGIS\tintemp", true);
            tinEdit.Refresh();

            return tinEdit as ITin;
        }

        /// <summary>
        /// 加一个点，更新ITin
        /// </summary>
        /// <param name="tin"></param>
        /// <param name="pointNext"></param>
        public void FlushTin(ITin tin, IPoint pointNext)
        {
            int nodeCountPlus = tin.DataNodeCount + 1;
            ITinEdit tinEdit = tin as ITinEdit;
            // 在点数后一个位置添加
            tinEdit.AddPointZ(pointNext, nodeCountPlus);
            tinEdit.Save();
            tinEdit.Refresh();
        }

        /// <summary>
        /// 根据给定文本信息（几何类型）创建几何字段
        /// </summary>
        /// <returns></returns>
        private IField CreateGeometryField()
        {
            // 创建几何定义
            IGeometryDef geometryDef = new GeometryDef();
            IGeometryDefEdit geometryDefEdit = geometryDef as IGeometryDefEdit;
                             geometryDefEdit.HasZ_2 = true;
                             geometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPoint;

            #region 判断几何类型
            // // 赋予几何类型
            //switch (geometryType)
            //{
            //    case "Point":
            //        geometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPoint;
            //        break;
            //    case "Polyline":
            //        geometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolyline;
            //        break;
            //    case "Polygon":
            //        geometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolygon;
            //        break;
            //}
            //

            #endregion

            // 创建字段
            IField geometryField = new Field();
            IFieldEdit geometryFieldEdit = geometryField as IFieldEdit;
            geometryFieldEdit.Name_2 = "Shape"; // 字段名按惯例叫Shape即可，与CreateFeatureClass()中必须一致
            geometryFieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry; // 字段类型Geometry
            geometryFieldEdit.GeometryDef_2 = geometryDef;

            return geometryField;
        }
        #endregion
    }
}
