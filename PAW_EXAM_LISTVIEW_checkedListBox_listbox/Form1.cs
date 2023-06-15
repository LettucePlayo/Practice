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
    public partial class Form1 : Form
    {
        public List<Doctor> doctors;
        public Form1()
        {
            doctors = new List<Doctor>();
            InitializeComponent();
            displayDoctors();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddDoctor adddoctor = new AddDoctor(this);
            adddoctor.Show();
        }

      public void displayDoctors()
        {
            listView1.Items.Clear();

            foreach(Doctor doctor in doctors)
            {
                var cacat = new ListViewItem(doctor.id.ToString());
                cacat.SubItems.Add(doctor.name);
                cacat.SubItems.Add(doctor.birth.ToString());
                cacat.SubItems.Add(doctor.wage.ToString());
                cacat.SubItems.Add(doctor.idSpecialty.ToString());

                cacat.Tag = doctor;
                listView1.Items.Add(cacat);

            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("No items selected!");
                return;
            }
            else
            {
                ListViewItem listviewitem = listView1.SelectedItems[0];
                Doctor d = (Doctor)listviewitem.Tag;
                doctors.Remove(d);

                AddDoctor doctor = new AddDoctor(this);
                doctor.Show();


            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("No items selected!");
                return;
            }
            else
            {
                ListViewItem listviewitem = listView1.SelectedItems[0];
                Doctor d = (Doctor)listviewitem.Tag;
                doctors.Remove(d);
                displayDoctors();
            }
        }
    }
}
