using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamPractice1
{
    [Serializable]
    public class Doctor : IComparable<Doctor>
    {
        public int id { get; set; }
        public string name{ get; set; }
        public DateTime birthDate { get; set; }
        public float wage { get; set; }
        public int IdSpecialty { get; set; }

        public Doctor()
        {
        }

        public Doctor(int id, string name, DateTime birthDate, float wage, int idSpecialty)
        {
            this.id = id;
            this.name = name;
            this.birthDate = birthDate;
            this.wage = wage;
            IdSpecialty = idSpecialty;
        }

        public int Compare(Doctor x, Doctor y)
        {
            if (x.birthDate == y.birthDate)
                return 0;
            else if (x.birthDate > y.birthDate)
                return 1;
            else return -1;



            throw new NotImplementedException();
        }

        public int CompareTo(Doctor y)
        {
            if(this.birthDate == y.birthDate)
                return 0;
            else if (this.birthDate > y.birthDate)
                return 1;
            else return -1;
            throw new NotImplementedException();
        }
    }
}
