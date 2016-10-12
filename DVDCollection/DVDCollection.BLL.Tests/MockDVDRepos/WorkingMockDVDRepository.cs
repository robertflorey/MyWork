using DVDCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDCollection.BLL.Tests.MockDVDRepos
{
    public class WorkingMockDVDRepository : IDVDRepository
    {
        private static List<DVD> _dvds;

        static WorkingMockDVDRepository()
        {
            _dvds = new List<DVD>
            {
                new DVD
                {
                    DVDId=1,
                    Title= "Snatch",
                    ReleaseDate = new DateTime(2001,01,19),
                    MPAARating= "R",
                    Studio= "SKA Films",
                    DirectorsName= "Guy Ritchie",
                    ActorsName= "Jason Statham",
                    UserRating= "Great",
                    UserNotes= "What do I know about Diamonds.",
                    Available= false,
                    BorrowerId=1
                },
                 new DVD
                {
                    DVDId=2,
                    Title= "Lock, Stock, And Two Smoking Barrels",
                    ReleaseDate = new DateTime(1998,08,28),
                    MPAARating= "R",
                    Studio= "SKA Films",
                    DirectorsName= "Guy Ritchie",
                    ActorsName= "Jason Flemyng",
                    UserRating= "Great",
                    UserNotes= "Gambling is bad.",
                    Available= true
                },
            };
        }
        public DVD AddDVD(DVD dvd)
        {
            return dvd;
        }

        public void EditDVD(DVD dvd)
        {
             var result = dvd;
        }

        public IEnumerable<DVD> GetAllDVDs()
        {
            return _dvds;
        }

        public DVD GetDVD(int dvdId)
        {
            DVD dvd = new DVD();
            dvd = _dvds.FirstOrDefault(d => d.DVDId == dvdId);
            return dvd;
        }

        public IEnumerable<DVD> GetDVDByTitle(string search)
        {
            List<DVD> dvds = new List<DVD>();
            foreach(DVD dvd in _dvds)
            {
                if(dvd.Title.Contains(search))
                {
                    dvds.Add(dvd);
                }
            }
            return dvds;
        }

        public void LendDVD(int dvdId, int borrowerId)
        {
            DVD dvd = new DVD();
            dvd = GetDVD(dvdId);
            dvd.BorrowerId = borrowerId;
        }

        public bool RemoveDVD(int dvdId)
        {
            DVD dvd = new DVD();
            dvd=_dvds.FirstOrDefault(d => d.DVDId == dvdId);
            return true;

        }

        public void ReturnDVD(int dvdId)
        {
            DVD dvd = new DVD();
            dvd = GetDVD(dvdId);
        }
    }
}
