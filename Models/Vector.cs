namespace LinearAlgebraCalculator.Models
{
    public class Vector
    {
        public int Size { get; set; }
        public double[] Data { get; set; }

        public Vector(int size)
        {
            Size = size;
            Data = new double[size];
        }

        public Vector(double[] data)
        {
            Size = data.Length;
            Data = data;
        }

        public Vector VectorAddition(Vector v)
        {
            if (Size != v.Size)
            {
                throw new ArgumentException("Vectors must be the same size for addition.");
            }

            double[] resultData = new double[Size];
            for (int i = 0; i < Size; i++)
            {
                resultData[i] = Data[i] + v.Data[i];
            }
            return new Vector(resultData);
        }

        public Vector VectorSubtraction(Vector v)
        {
            if (Size != v.Size)
            {
                throw new ArgumentException("Vectors must be the same size for subtraction.");
            }

            double[] resultData = new double[Size];
            for (int i = 0; i < Size; i++)
            {
                resultData[i] = Data[i] - v.Data[i];
            }
            return new Vector(resultData);
        }

        public Vector ScalarMultiplication(double scalar)
        {
            double[] resultData = new double[Size];
            for (int i = 0; i < Size; i++)
            {
                resultData[i] = Data[i] * scalar;
            }
            return new Vector(resultData);
        }

        public double DotProduct(Vector v)
        {
            if (Size != v.Size)
            {
                throw new ArgumentException("Vectors must be the same size for dot product.");
            }

            double result = 0;
            for (int i = 0; i < Size; i++)
            {
                result += Data[i] * v.Data[i];
            }
            return result;
        }

        public double Magnitude()
        {
            double result = 0;
            for (int i = 0; i < Size; i++)
            {
                result += Data[i] * Data[i];
            }
            return Math.Sqrt(result);
        }

        public Vector Normalize()
        {
            double magnitude = Magnitude();
            double[] resultData = new double[Size];
            for (int i = 0; i < Size; i++)
            {
                resultData[i] = Data[i] / magnitude;
            }
            return new Vector(resultData);
        }

        public Vector CrossProduct(Vector v)
        {
            if (Size != 3 || v.Size != 3)
            {
                throw new ArgumentException("Both vectors must be three-dimensional for cross product.");
            }

            double[] resultData = new double[3];
            resultData[0] = Data[1] * v.Data[2] - Data[2] * v.Data[1];
            resultData[1] = Data[2] * v.Data[0] - Data[0] * v.Data[2];
            resultData[2] = Data[0] * v.Data[1] - Data[1] * v.Data[0];

            return new Vector(resultData);
        }

        public void Print()
        {
            foreach (var item in Data)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}