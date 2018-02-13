namespace Amedian.LinearAlgebra
{
    partial class Matrix
    {
        /// <summary>
        /// Applies the provided matrix function on each element. Returns the newly calculated matrix.
        /// </summary>
        /// <example>
        /// Input:
        /// [1 2]
        /// [3 4]
        /// 
        /// f(x) = 2 * x + 1
        /// 
        /// Output:
        /// [3 5]
        /// [7 9]
        /// </example>
        public Matrix Apply(IMatrixFunction f)
        {
            float[,] result = new float[rowLength, columnLength];
            for (int rowIndex = 0; rowIndex < rowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnLength; columnIndex++)
                {
                    result[rowIndex, columnIndex] = f.Calculate(elements[rowIndex, columnIndex]);
                }
            }

            return new Matrix(result, rowLength, columnLength);
        }
    }
}
