// Вариант 11
// В одномерном массиве, состоящем из N вещественных элементов, вычислить:
// номер максимального по модулю элемента массива
// сумму элементов массива, расположенных после первого положительного элемента.
// Преобразовать массив таким образом, чтобы сначала располагались все элементы, целая часть которых лежит в интервале [а, b], а потом — все остальные.

namespace CSharpLabs;

public class Lab1
{
    public void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
            Console.Write(array[i] + " ");
        Console.WriteLine();
    }
    
    public int[] InitArray(int N)
    {
        Random rnd = new Random();
        int[] array = new int[N];
        for (int i = 0; i < N; i++)
            array[i] = rnd.Next(-10, 10);
        
        return array;
    }
    
    public int FindAbsMaxIndex(int[] array)
    {
        int absMax = 0;
        int absMaxIndex = 0;
        for (int i = 0; i < array.Length; i++)
            if (Math.Abs(array[i]) > absMax)
            {
                absMax = Math.Abs(array[i]);
                absMaxIndex = i;
            }
        
        return absMaxIndex;
    }
    
    public int FindSumAfterFirstPositive(int[] array)
    {
        int sum = 0;
        bool isItPositive = false;
        for (int i = 0; i < array.Length; i++)
        {
            if (isItPositive)
                sum += array[i];
            if (array[i] > 0)
                isItPositive = true;
        }
    
        return sum;
    }
    
    public int[] RearrangeArray(int a, int b, int[] array)
    {
        int[] AB = new int[array.Length];
        int[] notAB = new int[array.Length];
        int firstIndex = 0;
        int secondIndex = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] >= a && array[i] <= b)
                AB[firstIndex++] = array[i];
            else
                notAB[secondIndex++] = array[i];
        }
    
        AB = AB.Take(firstIndex).ToArray();
        notAB = notAB.Take(secondIndex).ToArray();
        array = AB.Concat(notAB).ToArray();
        return array;
    }
}