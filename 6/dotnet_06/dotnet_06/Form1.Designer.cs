namespace dotnet_06
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cid = new System.Windows.Forms.RadioButton();
            this.sname = new System.Windows.Forms.RadioButton();
            this.id = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.find = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.StudentsDataGrid = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.学生ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.班级ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentsDataGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(539, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 454);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F);
            this.label2.Location = new System.Drawing.Point(29, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "查询学生";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.find);
            this.panel1.Location = new System.Drawing.Point(0, 56);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 398);
            this.panel1.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel5.Controls.Add(this.cid);
            this.panel5.Controls.Add(this.sname);
            this.panel5.Controls.Add(this.id);
            this.panel5.Location = new System.Drawing.Point(0, 49);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(150, 108);
            this.panel5.TabIndex = 2;
            // 
            // cid
            // 
            this.cid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cid.AutoSize = true;
            this.cid.Location = new System.Drawing.Point(8, 68);
            this.cid.Margin = new System.Windows.Forms.Padding(10, 5, 3, 5);
            this.cid.Name = "cid";
            this.cid.Size = new System.Drawing.Size(59, 16);
            this.cid.TabIndex = 2;
            this.cid.TabStop = true;
            this.cid.Text = "按班级";
            this.cid.UseVisualStyleBackColor = true;
            // 
            // sname
            // 
            this.sname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sname.AutoSize = true;
            this.sname.Location = new System.Drawing.Point(8, 42);
            this.sname.Margin = new System.Windows.Forms.Padding(10, 5, 3, 5);
            this.sname.Name = "sname";
            this.sname.Size = new System.Drawing.Size(59, 16);
            this.sname.TabIndex = 1;
            this.sname.TabStop = true;
            this.sname.Text = "按姓名";
            this.sname.UseVisualStyleBackColor = true;
            // 
            // id
            // 
            this.id.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.id.AutoSize = true;
            this.id.Location = new System.Drawing.Point(8, 16);
            this.id.Margin = new System.Windows.Forms.Padding(10, 5, 3, 5);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(59, 16);
            this.id.TabIndex = 0;
            this.id.TabStop = true;
            this.id.Text = "按学号";
            this.id.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(83, 178);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 22);
            this.button1.TabIndex = 1;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Search_button_click);
            // 
            // find
            // 
            this.find.Dock = System.Windows.Forms.DockStyle.Top;
            this.find.Location = new System.Drawing.Point(0, 0);
            this.find.Margin = new System.Windows.Forms.Padding(2);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(150, 21);
            this.find.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.StudentsDataGrid);
            this.panel3.Controls.Add(this.menuStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(539, 454);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(539, 232);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(150, 222);
            this.panel4.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(456, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 8, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "双击进行编辑";
            // 
            // StudentsDataGrid
            // 
            this.StudentsDataGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.StudentsDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StudentsDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.StudentsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentsDataGrid.Location = new System.Drawing.Point(9, 56);
            this.StudentsDataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.StudentsDataGrid.Name = "StudentsDataGrid";
            this.StudentsDataGrid.RowHeadersWidth = 51;
            this.StudentsDataGrid.RowTemplate.Height = 27;
            this.StudentsDataGrid.Size = new System.Drawing.Size(520, 388);
            this.StudentsDataGrid.TabIndex = 1;
            this.StudentsDataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EditStudentInfo);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新ToolStripMenuItem,
            this.添加ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(539, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.RefreshTable);
            // 
            // 添加ToolStripMenuItem
            // 
            this.添加ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.学生ToolStripMenuItem,
            this.班级ToolStripMenuItem});
            this.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            this.添加ToolStripMenuItem.Size = new System.Drawing.Size(53, 21);
            this.添加ToolStripMenuItem.Text = "添加...";
            // 
            // 学生ToolStripMenuItem
            // 
            this.学生ToolStripMenuItem.Name = "学生ToolStripMenuItem";
            this.学生ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.学生ToolStripMenuItem.Text = "学生";
            this.学生ToolStripMenuItem.Click += new System.EventHandler(this.AddStudents);
            // 
            // 班级ToolStripMenuItem
            // 
            this.班级ToolStripMenuItem.Name = "班级ToolStripMenuItem";
            this.班级ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.班级ToolStripMenuItem.Text = "班级";
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.DeleteSelected);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 454);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "学生管理系统";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentsDataGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView StudentsDataGrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox find;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton cid;
        private System.Windows.Forms.RadioButton sname;
        private System.Windows.Forms.RadioButton id;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 学生ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 班级ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
    }
}

