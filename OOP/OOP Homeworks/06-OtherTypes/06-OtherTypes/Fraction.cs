namespace _06_OtherTypes
{
    using System;
    using System.Globalization;

    public struct Fraction
    {
        private long _numerator;
        private long _denominator;

        public Fraction(long numerator, long denominator) : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public long Numerator
        {
            get { return this._numerator; }
            set
            {
                if (value != 0)
                {
                    this._numerator = value;
                }
                else
                {
                    throw new ArgumentException("Numenator cannot be zero.");
                }
            }
        }

        public long Denominator
        {
            get { return this._denominator; }
            set
            {
                if (value != 0)
                {
                    this._denominator = value;
                }
                else
                {
                    throw new ArgumentException("Denominator cannot be zero.");
                }
            }
        }


        public override string ToString()
        {
            var result = this.Numerator/(double) this.Denominator;
            return string.Format(result.ToString(CultureInfo.CurrentCulture));
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            try
            {
                var newNumeartor = checked(a.Numerator*b.Denominator + a.Denominator*b.Numerator);
                var newDenominator = checked(a.Denominator*b.Denominator);
                return new Fraction(newNumeartor, newDenominator);
            }
            catch (OverflowException)
            {
                throw new InvalidOperationException(
                    $"The {"Addition"} of two fractions will be out of allowed range for new fraction");
            }
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            try
            {
                var newNumeartor = checked(a.Numerator*b.Denominator - a.Denominator*b.Numerator);
                var newDenominator = checked(a.Denominator*b.Denominator);

                return new Fraction(newNumeartor, newDenominator);
            }
            catch (OverflowException)
            {
                throw new InvalidOperationException(
                    $"The {"Substraction"} of two fractions will be out of allowed range for new fraction");
            }
        }
    }
}