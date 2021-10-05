using ProGame.HospitalAPI.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.BLL.Interfaces
{
    public interface ICardInterface
    {
        void Add(Card card);

        void Delete(Card card);
        void Update(Card card);
        void GetAll();
    }
}
