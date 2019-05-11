namespace Amedian.LinearAlgebra
{
    partial class Matrix
    {
        /// <summary>
        /// Adds the provided M1 [n x m] matrix to the provided M2 [n x m] matrix and returns the sum [n x m] matrix.
        /// </summary>
        /// <see cref="https://en.wikipedia.org/wiki/Matrix_addition"/>
        /// <example>
        /// Input:
        /// [1 2 3]   [4 15 13]
        /// [4 5 6] + [2 -8 -7]
        /// [7 8 9]   [2 10 -9]
        /// 
        /// Output:
        /// [5 17 16]
        /// [6 -3 -1]
        /// [9 18  0]
        /// </example>
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            AssertSizeMatch(m1, m2);

            float[,] sum = new float[m1.rowLength, m1.columnLength];
            for (int rowIndex = 0; rowIndex < m1.rowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < m1.columnLength; columnIndex++)
                {
                    sum[rowIndex, columnIndex] = m1.elements[rowIndex, columnIndex] + m2.elements[rowIndex, columnIndex];
                }
            }

            return new Matrix(sum, m1.rowLength, m1.columnLength);
        }

        /// <summary>
        /// Adds the provided float value to each element of the provided M1 [n x m] matrix and returns the sum [n x m] matrix.
        /// </summary>
        /// <example>
        /// Input:
        /// [0 1 2]
        /// [3 4 5] + 1
        /// [6 7 8]
        /// 
        /// Output:
        /// [1 2 3]
        /// [4 5 6]
        /// [7 8 9]
        /// </example>
        /// <remarks>
        /// This operation is not a linear algebra standard.
        /// </remarks>
        public static Matrix operator +(float f, Matrix m1)
        {
            float[,] sum = new float[m1.rowLength, m1.columnLength];
            for (int rowIndex = 0; rowIndex < m1.rowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < m1.columnLength; columnIndex++)
                {
                    sum[rowIndex, columnIndex] = m1.elements[rowIndex, columnIndex] + f;
                }
            }

            return new Matrix(sum, m1.rowLength, m1.columnLength);
        }

        /// <summary>
        /// <seealso cref="Matrix.operator +(float,Matrix)"/>
        /// </summary>
        public static Matrix operator +(Matrix m1, float f)
        {
            return f + m1;
        }
    }
}
