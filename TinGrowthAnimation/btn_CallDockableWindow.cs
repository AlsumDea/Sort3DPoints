using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Framework;

namespace TinGrowthAnimation
{
    public class btn_CallDockableWindow : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public btn_CallDockableWindow()
        {
        }

        /// <summary>
        /// 这个按钮的功能就是呼出浮动窗
        /// </summary>
        protected override void OnClick()
        {
            //这三行代码固定的只能记住了
            UID dockWinID = new UIDClass();
            dockWinID.Value = ThisAddIn.IDs.OperationPanel;
            IDockableWindow dockWindow = ArcScene.DockableWindowManager.GetDockableWindow(dockWinID);

            //展示浮动窗
            if (dockWindow != null && !dockWindow.IsVisible())
                dockWindow.Show(true);
            ArcScene.Application.CurrentTool = null;
        }

        protected override void OnUpdate()
        {
            Enabled = ArcScene.Application != null;
        }
    }
}
