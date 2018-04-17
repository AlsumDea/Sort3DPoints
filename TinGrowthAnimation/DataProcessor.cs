using System;
using ESRI.ArcGIS.Analyst3D;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System.Windows.Forms;
using System.Collections.Generic;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.esriSystem;

namespace TinGrowthAnimation
{
    class DataProcessor
    {
        public IFeatureLayer IsIFeatureLayer(ILayer layer)
        {
            if (layer is IFeatureLayer)
                return layer as IFeatureLayer;
            else
                return null;
        }

        public List<IPoint> ToList(IFeatureClass featureClass)
        {
            List<IPoint> pts = new List<IPoint>();
            IFeatureCursor featureCursor = featureClass.Search(new QueryFilterClass(), true);
            IFeature feature = featureCursor.NextFeature();
            while (feature != null)
            {
                pts.Add(feature.Shape as IPoint);
                feature = featureCursor.NextFeature();
            }
            return pts;
        }

        public ITin CreateFirstTin(IFeatureClass featureClass, IEnvelope box, string TinPath, int from)
        {
            ITinEdit tinEdit = new TinClass();
            tinEdit.InitNew(box);
            IFeatureCursor featureCursor = featureClass.Search(new QueryFilterClass(), true);
            IField zF = featureClass.Fields.Field[featureClass.FindField("Z")];
            IFeature feature = featureCursor.NextFeature();
            int i = 0;
            while (feature != null && i < from) 
            {
                tinEdit.AddShapeZ(feature.Shape, esriTinSurfaceType.esriTinMassPoint, 0);
                i++;
                feature = featureCursor.NextFeature();
            }

            tinEdit.SaveAs(@TinPath, true);
            tinEdit.Refresh();
            return tinEdit as ITin;
        }
    }
}
