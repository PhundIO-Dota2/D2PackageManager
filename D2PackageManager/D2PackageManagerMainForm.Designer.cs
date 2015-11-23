namespace D2PackageManager {
    partial class D2PackageManagerMainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.addonsListBox = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelSelectedAddonName = new System.Windows.Forms.Label();
            this.panelLibrariesAddedPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.deleteAddonButton = new System.Windows.Forms.Button();
            this.listBoxCurrentAddonLibraries = new System.Windows.Forms.CheckedListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newAddonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelLibrariesAddedPanel.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.23853F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.76147F));
            this.tableLayoutPanel1.Controls.Add(this.addonsListBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(580, 357);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // addonsListBox
            // 
            this.addonsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addonsListBox.FormattingEnabled = true;
            this.addonsListBox.Location = new System.Drawing.Point(3, 3);
            this.addonsListBox.Name = "addonsListBox";
            this.addonsListBox.Size = new System.Drawing.Size(146, 331);
            this.addonsListBox.TabIndex = 0;
            this.addonsListBox.SelectedIndexChanged += new System.EventHandler(this.UpdateSelectedAddon);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.labelSelectedAddonName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panelLibrariesAddedPanel, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(155, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.97151F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.02849F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(422, 331);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // labelSelectedAddonName
            // 
            this.labelSelectedAddonName.AutoSize = true;
            this.labelSelectedAddonName.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelSelectedAddonName.Location = new System.Drawing.Point(3, 0);
            this.labelSelectedAddonName.Name = "labelSelectedAddonName";
            this.labelSelectedAddonName.Size = new System.Drawing.Size(0, 33);
            this.labelSelectedAddonName.TabIndex = 0;
            // 
            // panelLibrariesAddedPanel
            // 
            this.panelLibrariesAddedPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelLibrariesAddedPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLibrariesAddedPanel.Controls.Add(this.tableLayoutPanel3);
            this.panelLibrariesAddedPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLibrariesAddedPanel.Location = new System.Drawing.Point(3, 36);
            this.panelLibrariesAddedPanel.Name = "panelLibrariesAddedPanel";
            this.panelLibrariesAddedPanel.Size = new System.Drawing.Size(416, 292);
            this.panelLibrariesAddedPanel.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.05314F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.94686F));
            this.tableLayoutPanel3.Controls.Add(this.deleteAddonButton, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.listBoxCurrentAddonLibraries, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(414, 290);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // deleteAddonButton
            // 
            this.deleteAddonButton.ForeColor = System.Drawing.Color.Red;
            this.deleteAddonButton.Location = new System.Drawing.Point(321, 3);
            this.deleteAddonButton.Name = "deleteAddonButton";
            this.deleteAddonButton.Size = new System.Drawing.Size(88, 23);
            this.deleteAddonButton.TabIndex = 0;
            this.deleteAddonButton.Text = "Delete Addon";
            this.deleteAddonButton.UseVisualStyleBackColor = true;
            this.deleteAddonButton.Click += new System.EventHandler(this.deleteAddonButton_Click);
            // 
            // listBoxCurrentAddonLibraries
            // 
            this.listBoxCurrentAddonLibraries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxCurrentAddonLibraries.FormattingEnabled = true;
            this.listBoxCurrentAddonLibraries.Location = new System.Drawing.Point(3, 3);
            this.listBoxCurrentAddonLibraries.Name = "listBoxCurrentAddonLibraries";
            this.listBoxCurrentAddonLibraries.Size = new System.Drawing.Size(312, 284);
            this.listBoxCurrentAddonLibraries.TabIndex = 1;
            this.listBoxCurrentAddonLibraries.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listBoxCurrentAddonLibraries_ItemCheck);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 337);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(152, 20);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newAddonToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 16);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newAddonToolStripMenuItem
            // 
            this.newAddonToolStripMenuItem.Name = "newAddonToolStripMenuItem";
            this.newAddonToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.newAddonToolStripMenuItem.Text = "New Addon";
            this.newAddonToolStripMenuItem.Click += new System.EventHandler(this.NewAddonClick);
            // 
            // D2PackageManagerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(580, 357);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 400);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "D2PackageManagerMainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Dota 2 Package Manager";
            this.Load += new System.EventHandler(this.OnLoad);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panelLibrariesAddedPanel.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox addonsListBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelSelectedAddonName;
        private System.Windows.Forms.Panel panelLibrariesAddedPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newAddonToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button deleteAddonButton;
        private System.Windows.Forms.CheckedListBox listBoxCurrentAddonLibraries;
    }
}

