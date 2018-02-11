using System;

namespace Amedian.LinearAlgebra
{
    partial class Matrix
    {
        /**
         * Checks if each value within M1 [n x m] matrix matches the corresponding value within the M2 [n x m] matrix
         * under the Double.Epsilon error.
         */
        public static bool operator ==(Matrix m1, Matrix m2)
        {
            AssertSizeMatch(m1, m2);

            for (int rowIndex = 0; rowIndex < m1.rowLength; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < m1.columnLength; columnIndex++)
                {
                    if (Math.Abs(m1.elements[rowIndex, columnIndex] - m2.elements[rowIndex, columnIndex]) > Double.Epsilon)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /**
         * @see Matrix::operator==(Matrix,Matrix)
         */
        public static bool operator !=(Matrix m1, Matrix m2)
        {
            return !(m1 == m2);
        }

        /**
         * @see Matrix::operator==(Matrix,Matrix)
         */
        public override bool Equals(Object obj)
        {
            if (obj.GetType() != typeof(Matrix))
            {
                return false;
            }

            return this == (Matrix)obj;
        }
    }
}
