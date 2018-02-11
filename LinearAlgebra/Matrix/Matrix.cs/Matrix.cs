using Amedian.LinearAlgebra.Exception;
using System;

namespace Amedian.LinearAlgebra
{
    public partial class Matrix
    {
        protected const string ERROR_MINIMUM_REQUIREMENTS = "Minimum dimension requirement [1 x 1]. [{0} x {1}] given.";
        protected const string ERROR_ROW_DIMENSION_MISSMATCH = "Row dimension missmatch: {0} <> {1}.";
        protected const string ERROR_COLUMN_DIMENSION_MISSMATCH = "Column dimension missmatch: {0} <> {1}.";
        protected const string ERROR_MULTIPLY_DIMENSION_MISSMATCH = "Multiplicand's column dimension does not match multiplier's row dimension: {0} <> {1}.";

        /**
         * First index is interpreted as the row index of the matrix, starting at 0.
         * Second index is interpreted as the column index of the matrix, starting at 0.
         */
        protected float[,] elements;

        protected int rowLength;
        protected int columnLength;
        protected int hashCode = 0;

        /**
         * Initialises a 2D matrix with the float values.
         * The matrix' dimension has to be at least [1 x 1].
         * Note: Provided value is cloned and the reference is omitted in the further processing.
         * 
         * Defined operators:
         * ~M       : transposes M matrix
         * M1 + M2  : Adds M1 to M2
         * M1 - M2  : Subtracts M2 from M1
         * S * M    : Multiplies M matrix with S scalar
         * M * S    : Multiplies M matrix with S scalar
         * M1 * M2  : Multiplies M1 matrix with M2 matrix
         * M1 == M2 : Returns true if all of the corresponding values are matching within Double.Epsilon
         * M1 != M2 : Returns false if any of the corresponding values are not matching within Double.Epsilon
         * 
         * @example
         * 
         * Usage:
         * Matrix m = new Matrix(new float[2, 3] { {1f, 2f, 3f}, {4f, 5f, 6f} });
         * System.Console.WriteLine(m);
         * 
         * Output:
         * [1 2 3]
         * [4 5 6]
         */
        public Matrix(float[,] elements)
        {
            rowLength = elements.GetLength(0);
            columnLength = elements.GetLength(1);
            if (rowLength < 1 || columnLength < 1)
            {
                throw new InvalidDimensionException(string.Format(ERROR_MINIMUM_REQUIREMENTS, rowLength, columnLength));
            }
            this.elements = (float[,])elements.Clone();
        }

        /**
         * Note: HashCode is not implemented due YAGNI.
         */
        public override int GetHashCode()
        {
            return hashCode;
        }

        /**
         * Displays the 2D matrix as a multiple line string.
         * 
         * @see Matrix::Matrix()
         */
        public override string ToString()
        {
            string s = "";
            for(int row = 0; row < rowLength; row++)
            {
                s += "[ ";
                for (int column = 0; column < columnLength; column++)
                {
                    s += elements[row, column] + " ";
                }
                s += "]" + Environment.NewLine;
            }

            return s;
        }

        public int GetColumnLength()
        {
            return columnLength;
        }

        public int GetRowLength()
        {
            return rowLength;
        }

        public float Get(int rowIndex, int columnIndex)
        {
            return elements[rowIndex, columnIndex];
        }

        public void Set(int rowIndex, int columnIndex, float newValue)
        {
            elements[rowIndex, columnIndex] = newValue;
        }

        /**
         * @throws ArgumentDimensionMissmatchException
         */
        protected static void AssertSizeMatch(Matrix m1, Matrix m2)
        {
            if (m1.rowLength != m2.rowLength)
            {
                throw new ArgumentDimensionMissmatchException(
                    string.Format(ERROR_ROW_DIMENSION_MISSMATCH, m1.rowLength, m2.rowLength),
                    m1,
                    m2
                );
            }

            if (m1.columnLength != m2.columnLength)
            {
                throw new ArgumentDimensionMissmatchException(
                    string.Format(ERROR_COLUMN_DIMENSION_MISSMATCH, m1.columnLength, m2.columnLength),
                    m1,
                    m2
                );
            }
        }

        /**
         * @throws ArgumentDimensionMissmatchException
         */
        protected static void AssertMultiplySizeMatch(Matrix m1, Matrix m2)
        {
            if (m1.columnLength != m2.rowLength)
            {
                throw new ArgumentDimensionMissmatchException(
                    string.Format(ERROR_MULTIPLY_DIMENSION_MISSMATCH, m1.columnLength, m2.rowLength),
                    m1,
                    m2
                );
            }
        }
    }
}
