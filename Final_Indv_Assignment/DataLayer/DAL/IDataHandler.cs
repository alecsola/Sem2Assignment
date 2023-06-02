using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DataLayer.DAL
{
    internal interface IDataHandler
    {
        DataTable ReadData(string query);

        int executeQuery(string query, SqlParameter[]? sqlParameters);
        int executeQuery(string query);
    }
}
