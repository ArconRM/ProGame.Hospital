using ProGame.HospitalAPI.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.DAL.Interfaces
{
    public interface IRecordDAO
    {
        void Add(Record record);
        void Delete(Record record);
        IEnumerable<Record> GetAll();
        Record GetById(int id);
    }
}
