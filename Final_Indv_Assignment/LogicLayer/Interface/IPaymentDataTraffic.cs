﻿using LogicLayer.Class;

namespace DataLayer.DataTraffic
{
    public interface IPaymentDataTraffic
    {
        bool AddPayment(Payment payment);
        List<Payment> GetAllPayments();
        Payment GetPaymentById(int id);
        public List<Payment> HasUserSeasonTicket(int UserId);
    }
}