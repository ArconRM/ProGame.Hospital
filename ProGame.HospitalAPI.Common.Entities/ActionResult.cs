using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.Common.Entities
{
    public class ActionResult<T>
    {
        public T Value { get; set; }

        public ICollection<string> Exceptions { get; set; }

        public ActionResult(T value, ICollection<string> exceptions)
        {
            Value = value;
            Exceptions = exceptions;
        }
    }
}
