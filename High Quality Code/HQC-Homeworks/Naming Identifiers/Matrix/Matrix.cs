using System;

namespace ConsoleApplication1
{
    internal class Matrix
    {
        private static void Main()
        {
            var primaryMatrixA = new double[,] {{1, 3}, {5, 7}};
            var primaryMatrixB = new double[,] {{4, 2}, {1, 5}};

            var resultingMatrix = Merge(primaryMatrixA, primaryMatrixB);

            for (var yAxis = 0; yAxis < resultingMatrix.GetLength(0); yAxis++)
            {
                for (var xAxis = 0; xAxis < resultingMatrix.GetLength(1); xAxis++)
                {
                    Console.Write(resultingMatrix[yAxis, xAxis] + " ");
                }

                Console.WriteLine();
            }
        }

        //Merges two matrix into one 
        private static double[,] Merge(double[,] matrixA, double[,] matrixB)
        {
            //Assures that the resulting matrix will be square
            if (matrixA.GetLength(1) != matrixB.GetLength(0))
            {
                throw new Exception("Error!");
            }

            //Gives the number of columns in the first matrix
            var columnsAmount = matrixA.GetLength(1);

            //Creates matrix with the amount of columns from the 
            //first matrix and the amount of rows from the second one
            var resultingMatrix = new double[matrixA.GetLength(0), matrixB.GetLength(1)];

            //New matrix row iterator => iterates 1 row 
            for (var yAxis = 0; yAxis < resultingMatrix.GetLength(0); yAxis++)
            {
                for (var xAxis = 0; xAxis < resultingMatrix.GetLength(1); xAxis++)
                {
                    //Proper name for 'c' ???
                    for (var c = 0; c < columnsAmount; c++)
                    {
                        resultingMatrix[yAxis, xAxis] += matrixA[yAxis, c]*matrixB[c, xAxis];
                    }
                }
            }

            return resultingMatrix;
        }
    }
}