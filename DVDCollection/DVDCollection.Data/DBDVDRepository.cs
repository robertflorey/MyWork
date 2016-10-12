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
    public class DbDVDRepository : IDVDRepository
    {
        private const string CONN_STRING_KEY = "RJFDVD";

        public DVD AddDVD(DVD dvd)
        {
            using (var connection = Connector.GetOpenConnection(CONN_STRING_KEY))
            {
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO [DVD] (Title, ReleaseDate, MPAARating, Studio, DirectorsName, ActorsName, UserRating, UserNotes, Available) VALUES " +
                    "(@Title, @ReleaseDate, @MPAARating, @Studio, @DirectorsName, @ActorsName, @UserRating, @UserNotes, @Available);";

                command.AddParm("@Title", dvd.Title, DbType.String);
                command.AddParm("@ReleaseDate", dvd.ReleaseDate, DbType.Date);
                command.AddParm("@MPAARating", dvd.MPAARating, DbType.String);
                command.AddParm("@Studio", dvd.Studio, DbType.String);
                command.AddParm("@DirectorsName", dvd.DirectorsName, DbType.String);
                command.AddParm("@ActorsName", dvd.ActorsName, DbType.String);
                command.AddParm("@UserRating", dvd.UserRating, DbType.String);
                command.AddParm("@UserNotes", dvd.UserNotes, DbType.String);
                command.AddParm("@Available", true, DbType.Boolean);

                command.ExecuteNonQuery();
                return dvd;
            }
        }

        public void EditDVD(DVD dvd)
        {
            using (var connection = Connector.GetOpenConnection(CONN_STRING_KEY))
            {
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE [DVD] SET " +
                    "Title = @Title, " +
                    "ReleaseDate = @ReleaseDate, " +
                    "MPAARating = @MPAARating, " +
                    "Studio = @Studio, " +
                    "DirectorsName = @DirectorsName, " +
                    "ActorsName = @ActorsName, " +
                    "UserRating = @UserRating, " +
                    "UserNotes = @UserNotes, " +
                    "Available = @Available " +
                    "WHERE DVDId = @DVDId;";

                command.AddParm("@DVDId", dvd.DVDId, DbType.Int32);
                command.AddParm("@Title",dvd.Title, DbType.String);
                command.AddParm("@ReleaseDate",dvd.ReleaseDate,DbType.Date);
                command.AddParm("@MPAARating", dvd.MPAARating, DbType.String,5);
                command.AddParm("@Studio", dvd.Studio == "" ? DBNull.Value : (object)dvd.Studio, DbType.String);
                command.AddParm("@DirectorsName", dvd.DirectorsName == "" ? DBNull.Value : (object)dvd.DirectorsName, DbType.String);
                command.AddParm("@ActorsName", dvd.ActorsName == "" ? DBNull.Value : (object)dvd.ActorsName, DbType.String);
                command.AddParm("@UserRating", dvd.UserRating== "" ? DBNull.Value : (object)dvd.UserRating, DbType.String);
                command.AddParm("@UserNotes", dvd.UserNotes == "" ? DBNull.Value : (object)dvd.UserNotes, DbType.String);
                command.AddParm("@Available", true, DbType.Boolean);

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<DVD> GetAllDVDs()
        {
            using (var connection = Connector.GetOpenConnection(CONN_STRING_KEY))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT DVDId, Title, ReleaseDate, MPAARating, Studio, DirectorsName, ActorsName, UserRating, UserNotes, Available, BorrowerId FROM [DVD];";

                using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        yield return ReadDVD(reader);
                    }
                }
            }
        }

        public DVD GetDVD(int dvdId)
        {
            using (var connection = Connector.GetOpenConnection(CONN_STRING_KEY))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT DVDId, Title, ReleaseDate, MPAARating, Studio, DirectorsName, ActorsName, UserRating, UserNotes, Available, BorrowerId " +
                    "FROM DVD " +
                    "WHERE DVDId = @DVDId;";
                command.AddParm("@DVDId", dvdId, DbType.AnsiStringFixedLength, 3);

                using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                    {
                        return ReadDVD(reader);
                    }
                }
            }

            return null;
        }

        public IEnumerable<DVD> GetDVDByTitle(string search)
        {
            using (var connection = Connector.GetOpenConnection(CONN_STRING_KEY))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT DVDId, Title, ReleaseDate, MPAARating, Studio, DirectorsName, ActorsName, UserRating, UserNotes, Available, BorrowerId " +
                    "FROM [DVD] " +
                    "WHERE Title LIKE '%'+@Title +'%';";

                command.AddParm("@Title", search, DbType.String);

                using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        yield return ReadDVD(reader);
                    }
                }
            }
        }

        public bool RemoveDVD(int dvdId)
        {
            DVD dvd = new DVD();
            dvd = GetDVD(dvdId);
            using (var connection = Connector.GetOpenConnection(CONN_STRING_KEY))
            {
                var command = connection.CreateCommand();
                command.CommandText = "DELETE [DVD] " +
                    "WHERE DVDId = @DVDId;";

                command.AddParm("@DVDId", dvd.DVDId, DbType.Int32);
                return command.ExecuteNonQuery() > 0;
            }
            
        }

        public void LendDVD(int dvdId, int borrowerId)
        {
            DVD dvd = new DVD();
            dvd=GetDVD(dvdId);
            using (var connection = Connector.GetOpenConnection(CONN_STRING_KEY))
            {
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE [DVD] SET " +
                    "Available = @Available, " +
                    "BorrowerId = @BorrowerID " +
                    "WHERE DVDId = @DVDId;";

                command.AddParm("@DVDId", dvd.DVDId, DbType.Int32);
                command.AddParm("@Available", false, DbType.Boolean);
                command.AddParm("@BorrowerId", borrowerId, DbType.Int32);
                command.ExecuteNonQuery();
            }
        }

        public void ReturnDVD(int dvdId)
        {
            DVD dvd = new DVD();
            dvd = GetDVD(dvdId);
            using (var connection = Connector.GetOpenConnection(CONN_STRING_KEY))
            {
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE [DVD] SET " +
                    "Available = @Available, " +
                    "BorrowerId = @BorrowerId " +
                    "WHERE DVDId = @DVDId;";
                
                command.AddParm("@DVDId", dvd.DVDId, DbType.Int32);
                command.AddParm("@Available", true, DbType.Boolean);
                command.AddParm("@BorrowerId", DBNull.Value, DbType.Int32);
                command.ExecuteNonQuery();
            }
        }

        private DVD ReadDVD(DbDataReader reader)
        {
            var borrowerIdOrdinal = reader.GetOrdinal("BorrowerId");
            return new DVD
            {
                DVDId = reader.GetInt32(reader.GetOrdinal("DVDId")),
                Title = reader.GetString(reader.GetOrdinal("Title")),
                ReleaseDate= reader.GetDateTime(reader.GetOrdinal("ReleaseDate")),
                MPAARating = reader.GetString(reader.GetOrdinal("MPAARating")),
                Studio = reader.GetString(reader.GetOrdinal("Studio")),
                DirectorsName = reader.GetString(reader.GetOrdinal("DirectorsName")),
                ActorsName = reader.GetString(reader.GetOrdinal("ActorsName")),
                UserRating = reader.GetString(reader.GetOrdinal("UserRating")),
                UserNotes = reader.GetString(reader.GetOrdinal("UserNotes")),
                Available = reader.GetBoolean(reader.GetOrdinal("Available")),
                BorrowerId = reader.IsDBNull(borrowerIdOrdinal) ? default(int?) : reader.GetInt32(borrowerIdOrdinal)
            };
        }

        private int NextId()
        {
            using (var connection = Connector.GetOpenConnection(CONN_STRING_KEY))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT MAX(DVDId)) FROM [DVD];";

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
