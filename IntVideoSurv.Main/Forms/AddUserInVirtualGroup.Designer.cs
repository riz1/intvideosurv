namespace CameraViewer.Forms
{
    partial class AddUserInVirtualGroup
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
            this.treeList1UserInVirtualGroup = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.simpleButtonuserCancelInVG = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1AddUserInVirtualGroup = new DevExpress.XtraEditors.SimpleButton();
            this.labelControlselector = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1UserInVirtualGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.treeList1UserInVirtualGroup);
            this.panelControl1.Controls.Add(this.simpleButtonuserCancelInVG);
            this.panelControl1.Controls.Add(this.simpleButton1AddUserInVirtualGroup);
            this.panelControl1.Controls.Add(this.labelControlselector);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(268, 387);
            this.panelControl1.TabIndex = 2;
            // 
            // treeList1UserInVirtualGroup
            // 
            this.treeList1UserInVirtualGroup.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.treeList1UserInVirtualGroup.Location = new System.Drawing.Point(28, 38);
            this.treeList1UserInVirtualGroup.Name = "treeList1UserInVirtualGroup";
            this.treeList1UserInVirtualGroup.OptionsBehavior.AutoFocusNewNode = true;
            this.treeList1UserInVirtualGroup.OptionsBehavior.Editable = false;
            this.treeList1UserInVirtualGroup.OptionsSelection.InvertSelection = true;
            this.treeList1UserInVirtualGroup.OptionsView.ShowColumns = false;
            this.treeList1UserInVirtualGroup.OptionsView.ShowHorzLines = false;
            this.treeList1UserInVirtualGroup.OptionsView.ShowIndicator = false;
            this.treeList1UserInVirtualGroup.OptionsView.ShowVertLines = false;
            this.treeList1UserInVirtualGroup.Size = new System.Drawing.Size(210, 282);
            this.treeList1UserInVirtualGroup.TabIndex = 4;
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
            // simpleButtonuserCancelInVG
            // 
            this.simpleButtonuserCancelInVG.Location = new System.Drawing.Point(156, 335);
            this.simpleButtonuserCancelInVG.Name = "simpleButtonuserCancelInVG";
            this.simpleButtonuserCancelInVG.Size = new System.Drawing.Size(82, 27);
            this.simpleButtonuserCancelInVG.TabIndex = 3;
            this.simpleButtonuserCancelInVG.Text = "取消";
            this.simpleButtonuserCancelInVG.Click += new System.EventHandler(this.simpleButtonuserCancelInVG_Click);
            // 
            // simpleButton1AddUserInVirtualGroup
            // 
            this.simpleButton1AddUserInVirtualGroup.Location = new System.Drawing.Point(28, 336);
            this.simpleButton1AddUserInVirtualGroup.Name = "simpleButton1AddUserInVirtualGroup";
            this.simpleButton1AddUserInVirtualGroup.Size = new System.Drawing.Size(78, 26);
            this.simpleButton1AddUserInVirtualGroup.TabIndex = 2;
            this.simpleButton1AddUserInVirtualGroup.Text = "添加";
            this.simpleButton1AddUserInVirtualGroup.Click += new System.EventHandler(this.simpleButton1AddUserInVirtualGroup_Click);
            // 
            // labelControlselector
            // 
            this.labelControlselector.Location = new System.Drawing.Point(22, 12);
            this.labelControlselector.Name = "labelControlselector";
            this.labelControlselector.Size = new System.Drawing.Size(72, 14);
            this.labelControlselector.TabIndex = 1;
            this.labelControlselector.Text = "请选择用户：";
            // 
            // AddUserInVirtualGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 387);
            this.Controls.Add(this.panelControl1);
            this.Name = "AddUserInVirtualGroup";
            this.Text = "添加用户";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1UserInVirtualGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraTreeList.TreeList treeList1UserInVirtualGroup;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonuserCancelInVG;
        private DevExpress.XtraEditors.SimpleButton simpleButton1AddUserInVirtualGroup;
        private DevExpress.XtraEditors.LabelControl labelControlselector;
    }
}