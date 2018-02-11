namespace Amedian.LinearAlgebra
{
    partial class Matrix
    {
        /**
         * Multiplies each M1 [n x m] matrix value with the provided scalar.
         * Returns the product [n x m] matrix.
         * 
         * @see https://en.wikipedia.org/wiki/Scalar_multiplication
         * 
         * @example
         * 
         * Input:
         *     [1 2 3]
         * 2 * [4 5 6] * 2
         *     [7 8 9]
         * 
         * Output:
         * [ 4  8 12]
         * [16 20 24]
         * [28 32 36]
         */
        public static Matrix operator *(float f, Matrix m1)
        {
            float[,] product = new float[m1.rowLength, m1.columnLength];
            for (int rowIndex = 0; rowIndex < m1.rowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < m1.columnLength; columnIndex++)
                {
                    product[rowIndex, columnIndex] = m1.elements[rowIndex, columnIndex] * f;
                }
            }

            return new Matrix(product);
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
