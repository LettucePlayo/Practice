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

namespace ExamPractice1
{
    public partial class Form1 : Form
    {
        public List<Doctor> doctor;
        public Form1()
        {
            doctor = new List<Doctor>();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void displayDoctors()
        {
            lvDoctor.Items.Clear();
            foreach (Doctor doctors in doctor)
            {
                var listViewItem = new ListViewItem(doctors.id.ToString());
                listViewItem.SubItems.Add(doctors.name);
                listViewItem.SubItems.Add(doctors.wage.ToString());
                listViewItem.SubItems.Add(doctors.birthDate.ToShortDateString());
                listViewItem.SubItems.Add(doctors.IdSpecialty.ToString());

                listViewItem.Tag = doctors;
                lvDoctor.Items.Add(listViewItem);
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            AddDoctor addDoctor = new AddDoctor(doctor);
            if (addDoctor.ShowDialog() == DialogResult.OK)
            {
                displayDoctors();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lvDoctor.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a doctor!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ListViewItem item = lvDoctor.SelectedItems[0];
            Doctor doctorss = (Doctor)item.Tag;
            doctor.Remove(doctorss);
            displayDoctors();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(lvDoctor.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a doctor!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ListViewItem item = lvDoctor.SelectedItems[0];
            Doctor medic = (Doctor)item.Tag;
            EditForm editForm = new EditForm(medic);
            if(editForm.ShowDialog() == DialogResult.OK)
            {
                displayDoctors();
            }

        }

        private void xMLSerializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Doctor>));
            using (FileStream fileStream = File.Create("serializer.xml"))
                serializer.Serialize(fileStream, doctor);
        }

        private void xMLDeserializeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Doctor>));
            using (FileStream fileStream = File.OpenRead("serializer.xml"))
               doctor = (List<Doctor>)xmlSerializer.Deserialize(fileStream);
            doctor.Sort();
            displayDoctors();
         
        }

      
    }
}
