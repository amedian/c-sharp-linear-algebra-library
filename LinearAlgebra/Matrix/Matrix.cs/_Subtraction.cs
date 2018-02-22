namespace Amedian.LinearAlgebra
{
    partial class Matrix
    {
        /// <summary>
        /// Substracts the provided M2 [n x m] matrix from the provided M1 [n x m] matrix and returns the difference [n x m] matrix.
        /// </summary>
        /// <see cref="https://en.wikipedia.org/wiki/Matrix_addition"/>
        /// <example>
        /// Input:
        /// [1 2 3]   [4 15 13]
        /// [4 5 6] - [2 -8 -7]
        /// [7 8 9]   [2 10 -9]
        /// 
        /// Output:
        /// [-3 -13 -10]
        /// [ 2  13  13]
        /// [ 5  -2  18]
        /// 
        /// </example>
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            AssertSizeMatch(m1, m2);

            float[,] difference = new float[m1.rowLength, m1.columnLength];
            for (int rowIndex = 0; rowIndex < m1.rowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < m1.columnLength; columnIndex++)
                {
                    difference[rowIndex, columnIndex] = m1.elements[rowIndex, columnIndex] - m2.elements[rowIndex, columnIndex];
                }
            }

            return new Matrix(difference, m1.rowLength, m1.columnLength);
        }

        /// <summary>
        /// Substracts each element in the provided [n x m] matrix from the provided float value.
        /// </summary>
        /// <remarks>
        /// Returns an [n x m] reference independent matrix.
        /// </remarks>
        /// <example>
        /// Input:
        ///     [1 2 3]
        /// 9 - [4 5 6]
        ///     [7 8 9]
        /// 
        /// Output:
        /// [8 7 6]
        /// [5 4 3]
        /// [2 1 0]
        /// </example>
        public static Matrix operator -(float f, Matrix m1)
        {
            float[,] difference = new float[m1.rowLength, m1.columnLength];
            for (int rowIndex = 0; rowIndex < m1.rowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < m1.columnLength; columnIndex++)
                {
                    difference[rowIndex, columnIndex] = f - m1.elements[rowIndex, columnIndex];
                }
            }

            return new Matrix(difference, m1.rowLength, m1.columnLength);
        }

        /// <summary>
        /// Substracts the provided float value from each element in the provided M1 [n x m] matrix.
        /// Returns the difference [n x m] matrix.
        /// </summary>
        /// <remarks>
        /// Returns an [n x m] reference independent matrix.
        /// </remarks>
        /// <example>
        /// Input:
        /// [1 2 3]
        /// [4 5 6] - 1
        /// [7 8 9]
        /// 
        /// Output:
        /// [0 1 2]
        /// [3 4 5]
        /// [6 7 8]
        /// </example>
        public static Matrix operator -(Matrix m1, float f)
        {
            float[,] difference = new float[m1.rowLength, m1.columnLength];
            for (int rowIndex = 0; rowIndex < m1.rowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < m1.columnLength; columnIndex++)
                {
                    difference[rowIndex, columnIndex] = m1.elements[rowIndex, columnIndex] - f;
                }
            }

            return new Matrix(difference, m1.rowLength, m1.columnLength);
        }
    }
}
