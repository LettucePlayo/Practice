using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PregatireExamen
{
    public partial class AddDoctor : Form
    {
        Form1 form1;
        //List<String> specialty;
        public AddDoctor(Form1 form)
        {
            form1 = form;
            form1.specialty = new List<String>();
            InitializeComponent();
        }

        private void AddDoctor_Load(object sender, EventArgs e)
        {
            string[] lines = System.IO.File.ReadAllLines("Specialty.txt");
            foreach(string line in lines)
            {
                form1.specialty.Add(line);
                listBox1.Items.Add(line);
                comboBox1.Items.Add(line);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(tbId.Text);
                string name = tbName.Text;
                DateTime birthDate = dateTimePicker1.Value;
                float wage = float.Parse(tbWage.Text);
                //int idSpeciaty = form1.specialty.IndexOf(tbSpecialty.Text);
                int idSpeciaty = form1.specialty.IndexOf(comboBox1.Text);

                Doctor doctor = new Doctor(id, name, birthDate, wage, idSpeciaty);
                form1.doctors.Add(doctor);
                form1.DisplayDoctors();
                form1.DisplayDataGridView();
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString(),"Nasol");
            }
        }

        private void tbId_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbId, null);
        }

        private void tbId_Validating(object sender, CancelEventArgs e)
        {
            if (int.Parse(tbId.Text) < 0)
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Id e prea mic");
            }
        }

        private void tbName_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbName, null);
        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if (tbName.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Nume e prea mic");
            }
        }

        private void tbWage_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbWage, null);
        }

        private void tbWage_Validating(object sender, CancelEventArgs e)
        {
            if (float.Parse(tbWage.Text) < 0)
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Wage e prea mic");
            }
        }

        private void dateTimePicker1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(dateTimePicker1, null);
        }

        private void dateTimePicker1_Validating(object sender, CancelEventArgs e)
        {
            if(((DateTime.Now - dateTimePicker1.Value).TotalDays / 365)<25 ||
                ((DateTime.Now - dateTimePicker1.Value).TotalDays / 365) > 70)
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Viata e invalida");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            tbSpecialty.Text = form1.specialty.ElementAt(index);
        }
    }
}
