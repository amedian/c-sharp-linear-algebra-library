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

            return new Matrix(product, m1.rowLength, m2.columnLength);
        }

        /// <summary>
        /// Multiplies each element in the current [n x m] matrix with the corresponding element in the provided M2 [n x m] matrix. 
        /// Returns the product [n x m] matrix.
        /// </summary>
        /// <remarks>
        /// This method is not the standard linear algebra matrix multiply method.
        /// </remarks>
        /// <example>
        /// [10 20 30]   [ 1  2  3]   [1*10 2*20 3*30]   [ 10  40  90]
        /// [40 50 60] * [ 4  5  6] = [4*40 5*50 6*60] = [160 250 360]
        /// </example>
        public Matrix ElementwiseMultiply(Matrix m2)
        {
            AssertSizeMatch(this, m2);

            float[,] product = new float[this.rowLength, this.columnLength];
            for (int rowIndex = 0; rowIndex < this.rowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < this.columnLength; columnIndex++)
                {
                    product[rowIndex, columnIndex] = this.elements[rowIndex, columnIndex] * m2.elements[rowIndex, columnIndex];
                }
            }

            return new Matrix(product, this.rowLength, this.columnLength);
        }
    }
}
