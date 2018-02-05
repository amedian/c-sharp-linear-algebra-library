namespace Amedian.LinearAlgebra
{
    partial class Matrix
    {
        /**
         * Applies the provided matrix function on each element. Returns the newly calculated matrix.
         * 
         * @example
         * 
         * Input: 
         * [1, 2]
         * [3, 4]
         * 
         * f(x) = 2 * x + 1
         * 
         * Output:
         * [3, 5]
         * [7, 9]
         */
        public Matrix Apply(IMatrixFunction f)
        {
            float[,] result = new float[rowLength, columnLength];

            for (int row = 0; row < rowLength; row++)
            {
                for (int col = 0; col < columnLength; col++)
                {
                    result[row, col] = f.Calculate(elements[row, col]);
                }
            }

            return new Matrix(result);
        }
    }
}
