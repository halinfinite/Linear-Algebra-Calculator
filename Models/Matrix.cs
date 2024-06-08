namespace LinearAlgebraCalculator.Models
{
    public class Matrix
    {
        public int Rows { get; set; }
        public int Cols { get; set; }
        public double[,] Data { get; set; }

        // Matrix constructor:
        public Matrix(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            Data = new double[rows, cols];
        }

        public Matrix MatrixAddition(Matrix m)
        {
            if (Rows != m.Rows || Cols != m.Cols)
            {
                throw new ArgumentException("Matrices must be the same size for addition.");
            }

            Matrix result = new Matrix(Rows, Cols);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    result.Data[i, j] = Data[i, j] + m.Data[i, j];
                }
            }
            return result;
        }

        public Matrix MatrixSubtraction(Matrix m)
        {
            if (Rows != m.Rows || Cols != m.Cols)
            {
                throw new ArgumentException("Matrices must be the same size for subtraction.");
            }

            Matrix result = new Matrix(Rows, Cols);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    result.Data[i, j] = Data[i, j] - m.Data[i, j];
                }
            }
            return result;
        }

        public Matrix MatrixMultiplication(Matrix m)
        {
            if (Cols != m.Rows)
            {
                throw new ArgumentException("Number of columns in first matrix must match number of rows in second matrix for multiplication.");
            }

            Matrix result = new Matrix(Rows, m.Cols);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < m.Cols; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < Cols; k++)
                    {
                        sum += Data[i, k] * m.Data[k, j];
                    }
                    result.Data[i, j] = sum;
                }
            }
            return result;
        }

        public Matrix Transpose()
        {
            Matrix result = new Matrix(Cols, Rows);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    result.Data[j, i] = Data[i, j];
                }
            }
            return result;
        }

        public double Cofactor(int row, int col)
        {
            if (Rows != Cols)
            {
                throw new ArgumentException("Matrix must be square to calculate cofactor.");
            }

            double[,] minorData = new double[Rows - 1, Cols - 1];
            int m = 0;
            for (int i = 0; i < Rows; i++)
            {
                if (i == row)
                {
                    continue;
                }
                int n = 0;
                for (int j = 0; j < Cols; j++)
                {
                    if (j == col)
                    {
                        continue;
                    }
                    minorData[m, n] = Data[i, j];
                    n++;
                }
                m++;
            }

            Matrix minor = new Matrix(Rows - 1, Cols - 1);
            minor.Data = minorData;
            return minor.Determinant();
        }
        
        public double Determinant()
        {
            if (Rows != Cols)
            {
                throw new ArgumentException("Matrix must be square to calculate determinant.");
            }

            if (Rows == 2)
            {
                return Data[0, 0] * Data[1, 1] - Data[0, 1] * Data[1, 0];
            }

            double result = 0;
            for (int i = 0; i < Rows; i++)
            {
                result += Data[0, i] * Cofactor(0, i);
            }
            return result;
        }

        public Matrix Inverse()
        {
            if (Rows != Cols)
            {
                throw new ArgumentException("Matrix must be square to calculate inverse.");
            }

            double det = Determinant();
            if (det == 0)
            {
                throw new ArgumentException("Matrix is singular and cannot be inverted.");
            }

            Matrix result = new Matrix(Rows, Cols);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    result.Data[i, j] = Cofactor(j, i) / det;
                }
            }
            return result;
        }
        
        public void Print()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write(Data[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void Read()
        {
            for (int i = 0; i < this.Rows; i++)
            {
                string? input = Console.ReadLine();
                if (input == null)
                {
                    throw new ArgumentException("Invalid input.");
                }
                string[] rowValues = input.Split(' ');
                for (int j = 0; j < this.Cols; j++)
                {
                    Data[i, j] = double.Parse(rowValues[j]);
                }
            }
        }
    }
}

