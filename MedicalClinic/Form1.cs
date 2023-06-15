using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MedicalClinic
{
  
    public partial class Form1 : Form
    {
        public List<Doctor> doctors;
        public Form1()
        {
            doctors = new List<Doctor>();
            InitializeComponent();
        }

        private void displayDoctors()
        {
            lvDoctors.Items.Clear();
            foreach(Doctor doctor in doctors)
            {
                var listViewItem = new ListViewItem(doctor.Id.ToString());
                listViewItem.SubItems.Add(doctor.Name);
                listViewItem.SubItems.Add(doctor.BirthDate.ToShortDateString());
                listViewItem.SubItems.Add(doctor.Wage.ToString());
                listViewItem.SubItems.Add(doctor.IdSpecialty.ToString());

                listViewItem.Tag = doctor;
                lvDoctors.Items.Add(listViewItem);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Doctor>));
            using (FileStream fileStream = File.OpenRead("Serialized.xml"))
            {
                doctors = (List<Doctor>)xmlSerializer.Deserialize(fileStream);
                displayDoctors();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddDoctor editForm = new AddDoctor(doctors);
            if(editForm.ShowDialog() == DialogResult.OK)
            {
                displayDoctors();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(lvDoctors.SelectedItems.Count == 0)
            {
                MessageBox.Show("No items selected!");
                return;
            }
            ListViewItem listViewItem = lvDoctors.SelectedItems[0];
            Doctor d = (Doctor)listViewItem.Tag;
            doctors.Remove(d);
            displayDoctors();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvDoctors.SelectedItems.Count == 0)
            {
                MessageBox.Show("No items selected!");
                return;
            }

            ListViewItem listViewItem = lvDoctors.SelectedItems[0];
            Doctor doctor = (Doctor)listViewItem.Tag;
            EditDoctor doctor1 = new EditDoctor(doctor);
            if(doctor1.ShowDialog() == DialogResult.OK)
            {
                displayDoctors();
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Doctor>));
            using (FileStream fileStream = File.Create("Serialized.xml"))
            {
                xmlSerializer.Serialize(fileStream, doctors);
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Doctor>));
            using (FileStream fileStream = File.OpenRead("Serialized.xml"))
            {
                doctors = (List<Doctor>)xmlSerializer.Deserialize(fileStream);
                displayDoctors();
            }
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            doctors.Sort();
            displayDoctors();
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            doctors.Sort(new Doctor());
            displayDoctors();
        }
    }
}
