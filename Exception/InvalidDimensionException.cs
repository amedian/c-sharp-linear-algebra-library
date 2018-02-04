using SystemException = System.Exception;

namespace Amedian.LinearAlgebra.Exception
{
    class InvalidDimensionException : SystemException
    {
        public InvalidDimensionException(string message) : base(message)
        {
        }
    }
}
