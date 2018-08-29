namespace Exceptions_Homework
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class Exceptions
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            if (arr == null || arr.Length == 0)
            {
                throw new ArgumentException("The input array cannot be empty.");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException("StartIndex cannot be a negative number.");
            }

            if (count > arr.Length - startIndex)
            {
                throw new ArgumentOutOfRangeException("Conut cannot be bigger than (arr.Length - startIndex ).");
            }

            var result = new List<T>();

            for (var i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("String cannot be empty.");
            }

            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException("Count must be a positive number.");
            }

            if (count > str.Length)
            {
                throw new ArgumentOutOfRangeException("Count cannot be bigger than the string's length");
            }

            var result = new StringBuilder();

            for (var i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }

        public static bool CheckPrime(int number)
        {
            for (var divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number%divisor == 0)
                {
                    //The number is not prime.
                    return false;
                }
            }

            //The number is prime.
            return true;
        }

        private static void Main()
        {
            var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = Subsequence(new[] {-1, 3, 2, 1}, 0, 2);
            Console.WriteLine(string.Join(" ", subarr));

            var allarr = Subsequence(new[] {-1, 3, 2, 1}, 0, 4);
            Console.WriteLine(string.Join(" ", allarr));

            var emptyarr = Subsequence(new[] {-1, 3, 2, 1}, 0, 0);
            Console.WriteLine(string.Join(" ", emptyarr));

            Console.WriteLine(ExtractEnding("I love C#", 2));
            Console.WriteLine(ExtractEnding("Nakov", 4));
            Console.WriteLine(ExtractEnding("beer", 4));
            Console.WriteLine(ExtractEnding("Hi", 100));

            try
            {
                CheckPrime(23);
                Console.WriteLine("23 is prime.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("23 is not prime");
            }

            try
            {
                CheckPrime(33);
                Console.WriteLine("33 is prime.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("33 is not prime");
            }

            var peterExams = new List<Exam>
            {
                new SimpleMathExam(2),
                new CSharpExam(-55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                new CSharpExam(0)
            };
            var peter = new Student("Peter", "Petrov", peterExams);
            var peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}