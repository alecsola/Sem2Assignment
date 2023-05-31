﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DataTraffic;
using LogicLayer.Class;
using LogicLayer.Interface;

namespace LogicLayer.Services
{
    public class PaymentService
    {
        private IPaymentDataTraffic paymentDataTraffic;


        public PaymentService(IPaymentDataTraffic paymentDataTraffic)
        {
            this.paymentDataTraffic = paymentDataTraffic ?? throw new ArgumentNullException(nameof(paymentDataTraffic));
        }
        public bool AddPayment(Payment payment)
        {
            return paymentDataTraffic.AddPayment(payment);
        }
        public List<Payment> GetAllPayments()
        {
            return paymentDataTraffic.GetAllPayments();
        }
        public Payment GetPaymentById(int id)
        {
            return paymentDataTraffic.GetPaymentById(id);
        }
        public bool CheckIfUserProduct(int UserId)
        {
            paymentDataTraffic.UserHasProduct(UserId, "Month Ticket");
            foreach (Payment payment in GetAllPayments())
            {
                if (payment.UserId == UserId && payment.ProductName.Contains("Month Ticket"))
                {
             
                    payment.Price = 0;
                    return true;
                }
                
                
            }
            return false;
        }

    }
}