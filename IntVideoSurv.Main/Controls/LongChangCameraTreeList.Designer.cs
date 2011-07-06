namespace CameraViewer.Controls
{
    partial class LongChangCameraTreeList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlCamera = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.tlCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            this.tlCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlCamera.Location = new System.Drawing.Point(0, 0);
            this.tlCamera.Name = "tlCamera";
            this.tlCamera.Size = new System.Drawing.Size(188, 341);
            this.tlCamera.TabIndex = 0;
            // 
            // LongChangCameraTreeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlCamera);
            this.Name = "LongChangCameraTreeList";
            this.Size = new System.Drawing.Size(188, 341);
            ((System.ComponentModel.ISupportInitialize)(this.tlCamera)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList tlCamera;
    }
}
