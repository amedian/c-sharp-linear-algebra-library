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
         * [1 2]
         * [3 4]
         * 
         * f(x) = 2 * x + 1
         * 
         * Output:
         * [3 5]
         * [7 9]
         */
        public Matrix Apply(IMatrixFunction f)
        {
            float[,] result = new float[rowLength, columnLength];
            for (int rowIndex = 0; rowIndex < rowLength; rowIndex++)
            {
                for (int colIndex = 0; colIndex < columnLength; colIndex++)
                {
                    result[rowIndex, colIndex] = f.Calculate(elements[rowIndex, colIndex]);
                }
            }

            return new Matrix(result);
        }
    }
}
