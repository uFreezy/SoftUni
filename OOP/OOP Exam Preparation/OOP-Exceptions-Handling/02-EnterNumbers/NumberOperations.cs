using System;

public class NumberOperations
{
    private int start;
    private int end;

    public NumberOperations(int start, int end)
    {
        this.start = start;
        this.end = end;
    }

    public int Start
    {
        get { return this.start; }
        set
        {
            try
            {
                this.start = value;
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

    public int End
    {
        get { return this.end; }
        set
        {
            try
            {
                if (value > this.start)
                {
                    this.end = value;
                }
                else
                {
                    throw new ArgumentException("End must be bigger than Start");
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

    public void EnterNumbers()
    {
        int Counter = 0;

        while (true)
        {
            try
            {
                int input = int.Parse(Console.ReadLine());

                if (input < this.start || input > this.end)
                {
                   throw new ArgumentException();
                }

                Counter++;
            }

            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Number must be a valid int.");
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine("Not a valid number.");
            }

            if (Counter == 10)
            {
                break;
            }
        }
    }
}
