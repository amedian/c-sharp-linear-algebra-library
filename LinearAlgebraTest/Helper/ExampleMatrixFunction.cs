using Amedian.LinearAlgebra;

namespace Amedian.LinearAlgebraTest.Helper
{
    class ExampleMatrixFunction : IMatrixFunction
    {
        public float Calculate(float element)
        {
            return element * 2 + 1;
        }
    }
}
