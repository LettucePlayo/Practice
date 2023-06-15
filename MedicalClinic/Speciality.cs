using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic
{
    class Speciality
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Speciality(int iD, string name)
        {
            ID = iD;
            Name = name;
        }
    }
}
