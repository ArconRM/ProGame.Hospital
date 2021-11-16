using ProGame.HospitalAPI.Common.Entities;
using ProGame.HospitalAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.DAL
{
    public class RecordDAO : IRecordDAO
    {
        public void Add(Record record)
        {
            using (HospitalAPIContext db = new())
            {
                db.Records.Add(record);
                db.SaveChanges();
            }
        }

        public void Delete(Record record)
        {
            using (HospitalAPIContext db = new())
            {
                db.Records.Remove(record);
                db.SaveChanges();
            }
        }

        public IEnumerable<Record> GetAll()
        {
            using (HospitalAPIContext db = new())
            {
                return db.Records.ToList();
            }
        }

        public Record GetById(int id)
        {
            using (HospitalAPIContext db = new())
            {
                return db.Records.Where(r => r.Id == id).FirstOrDefault();
            }
        }
    }
}
