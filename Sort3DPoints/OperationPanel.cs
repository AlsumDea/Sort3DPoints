using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Sort3DPoints
{
    /// <summary>
    /// 浮动窗的设计类。它包括了组成浮动窗的逻辑。
    /// </summary>
    public partial class OperationPanel : UserControl
    {
        // Mxd下的已激活地图
        private IMap nowMap = (ArcMap.Application.Document as IMxDocument).FocusMap;
        
        // 数据处理器
        private DataProcessor dp = new DataProcessor();
        // 所选的输入图层
        private IFeatureLayer surplusLayer = null;
        private IFeatureLayer remainLayer = null;
        private CalcMethod calcMethod = CalcMethod.Null;

        #region 自动生成

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="hook"></param>
        public OperationPanel(object hook)
        {
            InitializeComponent();
            this.Hook = hook;

            ReadLayer();
        }

        /// <summary>
        /// Host object of the dockable window
        /// </summary>
        private object Hook
        {
            get;
            set;
        }

        /// <summary>
        /// Implementation class of the dockable window add-in. It is responsible for 
        /// creating and disposing the user interface class of the dockable window.
        /// </summary>
        public class AddinImpl : ESRI.ArcGIS.Desktop.AddIns.DockableWindow
        {
            private OperationPanel m_windowUI;

            public AddinImpl()
            {
            }

            protected override IntPtr OnCreateChild()
            {
                m_windowUI = new OperationPanel(this.Hook);
                return m_windowUI.Handle;
            }

            protected override void Dispose(bool disposing)
            {
                if (m_windowUI != null)
                    m_windowUI.Dispose(disposing);

                base.Dispose(disposing);
            }

        }

        #endregion

        /// <summary>
        /// 读图层
        /// </summary>
        private void ReadLayer()
        {
            if (nowMap.LayerCount != 0)
            {
                ClearList();
                // 事件操作
                listBox_Surplus.SelectedIndexChanged -= listBox_Surplus_SelectedIndexChanged;
                listBox_Remain.SelectedIndexChanged -= listBox_Remain_SelectedIndexChanged;
                for (int i = 0; i < nowMap.LayerCount; i++)
                {
                    string name = nowMap.Layer[i].Name;
                    listBox_Surplus.Items.Add(name);
                    listBox_Remain.Items.Add(name);
                }
                listBox_Remain.SelectedIndex = 0;
                listBox_Surplus.SelectedIndex = 0;
                // 事件操作
                listBox_Remain.SelectedIndexChanged += listBox_Remain_SelectedIndexChanged;
                listBox_Surplus.SelectedIndexChanged += listBox_Surplus_SelectedIndexChanged;
            }
            else
                return;
        }

        /// <summary>
        /// 清除ListBox的项目
        /// </summary>
        private void ClearList()
        {
            if (listBox_Remain.Items.Count == 0 && listBox_Surplus.Items.Count == 0)
                return;
            else
            {
                listBox_Remain.Items.Clear();
                listBox_Surplus.Items.Clear();
            }
        }
        
        /// <summary>
        /// 创建默认Shape字段
        /// </summary>
        /// <param name="geometryType"></param>
        /// <returns></returns>
        private IField CreateGeometryField(string geometryType)
        {
            // 创建几何定义
            IGeometryDef geometryDef = new GeometryDef();
            IGeometryDefEdit geometryDefEdit = geometryDef as IGeometryDefEdit;
            
            geometryDefEdit.HasM_2 = false;
            geometryDefEdit.HasZ_2 = true;

            // 赋予几何类型
            switch (geometryType)
            {
                case "Point":
                    geometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPoint;
                    break;
                case "Polyline":
                    geometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolyline;
                    break;
                case "Polygon":
                    geometryDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPolygon;
                    break;
            }


            // 创建字段
            IField geometryField = new Field();
            IFieldEdit geometryFieldEdit = geometryField as IFieldEdit;
            geometryFieldEdit.Name_2 = "Shape";// 字段名按惯例叫Shape即可，与CreateFeatureClass中必须一致
            geometryFieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;// 字段类型Geometry
            geometryFieldEdit.GeometryDef_2 = geometryDef;

            return geometryField;
        }

        /// <summary>
        /// 读取FocusMap的所有图层 -- Carto类库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Readlayer_Click(object sender, EventArgs e)
        {
            ReadLayer();
            #region 测试四阶行列式

            /*
            List<string> tss = new List<string>();
            for (int i = 0; i < 20; i++)
            {
                Stopwatch time = new Stopwatch();
                time.Start();
            
                Tetrahedron t = new Tetrahedron();
                double v = 0;
                //循环2000次看看时间

                for (int j = 0; j < 20000; j++)
                {
                    v = t.Volume;
                }
            
            
                time.Stop();
                TimeSpan ts = time.Elapsed;
                tss.Add(ts.TotalMilliseconds.ToString());
            }

            foreach (string ts in tss)
            {
                this.textBox_Infowindow.Text += (Environment.NewLine + ts);
            }
            */
            #endregion
        }

        /// <summary>
        /// 当选择列表改变时，指向当前列表选择的名字相同的图层
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox_Surplus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = this.listBox_Surplus.SelectedItem.ToString();
            ILayer nowLayer = this.dp.SelectLayerByName(this.nowMap, name);
            if (nowLayer is IFeatureLayer)
                this.surplusLayer = nowLayer as IFeatureLayer;


            // 
            // 测试取图层是否成功
            // - Yes
            // MessageBox.Show(nowLayer.Name + Environment.NewLine + (nowLayer as IFeatureLayer).FeatureClass.FeatureType.ToString());
            //
        }
        private void listBox_Remain_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = this.listBox_Remain.SelectedItem.ToString();
            ILayer nowLayer = dp.SelectLayerByName(this.nowMap, name);
            if (nowLayer is IFeatureLayer)
                this.remainLayer = nowLayer as IFeatureLayer;

            //MessageBox.Show(nowLayer.Name + Environment.NewLine + (nowLayer as IFeatureLayer).FeatureClass.FeatureType.ToString());
        }

        private void btn_Calculate_Click(object sender, EventArgs e)
        {
            Stopwatch t = new Stopwatch();
            progressBar.Value = 0;

            // 问题句 应该判断两个要素图层是否为空
            if (this.surplusLayer != null && this.remainLayer != null)
            {
                //获取两个基本的List<IPoint>
                // 计时器启动
                t.Start();
                this.dp.SurplusPoints = this.dp.FeatureLayerToList(surplusLayer);
                this.dp.RemainPoints = this.dp.FeatureLayerToList(remainLayer);
                progressBar.Value = 30;
                try
                {
                    ITin theTin = dp.CreateFirstTin(dp.SurplusPoints, surplusLayer.AreaOfInterest);
                    progressBar.Value = 31;
                    this.textBox_Infowindow.Text = "转换数据并构造初始Tin成功" + Environment.NewLine + " --耗时：" + t.Elapsed.TotalSeconds.ToString() + ",进入排序...";
                    while(this.dp.RemainPoints.Count != 0)
                    {
                        // - 处理逻辑
                        // 1. 先找一次最大值点
                        IPoint pointNext = null;
                        switch (this.calcMethod)
                        {
                            case CalcMethod.Null:
                            case CalcMethod.Elevation:
                                pointNext = dp.CalcElevationOnce(theTin, dp.RemainPoints);
                                break;
                            case CalcMethod.Distance:
                                pointNext = dp.CalcDistanceOnce(theTin, dp.RemainPoints);
                                break;
                            case CalcMethod.Volume:
                                pointNext = dp.CalcVolumeOnce(theTin, dp.RemainPoints);
                                break;
                            default:
                                break;
                        }
                        // 2. 然后加该点到SurplusPoints里
                        dp.SurplusPoints.Add(pointNext);
                        // 3. 然后删除从RemainPoints里删除该点，并重构Tin
                        dp.FlushTin(theTin, pointNext);
                        dp.RemainPoints.Remove(pointNext);
                        // 4. 单次循环结束，进行下一次循环，检查RemainPoints.Count == 0
                    }
                    progressBar.Value =  74;
                    // 循环结束，输出List为IFeatureClass
                    this.textBox_Infowindow.Text += Environment.NewLine + "排序完成"+Environment.NewLine+" --当前耗时：" + t.Elapsed.TotalSeconds.ToString() + ",进入下一步...";
                    dp.ListToFeatureClass(dp.SurplusPoints, "SortResult" ,dp.SurplusPoints.Count);
                }
                catch(Exception exception)
                {
                    MessageBox.Show(exception.Message + Environment.NewLine + "我也不知道出了什么问题XD");
                }
            }
            else
            {
                MessageBox.Show("请选择【初始凸壳点图层】、【剩余点图层】。");
            }
            // 计时器停止
            progressBar.Value = 100;
            t.Stop();
            this.textBox_Infowindow.Text +=
                Environment.NewLine+
                "总排序点数：" + dp.SurplusPoints.Count.ToString() 
                + Environment.NewLine +
                "用时(秒): " + t.Elapsed.TotalSeconds.ToString();
        }

        private void btn_ClearSelect_Click(object sender, EventArgs e)
        {
            // 先解绑定事件
            listBox_Surplus.SelectedIndexChanged -= listBox_Surplus_SelectedIndexChanged;
            listBox_Remain.SelectedIndexChanged -= listBox_Remain_SelectedIndexChanged;
            // 然后清除选择
            ClearList();
            surplusLayer = null;
            remainLayer = null;
            dp.SurplusPoints.Clear();
            dp.RemainPoints.Clear();
            dp.OrderByElevation.Clear();
            dp.OrderByDistance.Clear();
            dp.OrderByVolume.Clear();
            // 然后添加绑定
            listBox_Surplus.SelectedIndexChanged += listBox_Surplus_SelectedIndexChanged;
            listBox_Remain.SelectedIndexChanged += listBox_Remain_SelectedIndexChanged;
        }

        private void Btn_GetNPoints_Click(object sender, EventArgs e)
        {
            int pointsNum = Convert.ToInt32(textBox_PointsNum.Text);

            if (dp.SurplusPoints.Count == 0)
                MessageBox.Show("点数不对！请进行计算。");
            else if (pointsNum < 0 || pointsNum > dp.SurplusPoints.Count)
                MessageBox.Show("输入有误");
            else
                dp.ListToFeatureClass(dp.SurplusPoints, "HeadFirst" + pointsNum.ToString(), pointsNum);
        }

        private void radioBtn_Elevation_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn_Elevation.Checked)
                calcMethod = CalcMethod.Elevation;
        }

        private void radioBtn_Distance_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn_Distance.Checked)
                calcMethod = CalcMethod.Distance;
        }

        private void radioBtn_Volume_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtn_Volume.Checked)
                calcMethod = CalcMethod.Volume;
        }
    }
}
