namespace CameraViewer.Forms
{
    partial class frmDecoder
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
            this.components = new System.ComponentModel.Container();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.textEditname = new DevExpress.XtraEditors.TextEdit();
            this.textEditIp = new DevExpress.XtraEditors.TextEdit();
            this.textEditport = new DevExpress.XtraEditors.TextEdit();
            this.textEditmax = new DevExpress.XtraEditors.TextEdit();
            this.simpleButtonOk = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtoncancle = new DevExpress.XtraEditors.SimpleButton();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.textEditname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditmax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(17, 25);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "解码器名称：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(17, 72);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(59, 14);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "解码器IP：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(17, 119);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(72, 14);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "解码器端口：";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(17, 166);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(72, 14);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "最大解码数：";
            // 
            // textEditname
            // 
            this.textEditname.Location = new System.Drawing.Point(95, 22);
            this.textEditname.Name = "textEditname";
            this.textEditname.Size = new System.Drawing.Size(115, 21);
            this.textEditname.TabIndex = 1;
            // 
            // textEditIp
            // 
            this.textEditIp.Location = new System.Drawing.Point(95, 69);
            this.textEditIp.Name = "textEditIp";
            this.textEditIp.Size = new System.Drawing.Size(115, 21);
            this.textEditIp.TabIndex = 2;
            // 
            // textEditport
            // 
            this.textEditport.Location = new System.Drawing.Point(95, 116);
            this.textEditport.Name = "textEditport";
            this.textEditport.Size = new System.Drawing.Size(115, 21);
            this.textEditport.TabIndex = 3;
            // 
            // textEditmax
            // 
            this.textEditmax.Location = new System.Drawing.Point(95, 163);
            this.textEditmax.Name = "textEditmax";
            this.textEditmax.Size = new System.Drawing.Size(115, 21);
            this.textEditmax.TabIndex = 4;
            // 
            // simpleButtonOk
            // 
            this.simpleButtonOk.Location = new System.Drawing.Point(17, 209);
            this.simpleButtonOk.Name = "simpleButtonOk";
            this.simpleButtonOk.Size = new System.Drawing.Size(76, 34);
            this.simpleButtonOk.TabIndex = 5;
            this.simpleButtonOk.Text = "确定";
            this.simpleButtonOk.Click += new System.EventHandler(this.AddDecoderButton);
            // 
            // simpleButtoncancle
            // 
            this.simpleButtoncancle.Location = new System.Drawing.Point(134, 209);
            this.simpleButtoncancle.Name = "simpleButtoncancle";
            this.simpleButtoncancle.Size = new System.Drawing.Size(76, 34);
            this.simpleButtoncancle.TabIndex = 6;
            this.simpleButtoncancle.Text = "取消";
            this.simpleButtoncancle.Click += new System.EventHandler(this.simpleButtoncancle_Click);
            // 
            // frmDecoder
            // 
            this.AcceptButton = this.simpleButtonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 268);
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
            this.MaximizeBox = false;
            this.Name = "frmDecoder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增解码器";
            ((System.ComponentModel.ISupportInitialize)(this.textEditname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditIp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditmax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit textEditname;
        private DevExpress.XtraEditors.TextEdit textEditIp;
        private DevExpress.XtraEditors.TextEdit textEditport;
        private DevExpress.XtraEditors.TextEdit textEditmax;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOk;
        private DevExpress.XtraEditors.SimpleButton simpleButtoncancle;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}