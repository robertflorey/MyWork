using DVDCollection.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDCollection.Data
{
    public class DbBorrowerRepository : IBorrowerRepository
    {
        private const string CONN_STRING_KEY = "RJFDVD";

        public bool AddBorrower(Borrower borrower)
        {
            using (var connection = Connector.GetOpenConnection(CONN_STRING_KEY))
            {
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO [Borrower] (Name, CheckOutDate, CheckInDate, DVDId) VALUES " +
                    "(@Name, @CheckOutDate, @CheckInDate, @DVDId); ";

                command.AddParm("@Name", borrower.Name, DbType.String);
                command.AddParm("@CheckOutDate", borrower.CheckOutDate.HasValue ? (object)borrower.CheckOutDate.Value : DBNull.Value, DbType.DateTime);
                command.AddParm("@CheckInDate", borrower.CheckInDate.HasValue ? (object)borrower.CheckInDate.Value : DBNull.Value, DbType.DateTime);
                command.AddParm("@DVDId", borrower.DVDId.HasValue ? (object)borrower.DVDId.Value : DBNull.Value, DbType.Int32);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public IEnumerable<Borrower> GetAllBorrowers()
        {
            using (var connection = Connector.GetOpenConnection(CONN_STRING_KEY))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT BorrowerId, Name, CheckOutDate, CheckInDate, DVDId FROM Borrower;";

                using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        yield return ReadBorrower(reader);
                    }
                }
            }
        }

        public Borrower GetBorrower(int borrowerId)
        {
            using (var connection = Connector.GetOpenConnection(CONN_STRING_KEY))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT BorrowerId, Name, CheckOutDate, CheckInDate, DVDId " +
                    "FROM Borrower " +
                    "WHERE BorrowerId = @BorrowerId;";

                command.AddParm("@BorrowerId", borrowerId, DbType.Int32);

                using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                    {
                        return ReadBorrower(reader);
                    }
                }
            }

            return null;
        }

        public void BorrowDVD(int borrowerId, int dvdId)
        {
            using (var connection = Connector.GetOpenConnection(CONN_STRING_KEY))
            {
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE [Borrower] SET " +
                    "CheckOutDate = @CheckOutDate, " +
                    "CheckInDate = @CheckInDate, " +
                    "DVDId = @DVDId " +
                    "WHERE BorrowerId = @BorrowerId;";

                command.AddParm("@BorrowerId", borrowerId, DbType.Int32);
                command.AddParm("@CheckOutDate", DateTime.Now, DbType.DateTime);
                command.AddParm("@CheckInDate", DateTime.Now.AddMonths(1), DbType.DateTime);
                command.AddParm("@DVDId", dvdId, DbType.Int32);
                command.ExecuteNonQuery();
            }
        }

        public void BorrowerReturnDVD(int borrowerId)
        {
            Borrower borrower = new Borrower();
            borrower = GetBorrower(borrowerId);

            using (var connection = Connector.GetOpenConnection(CONN_STRING_KEY))
            {
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE [Borrower] SET " +
                    "CheckOutDate = @CheckOutDate, " +
                    "CheckInDate = @CheckInDate, " +
                    "DVDId = @DVDId " +
                    "WHERE BorrowerId = @BorrowerId;";

                command.AddParm("@BorrowerId", borrower.BorrowerId, DbType.Int32);
                command.AddParm("@CheckOutDate", DBNull.Value, DbType.DateTime);
                command.AddParm("@CheckInDate", DBNull.Value, DbType.DateTime);
                command.AddParm("@DVDId", DBNull.Value, DbType.Int32);
                command.ExecuteNonQuery();
            }
        }

        private Borrower ReadBorrower(DbDataReader reader)
        {
            var checkOutDateOrdinal = reader.GetOrdinal("CheckOutDate");
            var checkInDateOrdinal = reader.GetOrdinal("CheckInDate");
            var dvdIdOrdinal = reader.GetOrdinal("DVDId");

            return new Borrower
            {
                BorrowerId = reader.GetInt32(reader.GetOrdinal("BorrowerId")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
                CheckOutDate = reader.IsDBNull(checkOutDateOrdinal) ? default(DateTime?) : reader.GetDateTime(checkOutDateOrdinal),
                CheckInDate = reader.IsDBNull(checkInDateOrdinal) ? default(DateTime?) : reader.GetDateTime(checkInDateOrdinal),
                DVDId = reader.IsDBNull(dvdIdOrdinal) ? default(int?) : reader.GetInt32(dvdIdOrdinal)
            };
        }

        private int NextId()
        {
            using (var connection = Connector.GetOpenConnection(CONN_STRING_KEY))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT MAX(BorrowerId) FROM Borrower;";

                var result = command.ExecuteScalar();
                if (result == DBNull.Value)
                {
                    return 1;
                }
                return ((int)result + 1);
            }
        }
    }
}
