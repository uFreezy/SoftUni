namespace _03_ExceptionHandling
{
    using System;

    internal class ExceptionHandling
    {
        private static void Main()
        {
            try
            {
                var parse = uint.Parse(Console.ReadLine());
                Console.WriteLine(Math.Sqrt(parse));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Invalid input!");
                throw ex;
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Number must be positive.");
                throw ex;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Input cannot be empty.");
                throw ex;
            }
            finally
            {
                Console.WriteLine("Goodbye");
            }


            ReadNumbers(1, 10);
        }

        public static void ReadNumbers(int start, int end)
        {
            for (var i = 0; i < 10; i++)
            {
                try
                {
                    var input = int.Parse(Console.ReadLine());

                    if (input < start || input > end)
                    {
                        throw new ArgumentException();
                    }
                }

                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Number must be a valid int.");
                    throw ex;
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine("Not a valid number.");
                    throw ex;
                }
            }
        }
    }
}