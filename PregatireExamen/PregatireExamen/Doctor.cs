using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PregatireExamen
{
    public class Doctor
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime birthDate { get; set; }

        public float wage { get; set; }

        public int specialtyId { get; set; }

        public Doctor(int id, string name, DateTime birthDate, float wage, int specialtyId)
        {
            this.id = id;
            this.name = name;
            this.birthDate = birthDate;
            this.wage = wage;
            this.specialtyId = specialtyId;
        }
    }
}
