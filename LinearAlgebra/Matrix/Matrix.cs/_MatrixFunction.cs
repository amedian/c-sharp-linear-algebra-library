namespace Amedian.LinearAlgebra
{
    partial class Matrix
    {
        /// <summary>
        /// Applies the provided matrix function on each element of the provided M [n x m] matirx.
        /// Returns the calculated [n x m] matrix.
        /// </summary>
        /// <example>
        /// Input:
        /// [1 2]
        /// [3 4]
        /// 
        /// f(x) = 2 * x + 1 (for all rowIndex and columnIndex)
        /// 
        /// Output:
        /// [3 5]
        /// [7 9]
        /// </example>
        /// <remarks>
        /// This operation is not a linear algebra standard.
        /// </remarks>
        public static Matrix operator *(Matrix m, IMatrixFunction function)
        {
            float[,] result = new float[m.rowLength, m.columnLength];
            for (int rowIndex = 0; rowIndex < m.rowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < m.columnLength; columnIndex++)
                {
                    result[rowIndex, columnIndex] = function.Calculate(rowIndex, columnIndex, m.elements[rowIndex, columnIndex]);
                }
            }

            return new Matrix(result, m.rowLength, m.columnLength);
        }

        /// <summary>
        /// <seealso cref="Matrix.operator*(Matrix,IMatrixFunction)"/>
        /// </summary>
        public static Matrix operator *(IMatrixFunction function, Matrix m)
        {
            return m * function;
        }
    }
}
