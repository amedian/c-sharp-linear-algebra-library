namespace Amedian.LinearAlgebra
{
    partial class Matrix
    {
        /**
         * Multiplies each M1 [n x m] matrix value with the provided scalar.
         * Returns the result [n x m] matrix.
         * 
         * @see https://en.wikipedia.org/wiki/Scalar_multiplication
         * 
         * @example
         * 
         * Input:
         *     [1, 2, 3]
         * 2 * [4, 5, 6] * 2
         *     [7, 8, 9]
         * 
         * Output:
         * [ 4,  8, 12]
         * [16, 20, 24]
         * [28, 32, 36]
         */
        public static Matrix operator *(float f, Matrix m1)
        {
            float[,] result = new float[m1.rowLength, m1.columnLength];
            for (int row = 0; row < m1.rowLength; row++)
            {
                for (int col = 0; col < m1.columnLength; col++)
                {
                    result[row, col] = m1.elements[row, col] * f;
                }
            }

            return new Matrix(result);
        }

        /**
         * @see Matrix::operator*(float,Matrix)
         */
        public static Matrix operator *(Matrix m1, float f)
        {
            return f * m1;
        }
    }
}
