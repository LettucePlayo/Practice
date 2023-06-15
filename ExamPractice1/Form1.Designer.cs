
namespace ExamPractice1
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.lvDoctor = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.xMLSerliazeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLSerializeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLDeserializeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(379, 46);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 75);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add Doctor";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lvDoctor
            // 
            this.lvDoctor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvDoctor.FullRowSelect = true;
            this.lvDoctor.GridLines = true;
            this.lvDoctor.HideSelection = false;
            this.lvDoctor.Location = new System.Drawing.Point(56, 208);
            this.lvDoctor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvDoctor.Name = "lvDoctor";
            this.lvDoctor.Size = new System.Drawing.Size(830, 339);
            this.lvDoctor.TabIndex = 1;
            this.lvDoctor.UseCompatibleStateImageBehavior = false;
            this.lvDoctor.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 74;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(706, 46);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 75);
            this.button2.TabIndex = 2;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(520, 46);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 75);
            this.button3.TabIndex = 2;
            this.button3.Text = "Edit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xMLSerliazeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(900, 33);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // xMLSerliazeToolStripMenuItem
            // 
            this.xMLSerliazeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xMLSerializeToolStripMenuItem,
            this.xMLDeserializeToolStripMenuItem});
            this.xMLSerliazeToolStripMenuItem.Name = "xMLSerliazeToolStripMenuItem";
            this.xMLSerliazeToolStripMenuItem.Size = new System.Drawing.Size(63, 29);
            this.xMLSerliazeToolStripMenuItem.Text = "XML";
            // 
            // xMLSerializeToolStripMenuItem
            // 
            this.xMLSerializeToolStripMenuItem.Name = "xMLSerializeToolStripMenuItem";
            this.xMLSerializeToolStripMenuItem.Size = new System.Drawing.Size(235, 34);
            this.xMLSerializeToolStripMenuItem.Text = "XML serialize";
            this.xMLSerializeToolStripMenuItem.Click += new System.EventHandler(this.xMLSerializeToolStripMenuItem_Click);
            // 
            // xMLDeserializeToolStripMenuItem
            // 
            this.xMLDeserializeToolStripMenuItem.Name = "xMLDeserializeToolStripMenuItem";
            this.xMLDeserializeToolStripMenuItem.Size = new System.Drawing.Size(235, 34);
            this.xMLDeserializeToolStripMenuItem.Text = "XML deserialize";
            this.xMLDeserializeToolStripMenuItem.Click += new System.EventHandler(this.xMLDeserializeToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lvDoctor);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView lvDoctor;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xMLSerliazeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xMLSerializeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xMLDeserializeToolStripMenuItem;
    }
}

