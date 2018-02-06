using SystemException = System.Exception;

namespace Amedian.LinearAlgebra.Exception
{
    class ArgumentDimensionMissmatchException : SystemException
    {
        protected Matrix m1;
        protected Matrix m2;

        public ArgumentDimensionMissmatchException(string message, Matrix m1, Matrix m2) : base(message)
        {
            this.m1 = m1;
            this.m2 = m2;
        }
    }
}
