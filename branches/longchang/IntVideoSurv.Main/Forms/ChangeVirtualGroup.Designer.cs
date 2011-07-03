namespace CameraViewer.Forms
{
    partial class ChangeVirtualGroup
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
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttoncancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "新组名：";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(100, 23);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(131, 22);
            this.textBox_name.TabIndex = 1;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(46, 71);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 32);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttoncancle
            // 
            this.buttoncancle.Location = new System.Drawing.Point(142, 71);
            this.buttoncancle.Name = "buttoncancle";
            this.buttoncancle.Size = new System.Drawing.Size(75, 32);
            this.buttoncancle.TabIndex = 2;
            this.buttoncancle.Text = "取消";
            this.buttoncancle.UseVisualStyleBackColor = true;
            this.buttoncancle.Click += new System.EventHandler(this.buttoncancle_Click);
            // 
            // ChangeVirtualGroupName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 140);
            this.Controls.Add(this.buttoncancle);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label1);
            this.Name = "ChangeVirtualGroupName";
            this.Text = "修改组名";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttoncancle;
    }
}