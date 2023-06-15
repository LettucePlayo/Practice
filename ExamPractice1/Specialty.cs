using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPractice1
{
    class Specialty
    {
        public int ID { get; set; }
        public string name { get; set; }

        public Specialty(int iD, string name)
        {
            ID = iD;
            this.name = name;
        }
    }
}
