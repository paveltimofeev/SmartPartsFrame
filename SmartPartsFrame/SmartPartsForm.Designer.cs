namespace SmartPartsFrame
{
    public partial class SmartPartsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmartPartsForm));
            this.tsToolBar = new System.Windows.Forms.ToolStrip();
            this.tsDefault = new System.Windows.Forms.ToolStripButton();
            this.tsGrid = new System.Windows.Forms.ToolStripButton();
            this.tsGridDecorator = new System.Windows.Forms.ToolStripButton();
            this.ssStatusBar = new System.Windows.Forms.StatusStrip();
            this.panelFiles = new System.Windows.Forms.Panel();
            this.cmFolder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.creadeNewFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.openFileInExternalBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.createNewFilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.eToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMap = new System.Windows.Forms.ToolStripButton();
            this.tsToolBar.SuspendLayout();
            this.cmFolder.SuspendLayout();
            this.cmFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsToolBar
            // 
            this.tsToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsDefault,
            this.tsGrid,
            this.tsGridDecorator,
            this.tsMap});
            this.tsToolBar.Location = new System.Drawing.Point(0, 0);
            this.tsToolBar.Name = "tsToolBar";
            this.tsToolBar.Size = new System.Drawing.Size(470, 25);
            this.tsToolBar.TabIndex = 0;
            this.tsToolBar.Text = "toolStrip1";
            // 
            // tsDefault
            // 
            this.tsDefault.Image = ((System.Drawing.Image)(resources.GetObject("tsDefault.Image")));
            this.tsDefault.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDefault.Name = "tsDefault";
            this.tsDefault.Size = new System.Drawing.Size(62, 22);
            this.tsDefault.Text = "Default";
            // 
            // tsGrid
            // 
            this.tsGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsGrid.Image = ((System.Drawing.Image)(resources.GetObject("tsGrid.Image")));
            this.tsGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsGrid.Name = "tsGrid";
            this.tsGrid.Size = new System.Drawing.Size(107, 22);
            this.tsGrid.Text = "Extendent Grid Test";
            // 
            // tsGridDecorator
            // 
            this.tsGridDecorator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsGridDecorator.Image = ((System.Drawing.Image)(resources.GetObject("tsGridDecorator.Image")));
            this.tsGridDecorator.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsGridDecorator.Name = "tsGridDecorator";
            this.tsGridDecorator.Size = new System.Drawing.Size(105, 22);
            this.tsGridDecorator.Text = "Grid Decorator Test";
            // 
            // ssStatusBar
            // 
            this.ssStatusBar.Location = new System.Drawing.Point(0, 328);
            this.ssStatusBar.Name = "ssStatusBar";
            this.ssStatusBar.Size = new System.Drawing.Size(470, 22);
            this.ssStatusBar.TabIndex = 1;
            this.ssStatusBar.Text = "statusStrip1";
            // 
            // panelFiles
            // 
            this.panelFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFiles.Location = new System.Drawing.Point(0, 25);
            this.panelFiles.Name = "panelFiles";
            this.panelFiles.Size = new System.Drawing.Size(470, 303);
            this.panelFiles.TabIndex = 0;
            // 
            // cmFolder
            // 
            this.cmFolder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creadeNewFolderToolStripMenuItem,
            this.renameFolderToolStripMenuItem,
            this.toolStripMenuItem1,
            this.deleteFolderToolStripMenuItem});
            this.cmFolder.Name = "cmFolder";
            this.cmFolder.Size = new System.Drawing.Size(185, 76);
            // 
            // creadeNewFolderToolStripMenuItem
            // 
            this.creadeNewFolderToolStripMenuItem.Name = "creadeNewFolderToolStripMenuItem";
            this.creadeNewFolderToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.creadeNewFolderToolStripMenuItem.Text = "Create new folder...";
            // 
            // renameFolderToolStripMenuItem
            // 
            this.renameFolderToolStripMenuItem.Name = "renameFolderToolStripMenuItem";
            this.renameFolderToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.renameFolderToolStripMenuItem.Text = "Rename folder";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 6);
            // 
            // deleteFolderToolStripMenuItem
            // 
            this.deleteFolderToolStripMenuItem.Name = "deleteFolderToolStripMenuItem";
            this.deleteFolderToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.deleteFolderToolStripMenuItem.Text = "Delete folder";
            // 
            // cmFile
            // 
            this.cmFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectFileToolStripMenuItem,
            this.sendFileToolStripMenuItem,
            this.toolStripMenuItem4,
            this.openFileInExternalBrowserToolStripMenuItem,
            this.toolStripMenuItem2,
            this.createNewFilToolStripMenuItem,
            this.toolStripMenuItem3,
            this.eToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmFile.Name = "cmFile";
            this.cmFile.Size = new System.Drawing.Size(240, 154);
            // 
            // selectFileToolStripMenuItem
            // 
            this.selectFileToolStripMenuItem.Name = "selectFileToolStripMenuItem";
            this.selectFileToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.selectFileToolStripMenuItem.Text = "Select file";
            // 
            // sendFileToolStripMenuItem
            // 
            this.sendFileToolStripMenuItem.Name = "sendFileToolStripMenuItem";
            this.sendFileToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.sendFileToolStripMenuItem.Text = "Print";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(236, 6);
            // 
            // openFileInExternalBrowserToolStripMenuItem
            // 
            this.openFileInExternalBrowserToolStripMenuItem.Name = "openFileInExternalBrowserToolStripMenuItem";
            this.openFileInExternalBrowserToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.openFileInExternalBrowserToolStripMenuItem.Text = "Open file in external browser ...";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(236, 6);
            // 
            // createNewFilToolStripMenuItem
            // 
            this.createNewFilToolStripMenuItem.Name = "createNewFilToolStripMenuItem";
            this.createNewFilToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.createNewFilToolStripMenuItem.Text = "Create new file ...";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(236, 6);
            // 
            // eToolStripMenuItem
            // 
            this.eToolStripMenuItem.Name = "eToolStripMenuItem";
            this.eToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.eToolStripMenuItem.Text = "Rename file ...";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.deleteToolStripMenuItem.Text = "Delete file";
            // 
            // tsMap
            // 
            this.tsMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsMap.Image = ((System.Drawing.Image)(resources.GetObject("tsMap.Image")));
            this.tsMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsMap.Name = "tsMap";
            this.tsMap.Size = new System.Drawing.Size(40, 22);
            this.tsMap.Text = "tsMap";
            // 
            // SmartPartsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 350);
            this.Controls.Add(this.panelFiles);
            this.Controls.Add(this.ssStatusBar);
            this.Controls.Add(this.tsToolBar);
            this.Name = "SmartPartsForm";
            this.Text = "SmartPart Framework";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tsToolBar.ResumeLayout(false);
            this.tsToolBar.PerformLayout();
            this.cmFolder.ResumeLayout(false);
            this.cmFile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ssStatusBar;
        private System.Windows.Forms.ToolStrip tsToolBar;
        private System.Windows.Forms.Panel panelFiles;
        private System.Windows.Forms.ContextMenuStrip cmFolder;
        private System.Windows.Forms.ToolStripMenuItem creadeNewFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteFolderToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmFile;
        private System.Windows.Forms.ToolStripMenuItem selectFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileInExternalBrowserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewFilToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem eToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripButton tsDefault;
        private System.Windows.Forms.ToolStripButton tsGrid;
        private System.Windows.Forms.ToolStripButton tsGridDecorator;
        private System.Windows.Forms.ToolStripButton tsMap;
    }
}

