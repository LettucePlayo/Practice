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
    public partial class AddDoctor : Form
    {
        public List<Doctor> doctor;
        public ListBox listBox;
        public AddDoctor(List<Doctor> doctor)
        {
            this.doctor = doctor;
            listBox = new ListBox();
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(tbID.Text);
                string name = tbName.Text;
                DateTime birthDate = dtpBirthDate.Value;
                int wage = int.Parse(tbWage.Text);
                //int spcID = int.Parse(lbSpecialities.GetItemText(lbSpecialities.SelectedItem.ToString()));




                Doctor newDoctor = new Doctor(id, name, birthDate, wage, 10);
                doctor.Add(newDoctor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private void loadTxt()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines("Specialities.txt".Trim());
                foreach(string line in lines)
                {
                    lbSpecialities.Items.Add(line);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }


        private void lbSpecialities_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lbSpecialities = lbSpecialities.SelectedIndex;
        }

        private void AddDoctor_Load(object sender, EventArgs e)
        {
            loadTxt();
        }

        private void dtpBirthDate_Validating(object sender, CancelEventArgs e)
        {
            if(DateTime.Now.Year -dtpBirthDate.Value.Year > 70 || DateTime.Now.Year - dtpBirthDate.Value.Year < 25)
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Age < 25 || > 70");
            }
        }

        private void dtpBirthDate_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(dtpBirthDate, null);

        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if(tbName.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Name should be > 3");
            }
        }

        private void tbName_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbName, null);
        }

        private void tbWage_Validating(object sender, CancelEventArgs e)
        {
            if(int.Parse(tbWage.Text) < 0)
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Wage should be >=0");
            }
        }

        private void tbWage_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbWage, null);
        }
    }
}
