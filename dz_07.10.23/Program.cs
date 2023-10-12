using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_07._10._23
{
    internal class Program
    {
        //6.2
        /// <summary>
        /// метод создает массив из целочисленных элементов
        /// </summary>
        /// <param name="array"></param>
        static void CreateArray(int[,] array) 
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    bool flag = false;
                    int n = 0;

                    while (!flag)
                    {
                        Console.Write($"Введите значение для элемента в формате целого числа [{i}, {j}]: ");
                        string input = Console.ReadLine();

                        flag = int.TryParse(input, out n);

                        if (!flag)
                        {
                            Console.WriteLine("Вы ввели не целое число! Попробуйте еще раз!");
                        }
                    }
                    array[i, j] = n;
                }
            }
        }
        /// <summary>
        /// метод выводит массив на консоль
        /// </summary>
        /// <param name="array"></param>
        static void PrintArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// метод умножает 2 массива друг на друга
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        static int[,] MultiplyArray(int[,] array1, int[,] array2) 
        {
            int[,] result = new int[array1.GetLength(0), array2.GetLength(1)];

            for (int i = 0; i < array1.GetLength(0); i++)
            {
                for (int j = 0; j < array2.GetLength(1); j++)
                {
                    int nn = 0;

                    for (int k = 0; k < array2.GetLength(0); k++)
                    {
                        nn += array1[i, k] * array2[k, j];
                    }

                    result[i, j] = nn;
                }
            }
            return result;
        }
        //6.3 
        /// <summary>
        /// генерирует температуры за год ежедневно через двумерный массив (месяц, день)
        /// </summary>
        /// <returns></returns>
        static int[,] TemperatureArrayGeneretic()
        {
            Random random = new Random();
            int[,] temperature = new int[12, 30];

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    temperature[i, j] = random.Next(-20, 35);
                }
            }

            return temperature;
        }
        /// <summary>
        /// вычисляет среднюю температуру за месяц
        /// </summary>
        /// <param name="temperature"></param>
        /// <returns></returns>
        static double[] AverageTemperatures(int[,] temperature)
        {
            double[] averageTemperatures = new double[12];

            for (int i = 0; i < 12; i++)
            {
                double sum = 0;

                for (int j = 0; j < 30; j++)
                {
                    sum += temperature[i, j];
                }

                averageTemperatures[i] = sum / 30;
            }

            return averageTemperatures;
        }
        static void Main(string[] args)
        {
            //6.2
            Console.WriteLine("Написать программу, реализующую умножению двух матриц, заданных в\r\nвиде двумерного массива. В программе предусмотреть два метода: метод печати матрицы,\r\nметод умножения матриц (на вход две матрицы, возвращаемое значение – матрица).");
            Console.WriteLine("Прежде чем перемножить массивы, их необходимо создать. Сделаем первый массив.");
            Console.WriteLine("Введите кол-во столбцов матрицы (натуральное число): ");
            bool resultArr1 = int.TryParse(Console.ReadLine(), out int b);
            Console.WriteLine("Введите кол-во строк матрицы (натуральное число): ");
            bool resultArr2 = int.TryParse(Console.ReadLine(),out int a);
            /*
            if (resultArr1 && resultArr2 ) 
            {
                if (a > 0 && b > 0)
                {
                    int[,] myArray = new int[a, b];
                    CreateArray(myArray);
                    PrintArray(myArray);
                }
                else
                {
                    Console.WriteLine("Вы ввели не натуральное число!");
                }
            }
            else 
            {
                Console.WriteLine("Вы ввели не число!");
            }
            */
            Console.WriteLine("Создадим второй массив.");
            Console.WriteLine("Введите кол-во столбцов матрицы (натуральное число): ");
            bool resultArr1_ = int.TryParse(Console.ReadLine(), out int k);
            Console.WriteLine("Введите кол-во строк матрицы (натуральное число и заметьте, что для умножения количество столбцов первого \nмассива должно быть равно количеству строк второго массива!): ");
            bool resultArr2_ = int.TryParse(Console.ReadLine(), out int l);
            if (resultArr1_ && resultArr2_)
            {
                if (k > 0 && l > 0)
                {
                    int[,] myArray2 = new int[k, l];
                    Console.WriteLine("Второй массив: ");
                    CreateArray(myArray2);
                    PrintArray(myArray2);
                    if (resultArr1 && resultArr2)
                    {
                        if (a > 0 && b > 0)
                        {
                            int[,] myArray1 = new int[a, b];
                            Console.WriteLine("Первый массив: ");
                            CreateArray(myArray1);
                            PrintArray(myArray1);
                            if (a == l)
                            {
                                int[,] Result = MultiplyArray(myArray1, myArray2);
                                Console.WriteLine("В результате мы получаем: ");    
                                PrintArray(Result);
                            }
                            else
                            {
                                Console.WriteLine("Невозможно умножить массивы. Количество столбцов первого массива должно быть равно \nколичеству строк второго массива.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели не натуральное число!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели не число!");
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели не натуральное число!");
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число!");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
            // 6.3
            Console.WriteLine("Написать программу, вычисляющую среднюю температуру за год. Создать\r\nдвумерный рандомный массив temperature[12,30], в котором будет храниться температура\r\nдля каждого дня месяца (предполагается, что в каждом месяце 30 дней). Сгенерировать\r\nзначения температур случайным образом. Для каждого месяца распечатать среднюю\r\nтемпературу. Для этого написать метод, который по массиву temperature [12,30] для каждого\r\nмесяца вычисляет среднюю температуру в нем, и в качестве результата возвращает массив\r\nсредних температур. Полученный массив средних температур отсортировать по\r\nвозрастанию");
            int[,] temperature = TemperatureArrayGeneretic();
            double[] averageTemperatures = AverageTemperatures(temperature);
            Array.Sort(averageTemperatures);

            for (int i = 0; i < averageTemperatures.Length; i++)
            {
                Console.WriteLine("Средняя температура в месяце {0}: {1}", i + 1, averageTemperatures[i]);
            }
        }
    }
}
