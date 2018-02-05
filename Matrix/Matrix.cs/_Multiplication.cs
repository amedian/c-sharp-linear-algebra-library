namespace Amedian.LinearAlgebra
{
    partial class Matrix
    {
        /**
         * Multiplies M1 [n x m] matrix with M2 [m x k] matrix.
         * Returns the result [n x k] matrix.
         * 
         * @see https://en.wikipedia.org/wiki/Matrix_multiplication
         * 
         * @example
         *          [ 1,  2,  3]
         *          [ 4,  5,  6]
         * 
         * [1, 2]   [ 9, 12, 15]
         * [3, 4]   [19, 26, 33]
         */
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            AssertMultiplySizeMatch(m1, m2);

            float[,] result = new float[m1.rowLength, m2.columnLength];
            for (int row = 0; row < m1.rowLength; row++)
            {
                for (int col = 0; col < m2.columnLength; col++)
                {
                    result[row, col] = 0;
                    for (int inner = 0; inner < m1.columnLength; inner++)
                    {
                        result[row, col] += m1.elements[row, inner] * m2.elements[inner, col];
                    }
                }
            }

            return new Matrix(result);
        }
    }
}
