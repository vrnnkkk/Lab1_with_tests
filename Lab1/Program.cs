using System;

namespace Lab1
{
    public class Program
    {
        static void Main(string[] args)
        {
            const int N = 10;
            float[] array = new float[N];
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (float)(random.Next(-1000, 1000) * 0.1);
            }

            PtintArray(array);

            Console.WriteLine("Количество отрицательных эл-ов: " + NegCount(array));
            Console.WriteLine("Сумма модулей элементов массива, расположенных после минимального по модулю элемента: " + SumAfterMinAbs(array));
        }


        //метод для вывода значений массива на экран
        static void PtintArray(float[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        //метод для вычисления количества отрицательных элементов в массиве
        public static int NegCount(float[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    count += 1;
                }
            }

            return count;
        }

        //метод для вычисления суммы модулей элемента массива, расположенных после минимального по модулю элемента
        public static float SumAfterMinAbs(float[] array)
        {
            float sum = 0;
            int index = IndexOfMinAbs(array) + 1;
            while (index < array.Length)
            {
                sum += Math.Abs(array[index]);
                index++;
            }

            return sum;
        }

        //метод для поиска индекса минимального по модулю элемента в массиве
        public static int IndexOfMinAbs(float[] array)
        {
            float minAbs = Math.Abs(array[0]);
            int c = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (Math.Abs(array[i]) < minAbs)
                {
                    minAbs = Math.Abs(array[i]);
                    c = i;
                }
            }

            return c;
        }
    }
}