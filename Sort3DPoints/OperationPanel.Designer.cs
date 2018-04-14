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
            this.textBox_PointsNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
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
            this.label2.Location = new System.Drawing.Point(4, 131);
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
            this.btn_Calculate.Location = new System.Drawing.Point(171, 239);
            this.btn_Calculate.Name = "btn_Calculate";
            this.btn_Calculate.Size = new System.Drawing.Size(77, 32);
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
            this.btn_ClearSelect.Location = new System.Drawing.Point(90, 239);
            this.btn_ClearSelect.Name = "btn_ClearSelect";
            this.btn_ClearSelect.Size = new System.Drawing.Size(75, 32);
            this.btn_ClearSelect.TabIndex = 2;
            this.btn_ClearSelect.Text = "清空选择";
            this.btn_ClearSelect.UseVisualStyleBackColor = true;
            this.btn_ClearSelect.Click += new System.EventHandler(this.btn_ClearSelect_Click);
            // 
            // listBox_Surplus
            // 
            this.listBox_Surplus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_Surplus.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_Surplus.FormattingEnabled = true;
            this.listBox_Surplus.ItemHeight = 20;
            this.listBox_Surplus.Location = new System.Drawing.Point(5, 26);
            this.listBox_Surplus.Name = "listBox_Surplus";
            this.listBox_Surplus.Size = new System.Drawing.Size(243, 102);
            this.listBox_Surplus.TabIndex = 3;
            this.listBox_Surplus.SelectedIndexChanged += new System.EventHandler(this.listBox_Surplus_SelectedIndexChanged);
            // 
            // listBox_Remain
            // 
            this.listBox_Remain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_Remain.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_Remain.FormattingEnabled = true;
            this.listBox_Remain.ItemHeight = 20;
            this.listBox_Remain.Location = new System.Drawing.Point(5, 152);
            this.listBox_Remain.Name = "listBox_Remain";
            this.listBox_Remain.Size = new System.Drawing.Size(243, 82);
            this.listBox_Remain.TabIndex = 3;
            this.listBox_Remain.SelectedIndexChanged += new System.EventHandler(this.listBox_Remain_SelectedIndexChanged);
            // 
            // textBox_Infowindow
            // 
            this.textBox_Infowindow.AcceptsTab = true;
            this.textBox_Infowindow.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox_Infowindow.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Infowindow.Location = new System.Drawing.Point(5, 277);
            this.textBox_Infowindow.Multiline = true;
            this.textBox_Infowindow.Name = "textBox_Infowindow";
            this.textBox_Infowindow.ReadOnly = true;
            this.textBox_Infowindow.Size = new System.Drawing.Size(243, 191);
            this.textBox_Infowindow.TabIndex = 4;
            this.textBox_Infowindow.Text = "信息提示处";
            // 
            // btn_Readlayer
            // 
            this.btn_Readlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Readlayer.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Readlayer.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btn_Readlayer.Location = new System.Drawing.Point(9, 239);
            this.btn_Readlayer.Name = "btn_Readlayer";
            this.btn_Readlayer.Size = new System.Drawing.Size(75, 32);
            this.btn_Readlayer.TabIndex = 2;
            this.btn_Readlayer.Text = "读图层";
            this.btn_Readlayer.UseVisualStyleBackColor = true;
            this.btn_Readlayer.Click += new System.EventHandler(this.btn_Readlayer_Click);
            // 
            // Btn_GetNPoints
            // 
            this.Btn_GetNPoints.Location = new System.Drawing.Point(171, 478);
            this.Btn_GetNPoints.Name = "Btn_GetNPoints";
            this.Btn_GetNPoints.Size = new System.Drawing.Size(75, 23);
            this.Btn_GetNPoints.TabIndex = 6;
            this.Btn_GetNPoints.Text = "取前N点";
            this.Btn_GetNPoints.UseVisualStyleBackColor = true;
            this.Btn_GetNPoints.Click += new System.EventHandler(this.Btn_GetNPoints_Click);
            // 
            // textBox_PointsNum
            // 
            this.textBox_PointsNum.Location = new System.Drawing.Point(44, 479);
            this.textBox_PointsNum.Name = "textBox_PointsNum";
            this.textBox_PointsNum.Size = new System.Drawing.Size(121, 21);
            this.textBox_PointsNum.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(6, 482);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "点数";
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.progressBar.Location = new System.Drawing.Point(5, 506);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(243, 23);
            this.progressBar.TabIndex = 9;
            // 
            // OperationPanel
            // 
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_PointsNum);
            this.Controls.Add(this.Btn_GetNPoints);
            this.Controls.Add(this.textBox_Infowindow);
            this.Controls.Add(this.listBox_Remain);
            this.Controls.Add(this.listBox_Surplus);
            this.Controls.Add(this.btn_Readlayer);
            this.Controls.Add(this.btn_ClearSelect);
            this.Controls.Add(this.btn_Calculate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "OperationPanel";
            this.Size = new System.Drawing.Size(255, 900);
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
        private System.Windows.Forms.TextBox textBox_PointsNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}
