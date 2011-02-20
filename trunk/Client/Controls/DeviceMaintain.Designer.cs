namespace CameraViewer.Controls
{
    partial class DeviceMaintain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceMaintain));
            this.treeList2 = new DevExpress.XtraTreeList.TreeList();
            this.colCameraId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colConnURL = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAddressID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colChannelNo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colOupputpath = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsDetectMotion = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsValid = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colKey = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.treeList2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList2
            // 
            this.treeList2.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colCameraId,
            this.colName,
            this.colDescription,
            this.colConnURL,
            this.colAddressID,
            this.colChannelNo,
            this.colOupputpath,
            this.colIsDetectMotion,
            this.colIsValid});
            this.treeList2.CustomizationFormBounds = new System.Drawing.Rectangle(172, 226, 208, 170);
            this.treeList2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList2.Location = new System.Drawing.Point(159, 0);
            this.treeList2.Name = "treeList2";
            this.treeList2.OptionsBehavior.AutoChangeParent = false;
            this.treeList2.OptionsBehavior.AutoNodeHeight = false;
            this.treeList2.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treeList2.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treeList2.OptionsBehavior.Editable = false;
            this.treeList2.OptionsBehavior.KeepSelectedOnClick = false;
            this.treeList2.OptionsBehavior.ResizeNodes = false;
            this.treeList2.OptionsBehavior.SmartMouseHover = false;
            this.treeList2.OptionsMenu.EnableFooterMenu = false;
            this.treeList2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeList2.OptionsView.AutoCalcPreviewLineCount = true;
            this.treeList2.OptionsView.ShowFocusedFrame = false;
            this.treeList2.OptionsView.ShowIndentAsRowStyle = true;
            this.treeList2.OptionsView.ShowIndicator = false;
            this.treeList2.OptionsView.ShowRoot = false;
            this.treeList2.Size = new System.Drawing.Size(686, 498);
            this.treeList2.TabIndex = 3;
            // 
            // colCameraId
            // 
            this.colCameraId.Caption = "Type";
            this.colCameraId.FieldName = "CameraId";
            this.colCameraId.Name = "colCameraId";
            // 
            // colName
            // 
            this.colName.Caption = "名称";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 27;
            this.colName.Name = "colName";
            this.colName.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Count;
            this.colName.SummaryFooterStrFormat = "Count Values = {0}";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 81;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "描述";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.OptionsColumn.AllowSort = false;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 85;
            // 
            // colConnURL
            // 
            this.colConnURL.Caption = "云台控制端口";
            this.colConnURL.FieldName = "ConnURL";
            this.colConnURL.Name = "colConnURL";
            this.colConnURL.Visible = true;
            this.colConnURL.VisibleIndex = 2;
            this.colConnURL.Width = 87;
            // 
            // colAddressID
            // 
            this.colAddressID.Caption = "云台地址";
            this.colAddressID.FieldName = "AddressID";
            this.colAddressID.Name = "colAddressID";
            this.colAddressID.Visible = true;
            this.colAddressID.VisibleIndex = 3;
            this.colAddressID.Width = 76;
            // 
            // colChannelNo
            // 
            this.colChannelNo.Caption = "视频输入通道号";
            this.colChannelNo.FieldName = "ChannelNo";
            this.colChannelNo.Name = "colChannelNo";
            this.colChannelNo.Visible = true;
            this.colChannelNo.VisibleIndex = 4;
            this.colChannelNo.Width = 94;
            // 
            // colOupputpath
            // 
            this.colOupputpath.Caption = "录像存放路径";
            this.colOupputpath.FieldName = "Oupputpath";
            this.colOupputpath.Name = "colOupputpath";
            this.colOupputpath.Visible = true;
            this.colOupputpath.VisibleIndex = 5;
            this.colOupputpath.Width = 85;
            // 
            // colIsDetectMotion
            // 
            this.colIsDetectMotion.Caption = "是否入侵检测";
            this.colIsDetectMotion.FieldName = "IsDetectMotion";
            this.colIsDetectMotion.Name = "colIsDetectMotion";
            this.colIsDetectMotion.Visible = true;
            this.colIsDetectMotion.VisibleIndex = 6;
            this.colIsDetectMotion.Width = 84;
            // 
            // colIsValid
            // 
            this.colIsValid.Caption = "是否有效";
            this.colIsValid.FieldName = "IsValid";
            this.colIsValid.Name = "colIsValid";
            this.colIsValid.Visible = true;
            this.colIsValid.VisibleIndex = 7;
            this.colIsValid.Width = 90;
            // 
            // treeList1
            // 
            this.treeList1.Appearance.Empty.BackColor = System.Drawing.Color.Ivory;
            this.treeList1.Appearance.Empty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treeList1.Appearance.Empty.Options.UseBackColor = true;
            this.treeList1.Appearance.Empty.Options.UseForeColor = true;
            this.treeList1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(245)))), ((int)(((byte)(230)))));
            this.treeList1.Appearance.EvenRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treeList1.Appearance.EvenRow.Options.UseBackColor = true;
            this.treeList1.Appearance.EvenRow.Options.UseForeColor = true;
            this.treeList1.Appearance.FooterPanel.BackColor = System.Drawing.Color.NavajoWhite;
            this.treeList1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.NavajoWhite;
            this.treeList1.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.treeList1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treeList1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treeList1.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.treeList1.Appearance.FooterPanel.Options.UseFont = true;
            this.treeList1.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treeList1.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.treeList1.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.treeList1.Appearance.GroupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treeList1.Appearance.GroupButton.Options.UseBackColor = true;
            this.treeList1.Appearance.GroupButton.Options.UseBorderColor = true;
            this.treeList1.Appearance.GroupButton.Options.UseForeColor = true;
            this.treeList1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(194)))), ((int)(((byte)(145)))));
            this.treeList1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(194)))), ((int)(((byte)(145)))));
            this.treeList1.Appearance.GroupFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treeList1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treeList1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.treeList1.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treeList1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.BurlyWood;
            this.treeList1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.BurlyWood;
            this.treeList1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.treeList1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treeList1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treeList1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.treeList1.Appearance.HeaderPanel.Options.UseFont = true;
            this.treeList1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treeList1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.treeList1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.treeList1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treeList1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treeList1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.treeList1.Appearance.HorzLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.treeList1.Appearance.HorzLine.Options.UseBackColor = true;
            this.treeList1.Appearance.HorzLine.Options.UseForeColor = true;
            this.treeList1.Appearance.OddRow.BackColor = System.Drawing.Color.Bisque;
            this.treeList1.Appearance.OddRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treeList1.Appearance.OddRow.Options.UseBackColor = true;
            this.treeList1.Appearance.OddRow.Options.UseForeColor = true;
            this.treeList1.Appearance.Preview.BackColor = System.Drawing.Color.Cornsilk;
            this.treeList1.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.treeList1.Appearance.Preview.Options.UseBackColor = true;
            this.treeList1.Appearance.Preview.Options.UseForeColor = true;
            this.treeList1.Appearance.Preview.Options.UseTextOptions = true;
            this.treeList1.Appearance.Preview.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.treeList1.Appearance.Row.BackColor = System.Drawing.Color.Ivory;
            this.treeList1.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(112)))));
            this.treeList1.Appearance.Row.Options.UseBackColor = true;
            this.treeList1.Appearance.Row.Options.UseForeColor = true;
            this.treeList1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(138)))));
            this.treeList1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treeList1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treeList1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treeList1.Appearance.TreeLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.treeList1.Appearance.TreeLine.Options.UseForeColor = true;
            this.treeList1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.treeList1.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.treeList1.Appearance.VertLine.Options.UseBackColor = true;
            this.treeList1.Appearance.VertLine.Options.UseForeColor = true;
            this.treeList1.Appearance.VertLine.Options.UseTextOptions = true;
            this.treeList1.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treeList1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("treeList1.BackgroundImage")));
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colKey});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.AutoChangeParent = false;
            this.treeList1.OptionsBehavior.AutoNodeHeight = false;
            this.treeList1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treeList1.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsBehavior.KeepSelectedOnClick = false;
            this.treeList1.OptionsBehavior.ResizeNodes = false;
            this.treeList1.OptionsBehavior.SmartMouseHover = false;
            this.treeList1.OptionsMenu.EnableFooterMenu = false;
            this.treeList1.OptionsPrint.PrintHorzLines = false;
            this.treeList1.OptionsPrint.PrintVertLines = false;
            this.treeList1.OptionsPrint.UsePrintStyles = true;
            this.treeList1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeList1.OptionsView.ShowFocusedFrame = false;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.Size = new System.Drawing.Size(159, 498);
            this.treeList1.TabIndex = 2;
            // 
            // colKey
            // 
            this.colKey.AllNodesSummary = true;
            this.colKey.Caption = "设备";
            this.colKey.FieldName = "Key";
            this.colKey.MinWidth = 27;
            this.colKey.Name = "colKey";
            this.colKey.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Count;
            this.colKey.SummaryFooterStrFormat = "Count keys = {0}";
            this.colKey.Visible = true;
            this.colKey.VisibleIndex = 0;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "名称";
            this.treeListColumn1.FieldName = "Name";
            this.treeListColumn1.MinWidth = 27;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Count;
            this.treeListColumn1.SummaryFooterStrFormat = "Count Values = {0}";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 85;
            // 
            // popupMenu1
            // 
            this.popupMenu1.Name = "popupMenu1";
            // 
            // DeviceMaintain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeList2);
            this.Controls.Add(this.treeList1);
            this.Name = "DeviceMaintain";
            this.Size = new System.Drawing.Size(845, 498);
            ((System.ComponentModel.ISupportInitialize)(this.treeList2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCameraId;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colKey;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colConnURL;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAddressID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colChannelNo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colOupputpath;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsDetectMotion;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsValid;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
    }
}
