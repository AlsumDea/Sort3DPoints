namespace Sort3DPoints
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Calculate = new System.Windows.Forms.Button();
            this.btn_ClearSelect = new System.Windows.Forms.Button();
            this.listBox_Surplus = new System.Windows.Forms.ListBox();
            this.listBox_Remain = new System.Windows.Forms.ListBox();
            this.textBox_Infowindow = new System.Windows.Forms.TextBox();
            this.btn_Readlayer = new System.Windows.Forms.Button();
            this.Btn_GetNPoints = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.radioBtn_Elevation = new System.Windows.Forms.RadioButton();
            this.radioBtn_Distance = new System.Windows.Forms.RadioButton();
            this.radioBtn_Volume = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_PointsNum = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "初始点集";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(4, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "剩余点集";
            // 
            // btn_Calculate
            // 
            this.btn_Calculate.BackColor = System.Drawing.Color.LightCyan;
            this.btn_Calculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Calculate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Calculate.Location = new System.Drawing.Point(171, 265);
            this.btn_Calculate.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Calculate.Name = "btn_Calculate";
            this.btn_Calculate.Size = new System.Drawing.Size(77, 30);
            this.btn_Calculate.TabIndex = 2;
            this.btn_Calculate.Text = "执行计算";
            this.btn_Calculate.UseVisualStyleBackColor = false;
            this.btn_Calculate.Click += new System.EventHandler(this.btn_Calculate_Click);
            // 
            // btn_ClearSelect
            // 
            this.btn_ClearSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ClearSelect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ClearSelect.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btn_ClearSelect.Location = new System.Drawing.Point(90, 265);
            this.btn_ClearSelect.Name = "btn_ClearSelect";
            this.btn_ClearSelect.Size = new System.Drawing.Size(75, 30);
            this.btn_ClearSelect.TabIndex = 2;
            this.btn_ClearSelect.Text = "清空";
            this.btn_ClearSelect.UseVisualStyleBackColor = true;
            this.btn_ClearSelect.Click += new System.EventHandler(this.btn_ClearSelect_Click);
            // 
            // listBox_Surplus
            // 
            this.listBox_Surplus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_Surplus.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_Surplus.FormattingEnabled = true;
            this.listBox_Surplus.ItemHeight = 19;
            this.listBox_Surplus.Location = new System.Drawing.Point(5, 26);
            this.listBox_Surplus.Name = "listBox_Surplus";
            this.listBox_Surplus.Size = new System.Drawing.Size(243, 78);
            this.listBox_Surplus.TabIndex = 3;
            this.listBox_Surplus.SelectedIndexChanged += new System.EventHandler(this.listBox_Surplus_SelectedIndexChanged);
            // 
            // listBox_Remain
            // 
            this.listBox_Remain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_Remain.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_Remain.FormattingEnabled = true;
            this.listBox_Remain.ItemHeight = 19;
            this.listBox_Remain.Location = new System.Drawing.Point(5, 127);
            this.listBox_Remain.Name = "listBox_Remain";
            this.listBox_Remain.Size = new System.Drawing.Size(243, 78);
            this.listBox_Remain.TabIndex = 3;
            this.listBox_Remain.SelectedIndexChanged += new System.EventHandler(this.listBox_Remain_SelectedIndexChanged);
            // 
            // textBox_Infowindow
            // 
            this.textBox_Infowindow.AcceptsTab = true;
            this.textBox_Infowindow.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox_Infowindow.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Infowindow.Location = new System.Drawing.Point(5, 301);
            this.textBox_Infowindow.Multiline = true;
            this.textBox_Infowindow.Name = "textBox_Infowindow";
            this.textBox_Infowindow.ReadOnly = true;
            this.textBox_Infowindow.Size = new System.Drawing.Size(243, 100);
            this.textBox_Infowindow.TabIndex = 4;
            this.textBox_Infowindow.Text = "信息提示处";
            // 
            // btn_Readlayer
            // 
            this.btn_Readlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Readlayer.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Readlayer.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btn_Readlayer.Location = new System.Drawing.Point(5, 265);
            this.btn_Readlayer.Name = "btn_Readlayer";
            this.btn_Readlayer.Size = new System.Drawing.Size(75, 30);
            this.btn_Readlayer.TabIndex = 2;
            this.btn_Readlayer.Text = "读图层";
            this.btn_Readlayer.UseVisualStyleBackColor = true;
            this.btn_Readlayer.Click += new System.EventHandler(this.btn_Readlayer_Click);
            // 
            // Btn_GetNPoints
            // 
            this.Btn_GetNPoints.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_GetNPoints.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_GetNPoints.Location = new System.Drawing.Point(163, 19);
            this.Btn_GetNPoints.Name = "Btn_GetNPoints";
            this.Btn_GetNPoints.Size = new System.Drawing.Size(75, 32);
            this.Btn_GetNPoints.TabIndex = 6;
            this.Btn_GetNPoints.Text = "取前N点";
            this.Btn_GetNPoints.UseVisualStyleBackColor = true;
            this.Btn_GetNPoints.Click += new System.EventHandler(this.Btn_GetNPoints_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(13, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "取点数";
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.progressBar.Location = new System.Drawing.Point(6, 57);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(232, 14);
            this.progressBar.TabIndex = 9;
            // 
            // radioBtn_Elevation
            // 
            this.radioBtn_Elevation.AutoSize = true;
            this.radioBtn_Elevation.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioBtn_Elevation.Location = new System.Drawing.Point(13, 16);
            this.radioBtn_Elevation.Name = "radioBtn_Elevation";
            this.radioBtn_Elevation.Size = new System.Drawing.Size(62, 21);
            this.radioBtn_Elevation.TabIndex = 10;
            this.radioBtn_Elevation.TabStop = true;
            this.radioBtn_Elevation.Text = "高程差";
            this.radioBtn_Elevation.UseVisualStyleBackColor = true;
            this.radioBtn_Elevation.CheckedChanged += new System.EventHandler(this.radioBtn_Elevation_CheckedChanged);
            // 
            // radioBtn_Distance
            // 
            this.radioBtn_Distance.AutoSize = true;
            this.radioBtn_Distance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioBtn_Distance.Location = new System.Drawing.Point(84, 16);
            this.radioBtn_Distance.Name = "radioBtn_Distance";
            this.radioBtn_Distance.Size = new System.Drawing.Size(74, 21);
            this.radioBtn_Distance.TabIndex = 10;
            this.radioBtn_Distance.TabStop = true;
            this.radioBtn_Distance.Text = "点面距⊥";
            this.radioBtn_Distance.UseVisualStyleBackColor = true;
            this.radioBtn_Distance.CheckedChanged += new System.EventHandler(this.radioBtn_Distance_CheckedChanged);
            // 
            // radioBtn_Volume
            // 
            this.radioBtn_Volume.AutoSize = true;
            this.radioBtn_Volume.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioBtn_Volume.Location = new System.Drawing.Point(167, 16);
            this.radioBtn_Volume.Name = "radioBtn_Volume";
            this.radioBtn_Volume.Size = new System.Drawing.Size(69, 21);
            this.radioBtn_Volume.TabIndex = 10;
            this.radioBtn_Volume.TabStop = true;
            this.radioBtn_Volume.Text = "体量差△";
            this.radioBtn_Volume.UseVisualStyleBackColor = true;
            this.radioBtn_Volume.CheckedChanged += new System.EventHandler(this.radioBtn_Volume_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.progressBar);
            this.groupBox1.Controls.Add(this.textBox_PointsNum);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Btn_GetNPoints);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(5, 407);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 77);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "后续处理";
            // 
            // textBox_PointsNum
            // 
            this.textBox_PointsNum.Location = new System.Drawing.Point(70, 22);
            this.textBox_PointsNum.Name = "textBox_PointsNum";
            this.textBox_PointsNum.Size = new System.Drawing.Size(87, 26);
            this.textBox_PointsNum.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioBtn_Distance);
            this.groupBox2.Controls.Add(this.radioBtn_Elevation);
            this.groupBox2.Controls.Add(this.radioBtn_Volume);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(7, 218);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 43);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "排序依据";
            // 
            // OperationPanel
            // 
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox_Infowindow);
            this.Controls.Add(this.listBox_Remain);
            this.Controls.Add(this.listBox_Surplus);
            this.Controls.Add(this.btn_Readlayer);
            this.Controls.Add(this.btn_ClearSelect);
            this.Controls.Add(this.btn_Calculate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(255, 900);
            this.Name = "OperationPanel";
            this.Size = new System.Drawing.Size(255, 487);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Calculate;
        private System.Windows.Forms.Button btn_ClearSelect;
        private System.Windows.Forms.ListBox listBox_Surplus;
        private System.Windows.Forms.ListBox listBox_Remain;
        private System.Windows.Forms.TextBox textBox_Infowindow;
        private System.Windows.Forms.Button btn_Readlayer;
        private System.Windows.Forms.Button Btn_GetNPoints;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.RadioButton radioBtn_Elevation;
        private System.Windows.Forms.RadioButton radioBtn_Distance;
        private System.Windows.Forms.RadioButton radioBtn_Volume;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_PointsNum;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
