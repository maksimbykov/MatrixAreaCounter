using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the matrix string:");
        string input = Console.ReadLine();

        int result = CountAreasOfOnes(input);
        Console.WriteLine("Number of areas formed by 1: " + result);
    }

    static int CountAreasOfOnes(string matrixString)
    {
        // Convert the input string to a matrix
        int[][] matrix = ConvertToMatrix(matrixString);

        // Initialize variables to keep track of visited positions
        bool[][] visited = new bool[matrix.Length][];
        for (int i = 0; i < matrix.Length; i++)
        {
            visited[i] = new bool[matrix[i].Length];
        }

        // Initialize the count of areas
        int count = 0;

        // Iterate through the matrix
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                // If the current position contains 1 and is not visited, explore the area
                if (matrix[i][j] == 1 && !visited[i][j])
                {
                    ExploreArea(matrix, visited, i, j);
                    count++;
                }
            }
        }

        return count;
    }

    static void ExploreArea(int[][] matrix, bool[][] visited, int row, int col)
    {
        // Check boundaries and whether the position is already visited
        if (row < 0 || row >= matrix.Length || col < 0 || col >= matrix[row].Length || visited[row][col] || matrix[row][col] == 0)
        {
            return;
        }

        // Mark the current position as visited
        visited[row][col] = true;

        // Explore neighbour positions
        ExploreArea(matrix, visited, row + 1, col); // Down
        ExploreArea(matrix, visited, row - 1, col); // Up
        ExploreArea(matrix, visited, row, col + 1); // Right
        ExploreArea(matrix, visited, row, col - 1); // Left
    }

    static int[][] ConvertToMatrix(string matrixString)
    {
        string[] rows = matrixString.Split(';');
        int numRows = rows.Length;

        int[][] matrix = new int[numRows][];
        for (int i = 0; i < numRows; i++)
        {
            string[] columns = rows[i].Split(',');
            matrix[i] = new int[columns.Length];

            for (int j = 0; j < columns.Length; j++)
            {
                matrix[i][j] = int.Parse(columns[j]);
            }
        }

        return matrix;
    }
}
