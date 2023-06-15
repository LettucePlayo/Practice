using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalClinic
{
    public partial class AddDoctor : Form
    {
        public List<Doctor> doctori;
        public List<String> specialty;
        public AddDoctor(List<Doctor> list)
        {
            doctori = list;
            specialty = new List<String>();
            InitializeComponent();
        }

        private void AddDoctor_Load(object sender, EventArgs e)
        {
            string[] lines = System.IO.File.ReadAllLines("Specialty.txt");
            foreach(string line in lines)
            {
                specialty.Add(line);
                lbSpecialty.Items.Add(line);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if(ValidateChildren())
                {
                    int id = int.Parse(tbID.Text);
                    string name = tbName.Text;
                    DateTime birth = dtpBirth.Value;
                    float wage = float.Parse(tbWage.Text);
                    int idSpec = specialty.IndexOf(tbSpec.Text);

                    Doctor doctor = new Doctor(id, name, birth, wage, idSpec);
                    doctori.Add(doctor);

                }
                else MessageBox.Show("Check input data!");


            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!");
            }
        }

        private void lbSpecialty_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbSpecialty.SelectedIndex;
            tbSpec.Text = specialty.ElementAt(index);
        }

        private void dtpBirth_Validating(object sender, CancelEventArgs e)
        {
            if(((DateTime.Now - dtpBirth.Value).TotalDays / 365) < 25 || ((DateTime.Now - dtpBirth.Value).TotalDays / 365) >70)
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Age must be > 25 and < 70!");
            }
        }

        private void dtpBirth_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(dtpBirth, null);
        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if(tbName.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Name must have more than 3 characters!");
            }
        }

        private void tbName_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbName, null);
        }

        private void tbWage_Validating(object sender, CancelEventArgs e)
        {
            if(float.Parse(tbWage.Text) < 0 )
            {
                e.Cancel = true;
                errorProvider1.SetError((Control)sender, "Wage must be >=0!");
            }
        }

        private void tbWage_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbWage, null);
        }
    }
}
