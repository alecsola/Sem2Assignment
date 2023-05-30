using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public class DataHandler : BaseDAL, IDataHandler
    {
        private IDbConnection con;
        protected virtual string cmd { get; }

        public DataHandler()
        {
            con = GetConnection();
        }

        public DataTable ReadData()
        {
            DataTable result = new DataTable();
            IDbConnection? con2 = null;
            try
            {
                con2 = GetConnection();
                con2.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = (SqlConnection)con2;
                    //get command
                    command.CommandText = cmd;
                    //get data
                    var data = command.ExecuteReader();
                    //fill datatable with querried data
                    result.Load(data);
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                if (con2 != null)
                {
                    con2.Close();
                }
            }
            return result;
        }

        //study this
        public int executeQuery(string query)
        {
            return executeQuery(query, null);
        }

        public int executeQuery(string query, SqlParameter[]? sqlParameters)
        {
            IDbConnection? con3 = null;
                
            try
            {
                con3 = GetConnection();
                con3.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = (SqlConnection)con3;
                    command.CommandText = query;
                    if (sqlParameters != null)
                    {
                        command.Parameters.AddRange(sqlParameters);
                    }
                    return command.ExecuteNonQuery();
                }
            }
            catch
            {
                return 0;
            }
            finally
            {
                if(con3 != null)
                {
                    con3.Close();
                }
                
            }
        }
    }
}
