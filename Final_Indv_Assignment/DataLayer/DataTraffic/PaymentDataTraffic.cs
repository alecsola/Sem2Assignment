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

namespace DataLayer.DataTraffic
{
    public class PaymentDataTraffic : DataHandler, IPaymentDataTraffic
    {
        protected override string cmd
        {
            get
            {
                return "select p.Id, u.UserId,u.Username,  p.Price p.ProductName from Payment p inner join Users u ON p.UserId=u.UserId";
            }
        }
        public Payment GetPaymentById(int id)
        {
            DataTable table = base.ReadData();
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
            DataTable table = base.ReadData();
            foreach (DataRow dr in table.Rows)
            {
                payments.Add(DataConvertingPayment.ConvertRowToPayment(dr));
            }


            return payments;
        }
        public bool AddPayment(Payment payment)
        {
           
            string productNamesString = string.Join(",", payment.ProductName);
            string query = $"INSERT INTO Payment (Id,UserId, Price,ProductName) " + $"VALUES ({payment.Id},{payment.UserId},'{payment.Price}','{productNamesString}' )";
            return executeQuery(query) == 0 ? false : true;
        }
    }
}
