using ESRI.ArcGIS.Analyst3D;
using ESRI.ArcGIS.ArcScene;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TinGrowthAnimation
{
    /// <summary>
    /// Designer class of the dockable window add-in. It contains user interfaces that
    /// make up the dockable window.
    /// </summary>
    public partial class OperationPanel : UserControl
    {
        IScene nowScene = (ArcScene.Application.Document as ISxDocument).Scene;
        IActiveView nowSceneActiveView;
        IFeatureLayer featureLayer = null;
        IFeature featureTemp;

        IFeatureCursor featureCursor = null;
        DataProcessor dp;
        private int step;
        private string tinPath;
        private string tinNameExt;
        ITin tinNext;
        ITinLayer tinLayer = new TinLayerClass();
        bool isCalcFirst = true;
        // 起始值
        int nowID = 200;


        #region 自动生成代码

        public OperationPanel(object hook)
        {
            InitializeComponent();
            this.Hook = hook;
            dp = new DataProcessor();
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
        /// <param name="scene"></param>
        private void ReadLayer(IScene scene, ListBox listBox)
        {
            int layerCount = scene.LayerCount;
            for (int i = 0; i < layerCount; i++)
            {
                listBox.Items.Add(scene.Layer[i].Name);
            }

        }

        private void btn_ReadLayer_Click(object sender, EventArgs e)
        {
            listBox_LayerList.Items.Clear();
            ReadLayer(this.nowScene, this.listBox_LayerList);
            if (listBox_LayerList.Items.Count != 0)
            {
                listBox_LayerList.SelectedIndex = 0;
                MessageBox.Show("读取图层完成。");
            }
            else
                MessageBox.Show("没有图层。");
        }

        private void btn_GetFeatureLayer_Click(object sender, EventArgs e)
        {
            int id = this.listBox_LayerList.SelectedIndex;
            featureLayer = dp.IsIFeatureLayer(nowScene.Layer[id]);
            if (featureLayer != null)
                this.textBox_Infowindow.Text += 
                    Environment.NewLine + "要素图层读取成功，要素个数：" +
                    featureLayer.FeatureClass.FeatureCount(new QueryFilterClass())
                    .ToString();
            else
                MessageBox.Show("选择的不是要素图层。");
        }

        /// <summary>
        /// 选择输出Tin的地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SaveFileDialog_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Title = "请选择Tin输出地址",
                Filter = "所有文件(*.*)|*.*",
                RestoreDirectory = true,
                OverwritePrompt = true
            };
            dialog.ShowDialog();
            this.textBox_TinPath.Text = tinPath = dialog.FileName;
            this.tinNameExt = tinPath.Substring(tinPath.LastIndexOf(@"\") + 1);
        }

        /// <summary>
        /// 生成第一个Tin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Animation_Click(object sender, EventArgs e)
        {
            nowSceneActiveView = nowScene as IActiveView;
            if (featureLayer != null && tinPath != null && tinNameExt != null)
            {
                int from = 200;
                tinNext = dp.CreateFirstTin(featureLayer.FeatureClass, featureLayer.AreaOfInterest, tinPath, from);
                tinLayer.Name = tinNameExt;
                tinLayer.Dataset = tinNext;

                nowScene.AddLayer(tinLayer as ILayer);
                nowSceneActiveView.PartialRefresh(esriViewDrawPhase.esriViewAll, null, tinLayer.AreaOfInterest);
                // doNext(tinNext, featureLayer.FeatureClass, tinLayer, nowSceneActiveView, from, step);
            }
            featureCursor = featureLayer.FeatureClass.Search(new QueryFilterClass(), true);
            int featureCount = featureLayer.FeatureClass.FeatureCount(new QueryFilterClass());
            featureTemp = featureCursor.NextFeature();
            // 直接定位到第200个要素
            for (int i = 0; i < nowID || featureCursor.NextFeature() != null; i++)
            {
                featureTemp = featureCursor.NextFeature();
            }
        }

        private void doNext(ITin tinNext, IFeatureClass featureClass, ITinLayer tinLayer, IActiveView nowSceneActiveView, int from, int step)
        {
            IFeatureCursor featureCursor = featureClass.Search(new QueryFilterClass(), true);
            int featureCount = featureClass.FeatureCount(new QueryFilterClass());
            IFeature featureTemp = featureCursor.NextFeature();
            // 直接定位到第200个要素
            for (int i = 0; i < from; i++)
            {
                featureTemp = featureCursor.NextFeature();
            }

            while (featureTemp != null)
            {
                // 当剩余点数比步长大时，遍历十次
                if(featureCount - from > step)
                {
                    ITinEdit tinEdit = tinNext as ITinEdit;
                    for (int i = 0; i < step; i++)
                    {
                        tinEdit.AddShapeZ(featureTemp.Shape, esriTinSurfaceType.esriTinMassPoint, 0);
                        tinEdit.Save();
                        featureTemp = featureCursor.NextFeature();
                    }
                    from += step;
                    tinEdit.Refresh();
                    tinLayer.Dataset = tinEdit as ITin;
                    nowSceneActiveView.PartialRefresh(esriViewDrawPhase.esriViewAll, null, tinLayer.AreaOfInterest);

                }
                // 否则，遍历剩余点数直到遍历完成
                else
                {
                    ITinEdit tinEdit = tinNext as ITinEdit;
                    for (int i = 0; i < featureCount - from; i++)
                    {
                        tinEdit.AddShapeZ(featureTemp.Shape, esriTinSurfaceType.esriTinMassPoint, 0);
                        tinEdit.Save();
                        featureTemp = featureCursor.NextFeature();
                    }
                    tinEdit.Refresh();
                    tinLayer.Dataset = tinEdit as ITin;
                    nowSceneActiveView.PartialRefresh(esriViewDrawPhase.esriViewAll, null, tinLayer.AreaOfInterest);

                }
            }
        }

        /// <summary>
        /// 点一次刷新一次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_GenerateOnce_Click(object sender, EventArgs e)
        {
            nowSceneActiveView = nowScene as IActiveView;
            step = Convert.ToInt32(this.textBox_Step.Text);
            int featureCount = featureLayer.FeatureClass.FeatureCount(new QueryFilterClass());

            // 足步长
            if(featureCount - nowID > step)
            {
                ITinEdit tinEdit = tinNext as ITinEdit;

                // 加10个   
                for (int i = 0; i < step; i++)
                {
                    featureTemp = featureCursor.NextFeature();
                    IFeature f = featureLayer.FeatureClass.GetFeature(nowID + i + 1);
                    tinEdit.AddShapeZ(f.Shape, esriTinSurfaceType.esriTinMassPoint, 0);
                    tinEdit.Save();
                }
                tinEdit.Refresh();
                tinLayer.Dataset = tinEdit as ITin;
                //nowScene.SceneGraph.RefreshViewers();
                nowSceneActiveView.PartialRefresh(esriViewDrawPhase.esriViewAll, tinLayer, tinLayer.AreaOfInterest);
                nowID += step;
            }
            else
            {
                ITinEdit tinEdit = tinNext as ITinEdit;

                // 加剩余点   
                for (int i = 0; i < featureCount - nowID; i++)
                {
                    featureTemp = featureCursor.NextFeature();
                    IFeature f = featureLayer.FeatureClass.GetFeature(nowID + i + 1);
                    tinEdit.AddShapeZ(f.Shape, esriTinSurfaceType.esriTinMassPoint, 0);
                    tinEdit.Save();
                }
                tinEdit.Refresh();
                tinLayer.Dataset = tinEdit as ITin;
                //nowScene.SceneGraph.RefreshViewers();

                nowSceneActiveView.PartialRefresh(esriViewDrawPhase.esriViewAll, tinLayer, tinLayer.AreaOfInterest);
                    
            }
            
        }
    }
}
