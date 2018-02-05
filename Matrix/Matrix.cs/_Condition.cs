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

            for (int row = 0; row < m1.rowLength; row++)
            {
                for (int col = 0; col < m1.columnLength; col++)
                {
                    if (Math.Abs(m1.elements[row, col] - m2.elements[row, col]) > Double.Epsilon)
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
