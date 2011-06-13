namespace CameraViewer.Forms
{
    partial class AddCameraInVirtualGroup
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
            this.treeList1CameraInVirtualGroup = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.simpleButtonCancelInVG = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1AddCameraInVirtualGroup = new DevExpress.XtraEditors.SimpleButton();
            this.labelControlselec = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1CameraInVirtualGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.treeList1CameraInVirtualGroup);
            this.panelControl1.Controls.Add(this.simpleButtonCancelInVG);
            this.panelControl1.Controls.Add(this.simpleButton1AddCameraInVirtualGroup);
            this.panelControl1.Controls.Add(this.labelControlselec);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(268, 387);
            this.panelControl1.TabIndex = 1;
            // 
            // treeList1CameraInVirtualGroup
            // 
            this.treeList1CameraInVirtualGroup.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.treeList1CameraInVirtualGroup.Location = new System.Drawing.Point(28, 38);
            this.treeList1CameraInVirtualGroup.Name = "treeList1CameraInVirtualGroup";
            this.treeList1CameraInVirtualGroup.OptionsBehavior.AutoFocusNewNode = true;
            this.treeList1CameraInVirtualGroup.OptionsBehavior.Editable = false;
            this.treeList1CameraInVirtualGroup.OptionsSelection.InvertSelection = true;
            this.treeList1CameraInVirtualGroup.OptionsView.ShowColumns = false;
            this.treeList1CameraInVirtualGroup.OptionsView.ShowHorzLines = false;
            this.treeList1CameraInVirtualGroup.OptionsView.ShowIndicator = false;
            this.treeList1CameraInVirtualGroup.OptionsView.ShowVertLines = false;
            this.treeList1CameraInVirtualGroup.Size = new System.Drawing.Size(210, 282);
            this.treeList1CameraInVirtualGroup.TabIndex = 4;
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
            // simpleButtonCancelInVG
            // 
            this.simpleButtonCancelInVG.Location = new System.Drawing.Point(156, 335);
            this.simpleButtonCancelInVG.Name = "simpleButtonCancelInVG";
            this.simpleButtonCancelInVG.Size = new System.Drawing.Size(82, 27);
            this.simpleButtonCancelInVG.TabIndex = 3;
            this.simpleButtonCancelInVG.Text = "取消";
            this.simpleButtonCancelInVG.Click += new System.EventHandler(this.simpleButtonCancelInVG_Click);
            // 
            // simpleButton1AddCameraInVirtualGroup
            // 
            this.simpleButton1AddCameraInVirtualGroup.Location = new System.Drawing.Point(28, 336);
            this.simpleButton1AddCameraInVirtualGroup.Name = "simpleButton1AddCameraInVirtualGroup";
            this.simpleButton1AddCameraInVirtualGroup.Size = new System.Drawing.Size(78, 26);
            this.simpleButton1AddCameraInVirtualGroup.TabIndex = 2;
            this.simpleButton1AddCameraInVirtualGroup.Text = "添加";
            this.simpleButton1AddCameraInVirtualGroup.Click += new System.EventHandler(this.simpleButton1AddCameraInVirtualGroup_Click);
            // 
            // labelControlselec
            // 
            this.labelControlselec.Location = new System.Drawing.Point(22, 12);
            this.labelControlselec.Name = "labelControlselec";
            this.labelControlselec.Size = new System.Drawing.Size(84, 14);
            this.labelControlselec.TabIndex = 1;
            this.labelControlselec.Text = "请选择摄像头：";
            // 
            // AddCameraInVirtualGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 387);
            this.Controls.Add(this.panelControl1);
            this.Name = "AddCameraInVirtualGroup";
            this.Text = "添加摄像头";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1CameraInVirtualGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraTreeList.TreeList treeList1CameraInVirtualGroup;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancelInVG;
        private DevExpress.XtraEditors.SimpleButton simpleButton1AddCameraInVirtualGroup;
        private DevExpress.XtraEditors.LabelControl labelControlselec;
    }
}