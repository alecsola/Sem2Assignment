using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public abstract class BaseDAL
    {
        private string _connectionstring = "Server=mssqlstud.fhict.local; Database=dbi500217_easeexpres;User Id = dbi500217_easeexpres; Password=Alec;Encrypt=False";
        protected IDbConnection GetConnection()
        {
            IDbConnection connection = new SqlConnection(_connectionstring);
            return connection;
        }
    }

}
