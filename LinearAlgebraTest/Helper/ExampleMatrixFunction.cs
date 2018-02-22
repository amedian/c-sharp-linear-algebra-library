using Amedian.LinearAlgebra;

namespace Amedian.LinearAlgebraTest.Helper
{
    class ExampleMatrixFunction : IMatrixFunction
    {
        public float Calculate(int rowIndex, int columnIndex, float element)
        {
            return rowIndex * 2 + columnIndex + element;
        }
    }
}
