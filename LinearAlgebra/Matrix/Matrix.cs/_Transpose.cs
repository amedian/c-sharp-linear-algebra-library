namespace Amedian.LinearAlgebra
{
    partial class Matrix
    {
        /**
         * Transposes the given [n x m] matrix and returns a transposed [m x n] matrix.
         * 
         * @see https://en.wikipedia.org/wiki/Transpose
         * 
         * @example
         * 
         * Input:
         * [1 2 3]
         * [4 5 6]
         * 
         * Output:
         * [1 4]
         * [2 5]
         * [3 6]
         */
        public static Matrix operator ~(Matrix m1)
        {
            float[,] transposedElements = new float[m1.columnLength, m1.rowLength];
            for (int rowIndex = 0; rowIndex < m1.rowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < m1.columnLength; columnIndex++)
                {
                    transposedElements[columnIndex, rowIndex] = m1.elements[rowIndex, columnIndex];
                }
            }

            return new Matrix(transposedElements);
        }
    }
}
