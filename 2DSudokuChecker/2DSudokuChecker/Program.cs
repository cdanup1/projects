using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DSudokuChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] partialSudoku = new int[9, 9]
            { {0, 2, 6, 0, 0, 0, 8, 1, 0},
              {3, 0, 0, 7, 0, 8, 0, 0, 6},
              {4, 0, 0, 0, 5, 0, 0, 0, 7},
              {0, 5, 0, 1, 0, 7, 0, 9, 0},
              {0, 0, 3, 9, 0, 5, 1, 0, 0},
              {0, 4, 0, 3, 0, 2, 0, 5, 0},
              {1, 0, 0, 0, 3, 0, 0, 0, 2},
              {5, 0, 0, 2, 0, 4, 0, 0, 9},
              {0, 3, 8, 0, 0, 0, 4, 6, 0} };

            bool isValid = checkSudoku(ref partialSudoku);
            Console.WriteLine("Sudoku is valid: " + isValid);
        }
        private static bool checkSudoku(ref int[,] partialSudoku)
        {
            //Check each row
            for (int i = 0; i < partialSudoku.GetLength(0); i++)
            {
                String row = String.Empty;
                for (int j = 0; j < partialSudoku.GetLength(1); j++)
                {
                    if (row.Contains(partialSudoku[i, j].ToString()))
                        return false;

                    if (partialSudoku[i, j] > 0)
                        row += partialSudoku[i, j].ToString();
                }
            }

            //Check each column
            for (int i = 0; i < partialSudoku.GetLength(0); i++)
            {
                String column = String.Empty;
                for (int j = 0; j < partialSudoku.GetLength(1); j++)
                {
                    if (column.Contains(partialSudoku[j, i].ToString()))
                        return false;

                    if (partialSudoku[j, i] > 0)
                        column += partialSudoku[j, i].ToString();
                }
            }

            //Check each 3x3 region
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    String region = String.Empty;
                    for (int a = 0; a < 3; a++)
                    {
                        for (int b = 0; b < 3; b++)
                        {
                            if (region.Contains(partialSudoku[i * 3 + a, j * 3 + b].ToString()))
                                return false;

                            if (partialSudoku[i * 3 + a, j * 3 + b] > 0)
                                region += partialSudoku[i * 3 + a, j * 3 + b].ToString();
                        }
                    }
                }
            }

            return true;
        }
    }
}
