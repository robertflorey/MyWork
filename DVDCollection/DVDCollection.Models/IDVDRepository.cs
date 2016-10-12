using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDCollection.Models
{
    public interface IDVDRepository
    {
        IEnumerable<DVD> GetAllDVDs();
        DVD GetDVD(int dvdId);
        IEnumerable<DVD> GetDVDByTitle(string search);
        DVD AddDVD(DVD dvd);
        void EditDVD(DVD dvd);
        bool RemoveDVD(int dvdId);
        void LendDVD(int dvdId, int borrowerId);
        void ReturnDVD(int dvdId);
    }
}
