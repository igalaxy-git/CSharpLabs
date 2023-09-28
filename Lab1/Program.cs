﻿// Вариант 11
// В одномерном массиве, состоящем из N вещественных элементов, вычислить:
// номер максимального по модулю элемента массива
// сумму элементов массива, расположенных после первого положительного элемента.
// Преобразовать массив таким образом, чтобы сначала располагались все элементы, целая часть которых лежит в интервале [а, b], а потом — все остальные.

Random rnd = new Random();
int N = Convert.ToInt32(Console.ReadLine());
int[] array = new int[N];
int absMax = 0;
int absMaxIndex = 0;
int sum = 0;
bool isItPositive = false;

for (int i = 0; i < N; i++)
{
    array[i] = rnd.Next(-10, 10);
    Console.Write(array[i] + " ");
    if (Math.Abs(array[i]) > absMax)
    {
        absMax = Math.Abs(array[i]);
        absMaxIndex = i;
    }

    if (isItPositive)
    {
        sum += array[i];
    }

    if (array[i] > 0)
    {
        isItPositive = true;
    }
}
Console.WriteLine();
Console.WriteLine(absMaxIndex);
Console.WriteLine(sum);