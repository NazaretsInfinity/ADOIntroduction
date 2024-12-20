namespace Academy
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageStudents = new System.Windows.Forms.TabPage();
            this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
            this.statusStripGroups = new System.Windows.Forms.StatusStrip();
            this.tslStudentsLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPageGroups = new System.Windows.Forms.TabPage();
            this.dataGridViewGroups = new System.Windows.Forms.DataGridView();
            this.StatusStripStudents = new System.Windows.Forms.StatusStrip();
            this.tslGroupCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbGroupsDirection = new System.Windows.Forms.ComboBox();
            this.lbGroupsDirection = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPageStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
            this.statusStripGroups.SuspendLayout();
            this.tabPageGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroups)).BeginInit();
            this.StatusStripStudents.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageStudents);
            this.tabControl.Controls.Add(this.tabPageGroups);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(836, 547);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageStudents
            // 
            this.tabPageStudents.Controls.Add(this.dataGridViewStudents);
            this.tabPageStudents.Controls.Add(this.statusStripGroups);
            this.tabPageStudents.Location = new System.Drawing.Point(4, 25);
            this.tabPageStudents.Name = "tabPageStudents";
            this.tabPageStudents.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStudents.Size = new System.Drawing.Size(828, 518);
            this.tabPageStudents.TabIndex = 0;
            this.tabPageStudents.Text = "Students";
            this.tabPageStudents.UseVisualStyleBackColor = true;
            // 
            // dataGridViewStudents
            // 
            this.dataGridViewStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudents.Location = new System.Drawing.Point(3, 47);
            this.dataGridViewStudents.Name = "dataGridViewStudents";
            this.dataGridViewStudents.RowHeadersWidth = 51;
            this.dataGridViewStudents.RowTemplate.Height = 24;
            this.dataGridViewStudents.Size = new System.Drawing.Size(825, 438);
            this.dataGridViewStudents.TabIndex = 1;
            // 
            // statusStripGroups
            // 
            this.statusStripGroups.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslStudentsLabelCount});
            this.statusStripGroups.Location = new System.Drawing.Point(3, 488);
            this.statusStripGroups.Name = "statusStripGroups";
            this.statusStripGroups.Size = new System.Drawing.Size(822, 27);
            this.statusStripGroups.TabIndex = 0;
            this.statusStripGroups.Text = "statusStrip1";
            // 
            // tslStudentsLabelCount
            // 
            this.tslStudentsLabelCount.Name = "tslStudentsLabelCount";
            this.tslStudentsLabelCount.Size = new System.Drawing.Size(172, 21);
            this.tslStudentsLabelCount.Text = "Количество Студентов";
            // 
            // tabPageGroups
            // 
            this.tabPageGroups.BackColor = System.Drawing.Color.Transparent;
            this.tabPageGroups.Controls.Add(this.lbGroupsDirection);
            this.tabPageGroups.Controls.Add(this.cbGroupsDirection);
            this.tabPageGroups.Controls.Add(this.dataGridViewGroups);
            this.tabPageGroups.Controls.Add(this.StatusStripStudents);
            this.tabPageGroups.Location = new System.Drawing.Point(4, 25);
            this.tabPageGroups.Name = "tabPageGroups";
            this.tabPageGroups.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGroups.Size = new System.Drawing.Size(828, 518);
            this.tabPageGroups.TabIndex = 1;
            this.tabPageGroups.Text = "Groups";
            // 
            // dataGridViewGroups
            // 
            this.dataGridViewGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewGroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewGroups.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGroups.Location = new System.Drawing.Point(3, 46);
            this.dataGridViewGroups.Name = "dataGridViewGroups";
            this.dataGridViewGroups.RowHeadersWidth = 51;
            this.dataGridViewGroups.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewGroups.RowTemplate.Height = 24;
            this.dataGridViewGroups.Size = new System.Drawing.Size(822, 439);
            this.dataGridViewGroups.TabIndex = 2;
            // 
            // StatusStripStudents
            // 
            this.StatusStripStudents.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStripStudents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslGroupCount});
            this.StatusStripStudents.Location = new System.Drawing.Point(3, 488);
            this.StatusStripStudents.Name = "StatusStripStudents";
            this.StatusStripStudents.Size = new System.Drawing.Size(822, 27);
            this.StatusStripStudents.TabIndex = 0;
            this.StatusStripStudents.Text = "statusStrip1";
            // 
            // tslGroupCount
            // 
            this.tslGroupCount.Name = "tslGroupCount";
            this.tslGroupCount.Size = new System.Drawing.Size(140, 21);
            this.tslGroupCount.Text = "Количество Групп";
            // 
            // cbGroupsDirection
            // 
            this.cbGroupsDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGroupsDirection.Location = new System.Drawing.Point(317, 6);
            this.cbGroupsDirection.Name = "cbGroupsDirection";
            this.cbGroupsDirection.Size = new System.Drawing.Size(258, 24);
            this.cbGroupsDirection.TabIndex = 3;
            // 
            // lbGroupsDirection
            // 
            this.lbGroupsDirection.AutoSize = true;
            this.lbGroupsDirection.Location = new System.Drawing.Point(251, 9);
            this.lbGroupsDirection.Name = "lbGroupsDirection";
            this.lbGroupsDirection.Size = new System.Drawing.Size(60, 16);
            this.lbGroupsDirection.TabIndex = 4;
            this.lbGroupsDirection.Text = "Direction";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 547);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Academy";
            this.tabControl.ResumeLayout(false);
            this.tabPageStudents.ResumeLayout(false);
            this.tabPageStudents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
            this.statusStripGroups.ResumeLayout(false);
            this.statusStripGroups.PerformLayout();
            this.tabPageGroups.ResumeLayout(false);
            this.tabPageGroups.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroups)).EndInit();
            this.StatusStripStudents.ResumeLayout(false);
            this.StatusStripStudents.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageStudents;
        private System.Windows.Forms.TabPage tabPageGroups;
        private System.Windows.Forms.StatusStrip statusStripGroups;
        private System.Windows.Forms.ToolStripStatusLabel tslStudentsLabelCount;
        private System.Windows.Forms.StatusStrip StatusStripStudents;
        private System.Windows.Forms.ToolStripStatusLabel tslGroupCount;
        private System.Windows.Forms.DataGridView dataGridViewStudents;
        private System.Windows.Forms.DataGridView dataGridViewGroups;
        private System.Windows.Forms.Label lbGroupsDirection;
        private System.Windows.Forms.ComboBox cbGroupsDirection;
    }
}

