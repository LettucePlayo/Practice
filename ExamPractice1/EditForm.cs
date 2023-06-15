using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamPractice1
{
    public partial class EditForm : Form
    {
        public Doctor doctor;
        public EditForm(Doctor doctor1)
        {
            this.doctor = doctor1;

            InitializeComponent();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = doctor.id.ToString();
            textBox2.Text = doctor.name;
            dateTimePicker1.Value = doctor.birthDate;
            textBox3.Text = doctor.wage.ToString();
            textBox4.Text = doctor.IdSpecialty.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            doctor.name = textBox2.Text;
            doctor.id = int.Parse(textBox1.Text);
            doctor.wage = int.Parse(textBox3.Text);
            doctor.IdSpecialty = int.Parse(textBox4.Text);
            doctor.birthDate = dateTimePicker1.Value;
        }
    }
}
