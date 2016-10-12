using DVDCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDCollection.BLL.Tests.MockDVDRepos
{
    public class NotImplementedMockDVDRepository : IDVDRepository
    {
        public DVD AddDVD(DVD dvd)
        {
            throw new NotImplementedException();
        }

        public void EditDVD(DVD dvd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DVD> GetAllDVDs()
        {
            throw new NotImplementedException();
        }

        public DVD GetDVD(int dvdId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DVD> GetDVDByTitle(string search)
        {
            throw new NotImplementedException();
        }

        public void LendDVD(int dvdId, int borrowerId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveDVD(int dvdId)
        {
            throw new NotImplementedException();
        }

        public void ReturnDVD(int dvdId)
        {
            throw new NotImplementedException();
        }
    }
}
