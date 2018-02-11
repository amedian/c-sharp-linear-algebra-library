namespace Amedian.LinearAlgebra
{
    partial class Matrix
    {
        /// <summary>
        /// Returns with a deep copy of the current matrix.
        /// </summary>
        public Matrix Clone()
        {
            return new Matrix((float[,])elements.Clone());
        }
    }
}
