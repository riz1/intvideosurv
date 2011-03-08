namespace CameraViewer.Forms
{
    partial class AddCameraInDecoder
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.treeList1DecoderCamera = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1AddCamera = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1DecoderCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.treeList1DecoderCamera);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.simpleButton1AddCamera);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(268, 387);
            this.panelControl1.TabIndex = 0;
            this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            // 
            // treeList1DecoderCamera
            // 
            this.treeList1DecoderCamera.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.treeList1DecoderCamera.Location = new System.Drawing.Point(28, 38);
            this.treeList1DecoderCamera.Name = "treeList1DecoderCamera";
            this.treeList1DecoderCamera.OptionsBehavior.AutoFocusNewNode = true;
            this.treeList1DecoderCamera.OptionsBehavior.Editable = false;
            this.treeList1DecoderCamera.OptionsView.ShowColumns = false;
            this.treeList1DecoderCamera.OptionsView.ShowHorzLines = false;
            this.treeList1DecoderCamera.OptionsView.ShowIndicator = false;
            this.treeList1DecoderCamera.OptionsView.ShowVertLines = false;
            this.treeList1DecoderCamera.Size = new System.Drawing.Size(210, 282);
            this.treeList1DecoderCamera.TabIndex = 4;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "名称";
            this.treeListColumn1.FieldName = "名称";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "描述";
            this.treeListColumn2.FieldName = "描述";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(156, 335);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(82, 27);
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "取消";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1AddCamera
            // 
            this.simpleButton1AddCamera.Location = new System.Drawing.Point(28, 336);
            this.simpleButton1AddCamera.Name = "simpleButton1AddCamera";
            this.simpleButton1AddCamera.Size = new System.Drawing.Size(78, 26);
            this.simpleButton1AddCamera.TabIndex = 2;
            this.simpleButton1AddCamera.Text = "添加";
            this.simpleButton1AddCamera.Click += new System.EventHandler(this.simpleButton1AddCamera_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "请选择摄像头：";
            // 
            // AddCameraInDecoder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 387);
            this.Controls.Add(this.panelControl1);
            this.MaximizeBox = false;
            this.Name = "AddCameraInDecoder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加摄像头";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1DecoderCamera)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1AddCamera;
        private DevExpress.XtraTreeList.TreeList treeList1DecoderCamera;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
    }
}