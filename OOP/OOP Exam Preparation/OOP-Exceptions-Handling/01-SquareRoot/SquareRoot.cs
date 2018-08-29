using System;

public class SquareRoot
{
    private uint number;

    public SquareRoot()
    {
    }

    public uint Number
    {
        get { return this.number; }
        set
        {
            try
            {
                this.number = value;
                Console.WriteLine(String.Format("Square root: {0}", Math.Sqrt(value)));
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine("Number must be valid.");
                throw ex;
            }

            catch (OverflowException ex)
            {
                Console.WriteLine("Number must be positive.");
                throw ex;
            }

            finally
            {
                Console.WriteLine("Goodbye!");
            }
        }
    }
}
