using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab1_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            const int cols = 4;
            const int rows = 5;
            int[,] matrix = new int[rows, cols];

            Random random = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(-10, 10);
                }
            }

            PtintMatrix(matrix);
            OrderRowsByNumberOfSameValues(matrix);
            SearchFirstNumberOfColWithNegValue(matrix);
        }

        //метод для вывода значений массива на экран
        static void PtintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void OrderRowsByNumberOfSameValues(int[,] matrix)
        {
            List<int> t = new List<int>(matrix.GetLength(1)); //временный лист для сортировки
            int countSameNumber = 0; //количество одинаковых чисел в строке
            List<MyList> helpList = new List<MyList>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    t.Add(matrix[i, j]);
                }
                countSameNumber = matrix.GetLength(1) - t.Distinct().Count();
                helpList.Add(new MyList(countSameNumber, t.ToList()));
                t.Clear();
            }

            helpList = helpList.OrderBy(number => number.CountSameNumbers).ToList();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(helpList[i].List[j] + " ");
                }
                Console.WriteLine($"    ({helpList[i].CountSameNumbers} одинаковых элементов)");
            }
            Console.WriteLine();
        }

        //поиск первого столбца, где нет отрицательных элементов
        public static void SearchFirstNumberOfColWithNegValue(int[,] matrix)
        {
            int countNegValues = 0;
            int number = -1;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, i] < 0)
                    {
                        countNegValues++;
                        break;
                    }
                }

                if (countNegValues == 0)
                {
                    number = i;
                    break;
                }
                countNegValues = 0;
            }
            if (number == 3)
            {
                Console.WriteLine("Столбцов, не содержащих отрицательные элементы, нет.");
            }
            else
            {
                Console.WriteLine($"Номер первого столбца, где нет отрицательных элементов {number+1}");
            }
            Console.WriteLine();
        }
    }
}