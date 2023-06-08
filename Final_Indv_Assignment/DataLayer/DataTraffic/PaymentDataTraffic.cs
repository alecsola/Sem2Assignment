using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DAL;
using DataLayer.DataConvertingToObject;
using LogicLayer.Class;
using Microsoft.Data.SqlClient;

namespace DataLayer.DataTraffic
{
    public class PaymentDataTraffic : DataHandler, IPaymentDataTraffic
    {
        protected override string cmd
        {
            get
            {
                return "select p.Id, p.Price, u.UserId, u.Username,p.ProductName from Payment p inner join Users u ON p.UserId=u.UserId";
            }
        }
        public Payment GetPaymentById(int id)
        {
            DataTable table = base.ReadData(cmd);
            foreach (DataRow dr in table.Rows)
            {
                Payment payment = DataConvertingPayment.ConvertRowToPayment(dr);
                if (payment.Id == id)
                {
                    return payment;
                }
            }
            return null; // or throw an exception indicating the ticket was not found
        }
        
        public List<Payment> GetAllPayments()
        {
            List<Payment> payments = new List<Payment>();
            DataTable table = base.ReadData(cmd);
            foreach (DataRow dr in table.Rows)
            {
                payments.Add(DataConvertingPayment.ConvertRowToPayment(dr));
            }


            return payments;
        }
        public List<Payment> HasUserSeasonTicket(int UserId)
        {
            List<Payment> payments = new List<Payment>();
            string query = $"SELECT p.Id, p.Price, p.UserId, p.ProductName FROM Payment p WHERE ProductName IN (SELECT ProductName FROM dbo.SeasonTickets st WHERE st.SeasonTicketName = ProductName) and UserId ={UserId} ;";
            DataTable table = base.ReadData(query);
            foreach (DataRow dr in table.Rows)
            {
                payments.Add(DataConvertingPayment.ConvertRowToPayment(dr));
            }

            return payments;
        }
        public bool AddPayment(Payment payment)
        {
           

            string productNamesString = string.Join(",", payment.ProductName);
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("Price", payment.Price));
            
            string query = $"INSERT INTO Payment (UserId, Price,ProductName) " + $"VALUES ({payment.UserId},@Price,'{productNamesString}' )";
            
            return executeQuery(query, parameters.ToArray()) == 0 ? false : true;
        }
    }
}
