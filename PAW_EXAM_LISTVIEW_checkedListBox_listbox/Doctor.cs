using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW_EXAM_LISTVIEW_checkedListBox_listbox
{
   public  class Doctor
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime birth { get; set; }

        public float wage { get; set; }

        public int idSpecialty { get; set; }

        public Doctor(int id, string name, DateTime birth, float wage, int idSpecialty)
        {
            this.id = id;
            this.name = name;
            this.birth = birth;
            this.wage = wage;
            this.idSpecialty = idSpecialty;
        }
    }
}
