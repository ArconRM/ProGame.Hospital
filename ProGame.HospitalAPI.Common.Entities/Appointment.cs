using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.Common.Entities
{
    public class Appointment: BaseEntity
    {
        public Record Record { get; set; }
        public string Description { get; set; }
        public bool IsCancelled { get; set; }
    }
}
