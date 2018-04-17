namespace TinGrowthAnimation
{
    partial class OperationPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Animation = new System.Windows.Forms.Button();
            this.textBox_Step = new System.Windows.Forms.TextBox();
            this.label_Step = new System.Windows.Forms.Label();
            this.listBox_LayerList = new System.Windows.Forms.ListBox();
            this.btn_ReadLayer = new System.Windows.Forms.Button();
            this.textBox_TinPath = new System.Windows.Forms.TextBox();
            this.btn_SaveFileDialog = new System.Windows.Forms.Button();
            this.label_LayerList = new System.Windows.Forms.Label();
            this.label_TinPath = new System.Windows.Forms.Label();
            this.textBox_Infowindow = new System.Windows.Forms.TextBox();
            this.btn_GetFeatureLayer = new System.Windows.Forms.Button();
            this.btn_GenerateOnce = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Animation
            // 
            this.btn_Animation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Animation.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Animation.Location = new System.Drawing.Point(177, 291);
            this.btn_Animation.Name = "btn_Animation";
            this.btn_Animation.Size = new System.Drawing.Size(75, 28);
            this.btn_Animation.TabIndex = 0;
            this.btn_Animation.Text = "动画生成";
            this.btn_Animation.UseVisualStyleBackColor = true;
            this.btn_Animation.Click += new System.EventHandler(this.btn_Animation_Click);
            // 
            // textBox_Step
            // 
            this.textBox_Step.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Step.Location = new System.Drawing.Point(47, 294);
            this.textBox_Step.Name = "textBox_Step";
            this.textBox_Step.Size = new System.Drawing.Size(64, 23);
            this.textBox_Step.TabIndex = 1;
            // 
            // label_Step
            // 
            this.label_Step.AutoSize = true;
            this.label_Step.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Step.Location = new System.Drawing.Point(6, 294);
            this.label_Step.Name = "label_Step";
            this.label_Step.Size = new System.Drawing.Size(37, 20);
            this.label_Step.TabIndex = 3;
            this.label_Step.Text = "步长";
            // 
            // listBox_LayerList
            // 
            this.listBox_LayerList.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_LayerList.FormattingEnabled = true;
            this.listBox_LayerList.ItemHeight = 17;
            this.listBox_LayerList.Location = new System.Drawing.Point(3, 41);
            this.listBox_LayerList.Name = "listBox_LayerList";
            this.listBox_LayerList.Size = new System.Drawing.Size(249, 123);
            this.listBox_LayerList.TabIndex = 4;
            // 
            // btn_ReadLayer
            // 
            this.btn_ReadLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ReadLayer.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ReadLayer.Location = new System.Drawing.Point(83, 7);
            this.btn_ReadLayer.Name = "btn_ReadLayer";
            this.btn_ReadLayer.Size = new System.Drawing.Size(72, 32);
            this.btn_ReadLayer.TabIndex = 5;
            this.btn_ReadLayer.Text = "读图层";
            this.btn_ReadLayer.UseVisualStyleBackColor = true;
            this.btn_ReadLayer.Click += new System.EventHandler(this.btn_ReadLayer_Click);
            // 
            // textBox_TinPath
            // 
            this.textBox_TinPath.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_TinPath.Location = new System.Drawing.Point(57, 179);
            this.textBox_TinPath.Name = "textBox_TinPath";
            this.textBox_TinPath.ReadOnly = true;
            this.textBox_TinPath.Size = new System.Drawing.Size(160, 23);
            this.textBox_TinPath.TabIndex = 6;
            // 
            // btn_SaveFileDialog
            // 
            this.btn_SaveFileDialog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_SaveFileDialog.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SaveFileDialog.Location = new System.Drawing.Point(223, 179);
            this.btn_SaveFileDialog.Name = "btn_SaveFileDialog";
            this.btn_SaveFileDialog.Size = new System.Drawing.Size(29, 23);
            this.btn_SaveFileDialog.TabIndex = 7;
            this.btn_SaveFileDialog.Text = "...";
            this.btn_SaveFileDialog.UseVisualStyleBackColor = true;
            this.btn_SaveFileDialog.Click += new System.EventHandler(this.btn_SaveFileDialog_Click);
            // 
            // label_LayerList
            // 
            this.label_LayerList.AutoSize = true;
            this.label_LayerList.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_LayerList.Location = new System.Drawing.Point(3, 12);
            this.label_LayerList.Name = "label_LayerList";
            this.label_LayerList.Size = new System.Drawing.Size(74, 22);
            this.label_LayerList.TabIndex = 8;
            this.label_LayerList.Text = "图层列表";
            // 
            // label_TinPath
            // 
            this.label_TinPath.AutoSize = true;
            this.label_TinPath.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_TinPath.Location = new System.Drawing.Point(3, 182);
            this.label_TinPath.Name = "label_TinPath";
            this.label_TinPath.Size = new System.Drawing.Size(52, 17);
            this.label_TinPath.TabIndex = 9;
            this.label_TinPath.Text = "Tin输出";
            // 
            // textBox_Infowindow
            // 
            this.textBox_Infowindow.Location = new System.Drawing.Point(3, 206);
            this.textBox_Infowindow.Multiline = true;
            this.textBox_Infowindow.Name = "textBox_Infowindow";
            this.textBox_Infowindow.ReadOnly = true;
            this.textBox_Infowindow.Size = new System.Drawing.Size(249, 79);
            this.textBox_Infowindow.TabIndex = 10;
            // 
            // btn_GetFeatureLayer
            // 
            this.btn_GetFeatureLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GetFeatureLayer.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_GetFeatureLayer.Location = new System.Drawing.Point(161, 7);
            this.btn_GetFeatureLayer.Name = "btn_GetFeatureLayer";
            this.btn_GetFeatureLayer.Size = new System.Drawing.Size(91, 32);
            this.btn_GetFeatureLayer.TabIndex = 5;
            this.btn_GetFeatureLayer.Text = "取要素层";
            this.btn_GetFeatureLayer.UseVisualStyleBackColor = true;
            this.btn_GetFeatureLayer.Click += new System.EventHandler(this.btn_GetFeatureLayer_Click);
            // 
            // btn_GenerateOnce
            // 
            this.btn_GenerateOnce.Location = new System.Drawing.Point(10, 322);
            this.btn_GenerateOnce.Name = "btn_GenerateOnce";
            this.btn_GenerateOnce.Size = new System.Drawing.Size(242, 62);
            this.btn_GenerateOnce.TabIndex = 11;
            this.btn_GenerateOnce.Text = "生成一次";
            this.btn_GenerateOnce.UseVisualStyleBackColor = true;
            this.btn_GenerateOnce.Click += new System.EventHandler(this.btn_GenerateOnce_Click);
            // 
            // OperationPanel
            // 
            this.Controls.Add(this.btn_GenerateOnce);
            this.Controls.Add(this.textBox_Infowindow);
            this.Controls.Add(this.label_TinPath);
            this.Controls.Add(this.label_LayerList);
            this.Controls.Add(this.btn_SaveFileDialog);
            this.Controls.Add(this.textBox_TinPath);
            this.Controls.Add(this.btn_GetFeatureLayer);
            this.Controls.Add(this.btn_ReadLayer);
            this.Controls.Add(this.listBox_LayerList);
            this.Controls.Add(this.label_Step);
            this.Controls.Add(this.textBox_Step);
            this.Controls.Add(this.btn_Animation);
            this.MinimumSize = new System.Drawing.Size(255, 350);
            this.Name = "OperationPanel";
            this.Size = new System.Drawing.Size(255, 390);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Animation;
        private System.Windows.Forms.TextBox textBox_Step;
        private System.Windows.Forms.Label label_Step;
        private System.Windows.Forms.ListBox listBox_LayerList;
        private System.Windows.Forms.Button btn_ReadLayer;
        private System.Windows.Forms.TextBox textBox_TinPath;
        private System.Windows.Forms.Button btn_SaveFileDialog;
        private System.Windows.Forms.Label label_LayerList;
        private System.Windows.Forms.Label label_TinPath;
        private System.Windows.Forms.TextBox textBox_Infowindow;
        private System.Windows.Forms.Button btn_GetFeatureLayer;
        private System.Windows.Forms.Button btn_GenerateOnce;
    }
}
