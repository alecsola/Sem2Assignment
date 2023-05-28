using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.Class;

namespace DataLayer.DataConvertingToObject
{
    public class DataConvertingPayment
    {
        public static Payment ConvertRowToPayment(DataRow row)
        {
            int Id = (int)row["Id"];
            int UserId = (int)row["UserId"];
       
            string Price = (string)row["Price"];
            List<string> productNames = new List<string>();

            
            string productNamesString = (string)row["ProductName"];
            productNames.AddRange(productNamesString.Split(','));

            Payment payment = new Payment(Id, UserId, Price, productNames);
            return payment;
        }
    }
}
