namespace Amedian.LinearAlgebra
{
    partial class Matrix
    {
        /// <summary>
        /// Multiplies M1 [n x m] matrix with M2 [m x k] matrix.
        /// Returns the product [n x k] matrix.
        /// </summary>
        /// <see cref="https://en.wikipedia.org/wiki/Matrix_multiplication"/>
        /// <example>
        ///         [ 1  2  3]
        ///         [ 4  5  6]
        ///         
        /// [1 2]   [ 9 12 15]
        /// [3 4]   [19 26 33]
        /// </example>
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            AssertMultiplySizeMatch(m1, m2);

            float[,] product = new float[m1.rowLength, m2.columnLength];
            for (int productRowIndex = 0; productRowIndex < m1.rowLength; productRowIndex++)
            {
                for (int productColumnIndex = 0; productColumnIndex < m2.columnLength; productColumnIndex++)
                {
                    product[productRowIndex, productColumnIndex] = 0;
                    for (int innerIndex = 0; innerIndex < m1.columnLength; innerIndex++)
                    {
                        product[productRowIndex, productColumnIndex] += m1.elements[productRowIndex, innerIndex] * m2.elements[innerIndex, productColumnIndex];
                    }
                }
            }

            return new Matrix(product);
        }
    }
}
