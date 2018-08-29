namespace Exceptions_Homework
{
    using System;

    public class CSharpExam : Exam
    {
        public CSharpExam(int score)
        {
            if (score < 0 || score > 100)
            {
                throw new ArgumentOutOfRangeException("Score cannot be below 0 or above 100.");
            }

            this.Score = score;
        }

        public int Score { get; private set; }

        public override ExamResult Check()
        {
            if (this.Score < 0 || this.Score > 100)
            {
                throw new ArgumentOutOfRangeException("The score cannot be below 0 or above 100.");
            }

            return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
        }
    }
}