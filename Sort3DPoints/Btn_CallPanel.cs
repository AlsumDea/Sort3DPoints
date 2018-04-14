using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Framework;

namespace Sort3DPoints
{
    public class Btn_CallPanel : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public Btn_CallPanel()
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
            IDockableWindow dockWindow = ArcMap.DockableWindowManager.GetDockableWindow(dockWinID);

            //展示浮动窗
            if (dockWindow != null && !dockWindow.IsVisible())
                dockWindow.Show(true);
            ArcMap.Application.CurrentTool = null;
        }
        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }
    }

}
