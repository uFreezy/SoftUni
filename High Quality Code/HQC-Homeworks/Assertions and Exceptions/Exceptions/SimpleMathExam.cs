namespace Exceptions_Homework
{
    using System;

    public class SimpleMathExam : Exam
    {
        public SimpleMathExam(int problemsSolved)
        {
            if (problemsSolved < 0)
            {
                throw new ArgumentOutOfRangeException("The problems solved cannot be less than 0.");
            }
            if (problemsSolved > 2)
            {
                throw new ArgumentOutOfRangeException("The problems solved cannot be more than 2");
            }

            this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved { get; private set; }

        public override ExamResult Check()
        {
            switch (this.ProblemsSolved)
            {
                case 0:
                    return new ExamResult(2, 2, 6, "Bad result: nothing done.");
                case 1:
                    return new ExamResult(4, 2, 6, "Average result: nothing done.");
                case 2:
                    return new ExamResult(6, 2, 6, "Average result: nothing done.");
                default:
                    throw new ArgumentOutOfRangeException("Invalid number of problems solved!");
            }
        }
    }
}