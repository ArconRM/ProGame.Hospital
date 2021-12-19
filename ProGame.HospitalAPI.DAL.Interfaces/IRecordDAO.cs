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
        Task<int> AddRecordAsync(Record record);

        Task DeleteRecordByIdAsync(int id);

        Task<IEnumerable<Record>> GetAllRecordsAsync();

        Task<Record> GetRecordByIdAsync(int id);
    }
}
