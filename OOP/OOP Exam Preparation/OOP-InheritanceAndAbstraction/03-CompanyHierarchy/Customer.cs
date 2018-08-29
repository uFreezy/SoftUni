using System;

namespace _03_CompanyHierarchy
{
    public class Customer : Person, ICustomer
    {
        private float netPurchase;

        public Customer(int id, string firstName, string lastName, float netPurchase)
            : base(id, firstName, lastName)
        {
            this.NetPurchase = netPurchase;
        }

        public float NetPurchase
        {
            get { return this.netPurchase; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Net purchase cannot be negative number");
                }

                this.netPurchase = value;
            }
        }
    }
}