namespace CameraViewer.Forms
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new DevExpress.XtraEditors.LabelControl();
            this.txtUserID = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.lblLoginInfo = new DevExpress.XtraEditors.LabelControl();
            this.labelPromoteInfo = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLogin.Location = new System.Drawing.Point(44, 140);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(87, 27);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "登录";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(159, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 27);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(42, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "用户名:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(42, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "密  码:";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(129, 19);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(117, 21);
            this.txtUserID.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.EditValue = "";
            this.txtPassword.Location = new System.Drawing.Point(129, 63);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(117, 21);
            this.txtPassword.TabIndex = 5;
            // 
            // lblLoginInfo
            // 
            this.lblLoginInfo.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblLoginInfo.Location = new System.Drawing.Point(71, 108);
            this.lblLoginInfo.Name = "lblLoginInfo";
            this.lblLoginInfo.Size = new System.Drawing.Size(0, 14);
            this.lblLoginInfo.TabIndex = 6;
            // 
            // labelPromoteInfo
            // 
            this.labelPromoteInfo.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelPromoteInfo.Location = new System.Drawing.Point(57, 108);
            this.labelPromoteInfo.Name = "labelPromoteInfo";
            this.labelPromoteInfo.Size = new System.Drawing.Size(0, 14);
            this.labelPromoteInfo.TabIndex = 7;
            // 
            // FormLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 195);
            this.Controls.Add(this.labelPromoteInfo);
            this.Controls.Add(this.lblLoginInfo);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录窗口";
            ((System.ComponentModel.ISupportInitialize)(this.txtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.TextEdit txtUserID;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        public DevExpress.XtraEditors.LabelControl lblLoginInfo;
        private DevExpress.XtraEditors.LabelControl labelPromoteInfo;
    }
}