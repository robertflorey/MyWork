using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDCollection.Data
{
    public static class DbCommandExtensions
    {
        public static void AddParm(this DbCommand command, string parameterName, object value, DbType dbtype, int size = 0)
        {
            var parm = command.CreateParameter();
            parm.Direction = ParameterDirection.Input;
            parm.ParameterName = parameterName;
            parm.Value = value;
            parm.DbType = dbtype;
            parm.Size = size;

            command.Parameters.Add(parm);
        }
    }
}
