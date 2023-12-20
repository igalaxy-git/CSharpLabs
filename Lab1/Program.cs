using CSharpLabs;

var l1 = new Lab1();

var tryParseN = uint.TryParse(Console.ReadLine(), out var N);
while (!tryParseN)
    tryParseN = uint.TryParse(Console.ReadLine(), out N);

int[] array = l1.InitArray((int) N);
l1.PrintArray(array);
Console.WriteLine(l1.FindAbsMaxIndex(array));
Console.WriteLine(l1.FindSumAfterFirstPositive(array));

var tryParseA = int.TryParse(Console.ReadLine(), out var a);
while (!tryParseA)
    tryParseA = int.TryParse(Console.ReadLine(), out a);
var tryParseB = int.TryParse(Console.ReadLine(), out var b);
while (!tryParseB)
    tryParseB = int.TryParse(Console.ReadLine(), out b);
array = l1.RearrangeArray(a, b, array);
l1.PrintArray(array);