using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            try
            {
                con.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = (SqlConnection)con;
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
                con.Close();
            }
            return result;
        }

        public int executeQuery(string query)
        {
            try
            {
                con.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = (SqlConnection)con;
                    command.CommandText = query;
                    return command.ExecuteNonQuery();
                }
            }
            catch
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
