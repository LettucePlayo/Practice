using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic
{
    [Serializable]
    public class Doctor : IComparable<Doctor>,IComparer<Doctor>
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public DateTime BirthDate { get; set; }

        public float Wage { get; set; }

        public int IdSpecialty { get; set; }
        public Doctor()
        {
        }
        public Doctor(int id, string name, DateTime birthDate, float wage, int IdSpecialty)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            Wage = wage;
            this.IdSpecialty = IdSpecialty;
        }

        public int CompareTo(Doctor other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public int Compare(Doctor x, Doctor y)
        {
            if (x.BirthDate > y.BirthDate)
                return 1;
            if (x.BirthDate == y.BirthDate)
                return 0;
            else return -1;
        }
    }
}
