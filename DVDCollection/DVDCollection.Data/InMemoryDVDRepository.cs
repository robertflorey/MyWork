using DVDCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDCollection.Data
{
    public class InMemoryDVDRepository : IDVDRepository
    {
        private static List<DVD> _dvds;

        static InMemoryDVDRepository()
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
            _dvds.Add(dvd);
            return dvd;
        }

        public void EditDVD(DVD dvd)
        {
            var selectedDVD = _dvds.FirstOrDefault(d => d.DVDId == dvd.DVDId);

        }

        public IEnumerable<DVD> GetAllDVDs()
        {
            return _dvds;
        }

        public DVD GetDVD(int dvdId)
        {
            var dvds = GetAllDVDs();
            return dvds.FirstOrDefault(d => d.DVDId == dvdId);
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
