namespace Amedian.LinearAlgebra
{
    public interface IMatrixFunction
    {
        /// <summary>
        /// Applies a function on a given matrix element.
        /// </summary>
        float Calculate(float element);
    }
}
