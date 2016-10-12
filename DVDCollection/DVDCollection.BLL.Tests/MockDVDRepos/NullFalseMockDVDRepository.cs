using DVDCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDCollection.BLL.Tests.MockDVDRepos
{
    public class NullFalseMockDVDRepository : IDVDRepository
    {
        public DVD AddDVD(DVD dvd)
        {
            return null;
        }

        public void EditDVD(DVD dvd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DVD> GetAllDVDs()
        {
            return null;
        }

        public DVD GetDVD(int dvdId)
        {
            return null;
        }

        public IEnumerable<DVD> GetDVDByTitle(string search)
        {
            return null;
        }

        public void LendDVD(int dvdId, int borrowerId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveDVD(int dvdId)
        {
            return false;
        }

        public void ReturnDVD(int dvdId)
        {
            throw new NotImplementedException();
        }
    }
}
