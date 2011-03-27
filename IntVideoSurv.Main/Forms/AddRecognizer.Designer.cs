namespace CameraViewer.Forms
{
    partial class AddRecognizer
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
            this.simpleButtoncancle = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonOk = new DevExpress.XtraEditors.SimpleButton();
            this.textEditmax = new DevExpress.XtraEditors.TextEdit();
            this.textEditport = new DevExpress.XtraEditors.TextEdit();
            this.textEditIp = new DevExpress.XtraEditors.TextEdit();
            this.textEditname = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.textEditmax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditname.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButtoncancle
            // 
            this.simpleButtoncancle.Location = new System.Drawing.Point(145, 214);
            this.simpleButtoncancle.Name = "simpleButtoncancle";
            this.simpleButtoncancle.Size = new System.Drawing.Size(76, 34);
            this.simpleButtoncancle.TabIndex = 11;
            this.simpleButtoncancle.Text = "取消";
            this.simpleButtoncancle.Click += new System.EventHandler(this.simpleButtoncancle_Click);
            // 
            // simpleButtonOk
            // 
            this.simpleButtonOk.Location = new System.Drawing.Point(28, 214);
            this.simpleButtonOk.Name = "simpleButtonOk";
            this.simpleButtonOk.Size = new System.Drawing.Size(76, 34);
            this.simpleButtonOk.TabIndex = 12;
            this.simpleButtonOk.Text = "确定";
            this.simpleButtonOk.Click += new System.EventHandler(this.simpleButtonOk_Click);
            // 
            // textEditmax
            // 
            this.textEditmax.Location = new System.Drawing.Point(106, 168);
            this.textEditmax.Name = "textEditmax";
            this.textEditmax.Size = new System.Drawing.Size(115, 21);
            this.textEditmax.TabIndex = 8;
            // 
            // textEditport
            // 
            this.textEditport.Location = new System.Drawing.Point(106, 121);
            this.textEditport.Name = "textEditport";
            this.textEditport.Size = new System.Drawing.Size(115, 21);
            this.textEditport.TabIndex = 9;
            // 
            // textEditIp
            // 
            this.textEditIp.Location = new System.Drawing.Point(106, 74);
            this.textEditIp.Name = "textEditIp";
            this.textEditIp.Size = new System.Drawing.Size(115, 21);
            this.textEditIp.TabIndex = 10;
            // 
            // textEditname
            // 
            this.textEditname.Location = new System.Drawing.Point(106, 27);
            this.textEditname.Name = "textEditname";
            this.textEditname.Size = new System.Drawing.Size(115, 21);
            this.textEditname.TabIndex = 7;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(28, 171);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(72, 14);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "最大解码数：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(28, 124);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(72, 14);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "识别器端口：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(28, 77);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(59, 14);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "识别器IP：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(28, 30);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 14);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "识别器名称：";
            // 
            // AddRecognizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 273);
            this.Controls.Add(this.simpleButtoncancle);
            this.Controls.Add(this.simpleButtonOk);
            this.Controls.Add(this.textEditmax);
            this.Controls.Add(this.textEditport);
            this.Controls.Add(this.textEditIp);
            this.Controls.Add(this.textEditname);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Name = "AddRecognizer";
            this.Text = "新增识别器";
            ((System.ComponentModel.ISupportInitialize)(this.textEditmax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditname.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButtoncancle;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOk;
        private DevExpress.XtraEditors.TextEdit textEditmax;
        private DevExpress.XtraEditors.TextEdit textEditport;
        private DevExpress.XtraEditors.TextEdit textEditIp;
        private DevExpress.XtraEditors.TextEdit textEditname;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}