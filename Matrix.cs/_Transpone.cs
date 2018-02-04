namespace Amedian.LinearAlgebra
{
    partial class Matrix
    {
        /**
         * Transposes given matrix.
         * 
         * @example https://en.wikipedia.org/wiki/Transpose
         * 
         * @example
         * 
         * Input:
         * [1, 2, 3]
         * [4, 5, 6]
         * 
         * Output:
         * [1, 4]
         * [2, 5]
         * [3, 6]
         */
        public static Matrix operator !(Matrix m1)
        {
            float[,] result = new float[m1.columnLength, m1.rowLength];
            for (int row = 0; row < m1.rowLength; row++)
            {
                for (int col = 0; col < m1.columnLength; col++)
                {
                    result[col, row] = m1.elements[row, col];
                }
            }

            return new Matrix(result);
        }
    }
}
