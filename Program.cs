using LinearAlgebraCalculator.Models;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Matrix and Vector Operations CLI!");
        Console.WriteLine("Enter commands to perform operations, or 'quit' to exit.");
        Console.WriteLine("'help' for a list of commands.");

        while (true)
        {
            Console.Write("> ");
            string? command = Console.ReadLine();

            if (command == "quit")
            {
                break;
            }
            
            if (command == "help")
            {
                Console.WriteLine("Commands:" +
                                  "\nadd" +
                                  "\nmultiply" +
                                  "\nsubtract" +
                                  "\ndot" +
                                  "\ncross" +
                                  "\ndeterminant" +
                                  "\ninverse" +
                                  "\ntranspose");
            }
            
            try
            {
                if (command == "add")
                {
                    Console.WriteLine("Enter the dimensions of the matrices (rows columns):");
                    string? input = Console.ReadLine();
                    if (input == null)
                    {
                        throw new ArgumentException("Invalid input.");
                    }
                    string[] dimensions = input.Split(' ');
                    int rows = int.Parse(dimensions[0]);
                    int cols = int.Parse(dimensions[1]);
                    Matrix m1 = new Matrix(rows, cols);
                    Matrix m2 = new Matrix(rows, cols);
                    Console.WriteLine("Enter the elements of the first matrix:");
                    m1.Read();
                    Console.WriteLine("Enter the elements of the second matrix:");
                    m2.Read();
                    Matrix result = m1.MatrixAddition(m2);
                    Console.WriteLine("Result:");
                    result.Print();
                }
                else if (command == "multiply")
                {
                    Console.WriteLine("Enter the dimensions of the matrices (rows columns):");
                    string? input = Console.ReadLine();
                    if (input == null)
                    {
                        throw new ArgumentException("Invalid input.");
                    }
                    string[] dimensions = input.Split(' ');
                    int rows1 = int.Parse(dimensions[0]);
                    int cols1 = int.Parse(dimensions[1]);
                    int rows2 = int.Parse(dimensions[1]);
                    int cols2 = int.Parse(dimensions[2]);
                    Matrix m1 = new Matrix(rows1, cols1);
                    Matrix m2 = new Matrix(rows2, cols2);
                    Console.WriteLine("Enter the elements of the first matrix:");
                    m1.Read();
                    Console.WriteLine("Enter the elements of the second matrix:");
                    m2.Read();
                    Matrix result = m1.MatrixMultiplication(m2);
                    Console.WriteLine("Result:");
                    result.Print();
                }
                else if (command == "subtract")
                {
                    Console.WriteLine("Enter the dimensions of the matrices (rows columns):");
                    string? input = Console.ReadLine();
                    if (input == null)
                    {
                        throw new ArgumentException("Invalid input.");
                    }
                    string[] dimensions = input.Split(' ');
                    int rows = int.Parse(dimensions[0]);
                    int cols = int.Parse(dimensions[1]);
                    Matrix m1 = new Matrix(rows, cols);
                    Matrix m2 = new Matrix(rows, cols);
                    Console.WriteLine("Enter the elements of the first matrix:");
                    m1.Read();
                    Console.WriteLine("Enter the elements of the second matrix:");
                    m2.Read();
                    Matrix result = m1.MatrixSubtraction(m2);
                    Console.WriteLine("Result:");
                    result.Print();
                }
                else if (command == "dot")
                {
                    Console.WriteLine("Enter the dimensions of the vectors:");
                    string? input = Console.ReadLine();
                    if (input == null)
                    {
                        throw new ArgumentException("Invalid input.");
                    }
                    int size = int.Parse(input);
                    Vector v1 = new Vector(size);
                    Vector v2 = new Vector(size);
                    Console.WriteLine("Enter the elements of the first vector:");
                }
                else if (command == "cross")
                {
                    Console.WriteLine("Enter the elements of the first vector:");
                    string? input = Console.ReadLine();
                    if (input == null)
                    {
                        throw new ArgumentException("Invalid input.");
                    }
                    double[] data1 = input.Split(' ').Select(double.Parse).ToArray();
                    Vector v1 = new Vector(data1);
                    Console.WriteLine("Enter the elements of the second vector:");
                    string? input2 = Console.ReadLine();
                    if (input2 == null)
                    {
                        throw new ArgumentException("Invalid input.");
                    }
                    double[] data2 = input2.Split(' ').Select(double.Parse).ToArray();
                    Vector v2 = new Vector(data2);
                    Vector result = v1.CrossProduct(v2);
                    Console.WriteLine("Result:");
                    result.Print();
                }
                else if (command == "determinant")
                {
                    Console.WriteLine("Enter the dimensions of the matrix (rows columns):");
                    string? input = Console.ReadLine();
                    if (input == null)
                    {
                        throw new ArgumentException("Invalid input.");
                    }
                    string[] dimensions = input.Split(' ');
                    int cols = int.Parse(dimensions[1]);
                    int rows = int.Parse(dimensions[0]);
                    Matrix m = new Matrix(rows, cols);
                    Console.WriteLine("Enter the elements of the matrix:");
                    m.Read();
                    double result = m.Determinant();
                    Console.WriteLine("Result: " + result);
                }
                else if (command == "inverse")
                {
                    Console.WriteLine("Enter the dimensions of the matrix (rows columns):");
                    string? input = Console.ReadLine();
                    if (input == null)
                    {
                        throw new ArgumentException("Invalid input.");
                    }
                    string[] dimensions = input.Split(' ');
                    int rows = int.Parse(dimensions[0]);
                    int cols = int.Parse(dimensions[1]);
                    Matrix m = new Matrix(rows, cols);
                    Console.WriteLine("Enter the elements of the matrix:");
                    m.Read();
                    Matrix result = m.Inverse();
                    Console.WriteLine("Result:");
                    result.Print();
                }
                else if (command == "transpose")
                {
                    Console.WriteLine("Enter the dimensions of the matrix (rows columns):");
                    string? input = Console.ReadLine();
                    if (input == null)
                    {
                        throw new ArgumentException("Invalid input.");
                    }
                    string[] dimensions = input.Split(' ');
                    int rows = int.Parse(dimensions[0]);
                    int cols = int.Parse(dimensions[1]);
                    Matrix m = new Matrix(rows, cols);
                    Console.WriteLine("Enter the elements of the matrix:");
                    m.Read();
                }

                else
                {
                    Console.WriteLine("Invalid command. Type 'help' for a list of commands.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}