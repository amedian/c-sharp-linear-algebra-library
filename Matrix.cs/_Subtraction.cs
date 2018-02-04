﻿namespace Amedian.LinearAlgebra
{
    partial class Matrix
    {
        /**
         * Substracts the provided M2 [n x m] matrix from the provided M1 [n x m] matrix and returns the result [n x m] matrix.
         * 
         * @see https://en.wikipedia.org/wiki/Matrix_addition
         * 
         * @example
         * 
         * Input:
         * [1, 2, 3]   [4, 15, 13]
         * [4, 5, 6] - [2, -8, -7]
         * [7, 8, 9]   [2, 10, -9]
         * 
         * Output:
         * [-3, -13, -10]
         * [ 2,  13,  13]
         * [ 5,  -2,  18]
         */
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            AssertSizeMatch(m1, m2);

            float[,] result = new float[m1.rowLength, m1.columnLength];
            for (int row = 0; row < m1.rowLength; row++)
            {
                for (int col = 0; col < m1.columnLength; col++)
                {
                    result[row, col] = m1.elements[row, col] - m2.elements[row, col];
                }
            }

            return new Matrix(result);
        }
    }
}
