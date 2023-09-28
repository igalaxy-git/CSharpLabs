// Вариант 11
// В одномерном массиве, состоящем из N вещественных элементов, вычислить:
// номер максимального по модулю элемента массива
// сумму элементов массива, расположенных после первого положительного элемента.
// Преобразовать массив таким образом, чтобы сначала располагались все элементы, целая часть которых лежит в интервале [а, b], а потом — все остальные.

Random rnd = new Random();
var tryParseN = int.TryParse(Console.ReadLine(), out var N);
while (!tryParseN)
    tryParseN = int.TryParse(Console.ReadLine(), out N);
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
        sum += array[i];

    if (array[i] > 0)
        isItPositive = true;
}
Console.WriteLine();
Console.WriteLine(absMaxIndex);
Console.WriteLine(sum);


var tryParseA = int.TryParse(Console.ReadLine(), out var a);
while (!tryParseA)
    tryParseA = int.TryParse(Console.ReadLine(), out a);

var tryParseB = int.TryParse(Console.ReadLine(), out var b);
while (!tryParseB)
    tryParseB = int.TryParse(Console.ReadLine(), out b);
int[] AB = new int[N];
int[] notAB = new int[N];
int firstIndex = 0;
int secondIndex = 0;
for (int i = 0; i < N; i++)
{
    if (array[i] >= a && array[i] <= b)
        AB[firstIndex++] = array[i];
    else
        notAB[secondIndex++] = array[i];
}
AB = AB.Take(firstIndex).ToArray();
notAB = notAB.Take(secondIndex).ToArray();
array = AB.Concat(notAB).ToArray();
for (int i = 0; i < N; i++)
    Console.Write(array[i] + " ");
