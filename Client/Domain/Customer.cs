﻿namespace Domain
{
    public class Customer
    {
        public string Name { get; set; }
        public double CreditLimit { get; set; }
        public Order[] Orders { get; set; }
    }
}
