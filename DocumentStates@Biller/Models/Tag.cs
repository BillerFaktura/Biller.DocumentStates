using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentStates_Biller.Models
{
    public class Tag
    {
        public Tag()
        {
            Date = DateTime.Now;
        }
        public string Name { get; set; }

        public DateTime Date { get; set; }
    }
}
