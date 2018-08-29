namespace _07_DelegatesAndEvents
{
    public delegate double CalculateInterest(double moneySum, double interest, int years);

    public class InterestCalculator
    {
        private readonly CalculateInterest _interestDelegate;

        public InterestCalculator(double moneySum, double interest, int years,
            CalculateInterest interestDelegate)
        {
            this.Money = moneySum;
            this.Interest = interest;
            this.Years = years;
            this._interestDelegate = interestDelegate;
        }

        public double Money { get; set; }

        public double Interest { get; set; }

        public int Years { get; set; }

        public override string ToString()
        {
            return $"{this._interestDelegate(this.Money, this.Interest, this.Years):F4}";
        }
    }
}