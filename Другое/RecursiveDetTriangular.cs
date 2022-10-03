using System;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        //создаём
        int r = 4;
        double[,] Matrix = new double[r, r];

        //заполняем случайными числами от 0 до 100
        Random random = new Random();
        double rand;
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < r; j++)
            {
                rand = random.Next(0, 10);
                Matrix[i, j] = rand;
            }
        }

        //Выводим матрицу на экран
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < r; j++)
            {
                Console.Write(Matrix[i, j] + "\t");
            }
            Console.WriteLine("\n");
        }

        Console.WriteLine(CalculateTriangularMatrixRecursive(Matrix));
    }

    static public double CalculateTriangularMatrixRecursive(double[,] squareMatrix)
    {
        int n = squareMatrix.GetLength(0);
        if (n == 1)
            return squareMatrix[0, 0]; // Get the last element from diagonal
        else
        {
            double[,] newMass = new double[n - 1, n - 1];
            bool rowsAreSwapped = false;
            for (int row = 1; row < n; row++)
            {
                // Check whether first elem is 0.
                // Catching division by zero.
                if (squareMatrix[0, 0] == 0)
                {
                    for (int rowIndexer = 1; rowIndexer < n; rowIndexer++)
                    {
                        if (squareMatrix[rowIndexer, 0] != 0)
                        {
                            // Swap rows code
                            for (int columnIndexer = 0; columnIndexer < n; columnIndexer++)
                            {
                                double temp = squareMatrix[rowIndexer, columnIndexer];
                                squareMatrix[rowIndexer, columnIndexer] = squareMatrix[0, columnIndexer];
                                squareMatrix[0, columnIndexer] = temp;
                            }
                            rowsAreSwapped = true;
                            break;
                        }
                    }
                    // Column consists only zeroes
                    if (rowsAreSwapped == false)
                        return 0;
                }
                // If row starts with zero - skip the row
                if (squareMatrix[row, 0] != 0)
                {
                    double multiplier = squareMatrix[row, 0] / squareMatrix[0, 0];
                    for (int col = 0; col < n; col++)
                    {
                        squareMatrix[row, col] = squareMatrix[row, col] - squareMatrix[0, col] * multiplier;
                        if (col != 0)
                            newMass[row - 1, col - 1] = squareMatrix[row, col];
                    }
                }
                // Copy elements to new array if first elem in row = 0
                else
                {
                    for (int col = 1; col < n; col++)
                    {
                        newMass[row - 1, col - 1] = squareMatrix[row, col];
                    }
                }
            }
            Console.WriteLine("//////////////////////////");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(squareMatrix[i, j] + "\t");
                }
                Console.WriteLine("\r\n");
            }
            Console.WriteLine("///////////////////////////");
            return rowsAreSwapped == true ? -1 * squareMatrix[0, 0] * CalculateTriangularMatrixRecursive(newMass) : squareMatrix[0, 0] * CalculateTriangularMatrixRecursive(newMass);
        }
    }


}