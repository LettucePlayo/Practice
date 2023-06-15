
namespace PAW_EXAM_LISTVIEW_checkedListBox_listbox
{
    partial class AddDoctor
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Id = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tb_wage = new System.Windows.Forms.TextBox();
            this.tb_Specialty = new System.Windows.Forms.TextBox();
            this.btn_save_doctor = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(433, 52);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(117, 68);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Id
            // 
            this.Id.AutoSize = true;
            this.Id.Location = new System.Drawing.Point(42, 61);
            this.Id.Name = "Id";
            this.Id.Size = new System.Drawing.Size(19, 17);
            this.Id.TabIndex = 1;
            this.Id.Text = "Id";
            this.Id.Click += new System.EventHandler(this.Id_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Birth";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Wage";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 317);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 17);
            this.label5.TabIndex = 5;
            // 
            // tb_id
            // 
            this.tb_id.Location = new System.Drawing.Point(136, 61);
            this.tb_id.Name = "tb_id";
            this.tb_id.Size = new System.Drawing.Size(103, 22);
            this.tb_id.TabIndex = 6;
            this.tb_id.Validating += new System.ComponentModel.CancelEventHandler(this.tb_id_Validating);
            this.tb_id.Validated += new System.EventHandler(this.tb_id_Validated);
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(136, 123);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(103, 22);
            this.tb_name.TabIndex = 7;
            this.tb_name.Validating += new System.ComponentModel.CancelEventHandler(this.tb_name_Validating);
            this.tb_name.Validated += new System.EventHandler(this.tb_name_Validated);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(136, 201);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(258, 22);
            this.dateTimePicker1.TabIndex = 8;
            this.dateTimePicker1.Validating += new System.ComponentModel.CancelEventHandler(this.dateTimePicker1_Validating);
            this.dateTimePicker1.Validated += new System.EventHandler(this.dateTimePicker1_Validated);
            // 
            // tb_wage
            // 
            this.tb_wage.Location = new System.Drawing.Point(135, 257);
            this.tb_wage.Name = "tb_wage";
            this.tb_wage.Size = new System.Drawing.Size(104, 22);
            this.tb_wage.TabIndex = 9;
            this.tb_wage.Validating += new System.ComponentModel.CancelEventHandler(this.tb_wage_Validating);
            this.tb_wage.Validated += new System.EventHandler(this.tb_wage_Validated);
            // 
            // tb_Specialty
            // 
            this.tb_Specialty.Location = new System.Drawing.Point(433, 161);
            this.tb_Specialty.Name = "tb_Specialty";
            this.tb_Specialty.Size = new System.Drawing.Size(117, 22);
            this.tb_Specialty.TabIndex = 10;
            // 
            // btn_save_doctor
            // 
            this.btn_save_doctor.Location = new System.Drawing.Point(228, 349);
            this.btn_save_doctor.Name = "btn_save_doctor";
            this.btn_save_doctor.Size = new System.Drawing.Size(115, 29);
            this.btn_save_doctor.TabIndex = 11;
            this.btn_save_doctor.Text = "Save doctor";
            this.btn_save_doctor.UseVisualStyleBackColor = true;
            this.btn_save_doctor.Click += new System.EventHandler(this.btn_save_doctor_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_save_doctor);
            this.Controls.Add(this.tb_Specialty);
            this.Controls.Add(this.tb_wage);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Id);
            this.Controls.Add(this.listBox1);
            this.Name = "AddDoctor";
            this.Text = "AddDoctor";
            this.Load += new System.EventHandler(this.AddDoctor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label Id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox tb_wage;
        private System.Windows.Forms.TextBox tb_Specialty;
        private System.Windows.Forms.Button btn_save_doctor;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}