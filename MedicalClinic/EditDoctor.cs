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
    
    public partial class EditDoctor : Form
    {
        public List<String> specialty;
        public Doctor doctor;
        public EditDoctor(Doctor doctor)
        {
            specialty = new List<String>();
            this.doctor = doctor;
            InitializeComponent();
        }

        private void EditDoctor_Load(object sender, EventArgs e)
        {
            tbID.Text = doctor.Id.ToString();
            tbName.Text = doctor.Name;
            dtpBirth.Value = doctor.BirthDate;
            tbWage.Text = doctor.Wage.ToString();
            tbSpec.Text = doctor.IdSpecialty.ToString();

            string[] lines = System.IO.File.ReadAllLines("Specialty.txt");
            foreach (string line in lines)
            {
                specialty.Add(line);
                lbSpecialty.Items.Add(line);
            }
        }

        private void lbSpecialty_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbSpecialty.SelectedIndex;
            tbSpec.Text = specialty.ElementAt(index);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            doctor.Id = int.Parse(tbID.Text);
            doctor.Name = tbName.Text;
            doctor.BirthDate = dtpBirth.Value;
            doctor.Wage = float.Parse(tbWage.Text);
            doctor.IdSpecialty = specialty.IndexOf(tbSpec.Text);
        }
    }
}
