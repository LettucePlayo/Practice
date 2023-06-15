using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAW_EXAM_LISTVIEW_checkedListBox_listbox
{
    public partial class AddDoctor : Form
    {
        public Form1 form1;
        List<String> specialty;
        public AddDoctor(Form1 form)
        {
            form1 = form;
            specialty = new List<String>();
            InitializeComponent();
        }

        private void Id_Click(object sender, EventArgs e)
        {

        }

        private void btn_save_doctor_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(tb_id.Text);
                string name = tb_name.Text;
                DateTime birth = dateTimePicker1.Value;
                float wage = float.Parse(tb_wage.Text);

                int idSpecialty = specialty.IndexOf(tb_Specialty.Text);

                Doctor doctor = new Doctor(id, name, birth, wage, idSpecialty);
                Console.WriteLine("Doctor: " + doctor.id + doctor.name + doctor.birth + doctor.idSpecialty);
                form1.doctors.Add(doctor);

                form1.displayDoctors();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }


        }

        private void AddDoctor_Load(object sender, EventArgs e)
        {
            string[] lines = System.IO.File.ReadAllLines("Specialty.txt");
            foreach( string line in lines)
            {
                specialty.Add(line);
                listBox1.Items.Add(line);
            }
        }

        private void tb_id_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tb_id, null);
        }

        private void tb_id_Validating(object sender, CancelEventArgs e)
        {
            if( int.Parse(tb_id.Text) <0  )
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Id e prea mic");
            }
        }

        private void tb_name_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tb_name, null);
        }

        private void tb_name_Validating(object sender, CancelEventArgs e)
        {
            if ((tb_name.Text.Length) < 3)
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Nume prea mic");
            }
        }

        private void tb_wage_Validating(object sender, CancelEventArgs e)
        {
            if (float.Parse(tb_wage.Text) < 0)
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Wage e prea mic");
            }
        }

        private void tb_wage_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tb_wage, null);
        }

        private void dateTimePicker1_Validating(object sender, CancelEventArgs e)
        {
            if ( ((DateTime.Now - dateTimePicker1.Value).TotalDays / 365) <25  ||
                 ((DateTime.Now - dateTimePicker1.Value).TotalDays / 365) > 70 )
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Date e prea mic");
            }
        }

        private void dateTimePicker1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(dateTimePicker1, null);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            tb_Specialty.Text = specialty.ElementAt(index);
        }
    }
}
