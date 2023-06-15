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
    public partial class Form1 : Form
    {
        public List<String> specialty;
        public List<Doctor> doctors;
        public Form1()
        {
            doctors = new List<Doctor>();
            InitializeComponent();
            DisplayDoctors();
            DisplayDataGridView();
        }

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            AddDoctor addDoctor = new AddDoctor(this);
            addDoctor.Show();
        }

        public void DisplayDoctors()
        {
            listView1.Items.Clear();
            foreach(Doctor doctor in doctors)
            {
                var listVIewItem = new ListViewItem(doctor.id.ToString());
                listVIewItem.SubItems.Add(doctor.name);
                listVIewItem.SubItems.Add(doctor.birthDate.ToString());
                listVIewItem.SubItems.Add(doctor.wage.ToString());
                //listVIewItem.SubItems.Add(doctor.specialtyId.ToString());
                listVIewItem.SubItems.Add(specialty.ElementAt((doctor.specialtyId)));

                listVIewItem.Tag = doctor;
                listView1.Items.Add(listVIewItem);

            }
        }

        public void DisplayDataGridView()
        {
            dataGridView1.Rows.Clear();

            foreach(Doctor doctor in doctors)
            {
                int rowId = dataGridView1.Rows.Add(new object[]
                {
                    doctor.id,
                    doctor.name,
                    doctor.birthDate,
                    doctor.wage,
                    doctor.specialtyId
                });
                dataGridView1.Rows[rowId].Tag = doctor;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0 &&
                dataGridView1.SelectedRows.Count==0)
            {
                MessageBox.Show("No selected items");
                return;
            }
            else
            {
                if (listView1.SelectedItems.Count != 0)
                {
                    ListViewItem lvi = listView1.SelectedItems[0];
                    Doctor doctor = (Doctor)lvi.Tag;
                    doctors.Remove(doctor);

                }
                if (dataGridView1.SelectedRows.Count != 0)
                {
                    DataGridViewRow dataGridViewRow = dataGridView1.CurrentRow;
                    Doctor doctor = (Doctor)dataGridView1.Tag;
                    doctors.Remove(doctor);
                }
                
                AddDoctor addDoctor = new AddDoctor(this);
                addDoctor.Show();

            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("No selected items");
                return;
            } else
            {
                ListViewItem lvi = listView1.SelectedItems[0];
                Doctor doctor = (Doctor)lvi.Tag;
                doctors.Remove(doctor);
                DisplayDoctors();

            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            Doctor doctor = (Doctor)row.Tag;
            doctors.Remove(doctor);
            DisplayDataGridView();
            DisplayDoctors();
        }
    }
}
