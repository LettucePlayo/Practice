namespace PregatireExamen
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
            this.btnAddDoctor = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.birthDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.wage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.specialtyId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthDate2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wage2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdSpec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddDoctor
            // 
            this.btnAddDoctor.Location = new System.Drawing.Point(29, 112);
            this.btnAddDoctor.Name = "btnAddDoctor";
            this.btnAddDoctor.Size = new System.Drawing.Size(111, 23);
            this.btnAddDoctor.TabIndex = 0;
            this.btnAddDoctor.Text = "Add doctor";
            this.btnAddDoctor.UseVisualStyleBackColor = true;
            this.btnAddDoctor.Click += new System.EventHandler(this.btnAddDoctor_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.name,
            this.birthDate,
            this.wage,
            this.specialtyId});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(29, 244);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(315, 159);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // id
            // 
            this.id.Text = "Id";
            // 
            // name
            // 
            this.name.Text = "Name";
            // 
            // birthDate
            // 
            this.birthDate.Text = "Birth Date";
            // 
            // wage
            // 
            this.wage.Text = "Wage";
            // 
            // specialtyId
            // 
            this.specialtyId.Text = "Specialty Id";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(29, 192);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(197, 192);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id2,
            this.Name2,
            this.BirthDate2,
            this.Wage2,
            this.IdSpec});
            this.dataGridView1.Location = new System.Drawing.Point(359, 244);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseDoubleClick);
            // 
            // Id2
            // 
            this.Id2.HeaderText = "Id";
            this.Id2.MinimumWidth = 6;
            this.Id2.Name = "Id2";
            this.Id2.Width = 125;
            // 
            // Name2
            // 
            this.Name2.HeaderText = "Name";
            this.Name2.MinimumWidth = 6;
            this.Name2.Name = "Name2";
            this.Name2.Width = 125;
            // 
            // BirthDate2
            // 
            this.BirthDate2.HeaderText = "Birth Date";
            this.BirthDate2.MinimumWidth = 6;
            this.BirthDate2.Name = "BirthDate2";
            this.BirthDate2.Width = 125;
            // 
            // Wage2
            // 
            this.Wage2.HeaderText = "Column1Wage";
            this.Wage2.MinimumWidth = 6;
            this.Wage2.Name = "Wage2";
            this.Wage2.Width = 125;
            // 
            // IdSpec
            // 
            this.IdSpec.HeaderText = "Id Spec";
            this.IdSpec.MinimumWidth = 6;
            this.IdSpec.Name = "IdSpec";
            this.IdSpec.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnAddDoctor);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddDoctor;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader birthDate;
        private System.Windows.Forms.ColumnHeader wage;
        private System.Windows.Forms.ColumnHeader specialtyId;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name2;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthDate2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdSpec;
    }
}

