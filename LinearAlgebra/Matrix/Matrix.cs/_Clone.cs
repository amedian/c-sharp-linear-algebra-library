using System;

namespace Amedian.LinearAlgebra
{
    partial class Matrix
    {
        /// <summary>
        /// Returns with a deep copy of the current matrix.
        /// </summary>
        public Matrix Clone()
        {
            float[,] cloned = new float[this.rowLength, this.columnLength];
            Buffer.BlockCopy(this.elements, 0, cloned, 0, this.elements.Length * sizeof(float));

            return new Matrix(cloned, this.rowLength, this.columnLength);
        }
    }
}
