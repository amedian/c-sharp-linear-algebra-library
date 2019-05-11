using Amedian.LinearAlgebra.Exception;
using System;

namespace Amedian.LinearAlgebra
{
    /// <remarks>
    /// Defined operators:
    /// ~M       : transposes M matrix
    /// M1 + M2  : Adds M1 to M2
    /// M1 - M2  : Subtracts M2 from M1
    /// S * M    : Multiplies M matrix with S scalar
    /// M * S    : Multiplies M matrix with S scalar
    /// M * F    : Multiplies M matrix with a rowIndex + columnIndex based F function
    /// F * M    : Multiplies M matrix with a rowIndex + columnIndex based F function
    /// M + S    : Adds S scalar to M matrix
    /// S + M    : Adds S scalar to M matrix
    /// M1 * M2  : Multiplies M1 matrix with M2 matrix
    /// M1 == M2 : Returns true if all of the corresponding values are matching within Double.Epsilon
    /// M1 != M2 : Returns false if any of the corresponding values are not matching within Double.Epsilon
    /// </remarks>
    /// <example>
    /// Usage:
    /// Matrix m = new Matrix(new float[2, 3] { {1f, 2f, 3f}, {4f, 5f, 6f} });
    /// System.Console.WriteLine(m);
    ///  
    /// Output:
    /// [1 2 3]
    /// [4 5 6]
    /// </example>
    public partial class Matrix
    {
        protected const string ERROR_MINIMUM_REQUIREMENTS = "Minimum dimension requirement [1 x 1]. [{0} x {1}] given.";
        protected const string ERROR_ROW_DIMENSION_MISSMATCH = "Row dimension missmatch: {0} <> {1}.";
        protected const string ERROR_COLUMN_DIMENSION_MISSMATCH = "Column dimension missmatch: {0} <> {1}.";
        protected const string ERROR_MULTIPLY_DIMENSION_MISSMATCH = "Multiplicand's column dimension does not match multiplier's row dimension: {0} <> {1}.";

        /// <summary>
        /// First index is interpreted as the row index of the matrix, starting at 0.
        /// Second index is interpreted as the column index of the matrix, starting at 0.
        /// </summary>
        protected float[,] elements;

        protected int rowLength;
        protected int columnLength;
        protected int hashCode = 0;

        /// <summary>
        /// Initialises a 2D matrix with the float values.
        /// The matrix' dimension has to be at least [1 x 1].
        /// </summary>
        /// <remarks>
        /// Provided values are cloned and the proveded reference is omitted in the further process.
        /// </remarks>
        public Matrix(float[,] elements)
        {
            this.rowLength = elements.GetLength(0);
            this.columnLength = elements.GetLength(1);
            if (this.rowLength < 1 || this.columnLength < 1)
            {
                throw new InvalidDimensionException(string.Format(ERROR_MINIMUM_REQUIREMENTS, this.rowLength, this.columnLength));
            }

            this.elements = new float[this.rowLength, this.columnLength];
            Buffer.BlockCopy(elements, 0, this.elements, 0, elements.Length * sizeof(float));
        }

        /// <summary>
        /// Creates a matrix and initialises with the given arguments without any business logic.
        /// </summary>
        /// <remarks>
        /// Protected, input check free, clone free constructor for efficiency reasons.
        /// Use it with caution (the public constructor's requirements have to be provided manually).
        /// </remarks>
        protected Matrix(float[,] elements, int rowLength, int columnLength)
        {
            this.elements = elements;
            this.rowLength = rowLength;
            this.columnLength = columnLength;
        }

        /// <summary>
        /// HashCode is not implemented due YAGNI.
        /// </summary>
        public override int GetHashCode()
        {
            return this.hashCode;
        }

        /// <summary>
        /// Displays the 2D <seealso cref="Matrix"/> as a multiple line string.
        /// </summary>
        public override string ToString()
        {
            string s = "";
            for(int row = 0; row < this.rowLength; row++)
            {
                s += "[ ";
                for (int column = 0; column < this.columnLength; column++)
                {
                    s += this.elements[row, column] + " ";
                }
                s += "]" + Environment.NewLine;
            }

            return s;
        }

        public int GetColumnLength()
        {
            return this.columnLength;
        }

        public int GetRowLength()
        {
            return this.rowLength;
        }

        public float Get(int rowIndex, int columnIndex)
        {
            return this.elements[rowIndex, columnIndex];
        }

        public void Set(int rowIndex, int columnIndex, float newValue)
        {
            this.elements[rowIndex, columnIndex] = newValue;
        }

        /// <summary>
        /// Asserts if the given M1 and M2 matricies have the exactly same row and column counts.
        /// </summary>
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

        /// <summary>
        /// Asserts if the given M1 and M2 matricies have the apropiate row and column sizes compared to matrix multiply rules.
        /// </summary>
        /// <see cref="https://en.wikipedia.org/wiki/Matrix_multiplication"/>
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
