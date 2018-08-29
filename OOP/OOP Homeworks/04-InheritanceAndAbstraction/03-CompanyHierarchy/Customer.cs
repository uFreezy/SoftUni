namespace _03_CompanyHierarchy
{
    using System;

    public class Customer : Person, ICustomer
    {
        private float _netPurchase;

        public Customer(int id, string firstName, string lastName, float netPurchase)
            : base(id, firstName, lastName)
        {
            this.NetPurchase = netPurchase;
        }

        public float NetPurchase
        {
            get { return this._netPurchase; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Net purchase cannot be negative number");
                }

                this._netPurchase = value;
            }
        }
    }
}