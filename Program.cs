/*
Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки 
двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2

void SortRows(int[,]array){
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int g = 0; g < array.GetLength(1) - 1; g++) // третий цикл нужен для того чтобы отсортировать строчные элементы массива
            {
                if (array[i, g] < array[i, g + 1])
                {
                    int temp = array[i, g + 1];
                    array[i, g + 1] = array[i, g];
                    array[i, g] = temp;
                }
            }
        }
    }
}
*/




/*
Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей 
суммой элементов.

Например, задан массив:

1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
*/
/*

void SortRows(int[,]array){
    int minRow = 0;
    int minSumRow = 0;
    int sumRow = 0;
    for (int i = 0; i < array.GetLength(1); i++)
    {
        minRow += array[0, i];
    }
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++) sumRow += array[i, j];
        if (sumRow < minRow)
        {
            minRow = sumRow;
            minSumRow = i;
        }
        sumRow = 0;
    }
    Console.Write($" Минимальная сумма элементов находится в {minSumRow + 1} строке");
}
*/


/*
Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/
int h = 4;  // данный метод подходит только для массива 4х4
void SortRows(int[,]array, int h){          
    int i = 0, j = 0;
    int value = 1;
    for (int a = 0; a < h * h; a++)
    {
        int g = 0;
        do { array[i, j++] = value++; } while (++g < h - 1);  // заполняет строки пока счетчик(g) меньше размера сетки
        for (g = 0; g < h - 1; g++) array[i++, j] = value++;  // цикл заполняет сначала 1 строку
        for (g = 0; g < h - 1; g++) array[i, j--] = value++;  // затем спускается вниз по столбцу
        for (g = 0; g < h - 1; g++) array[i--, j] = value++;  // затем идет справа на лево по строке до конца сетки
        ++i; ++j;
        h = h < 2 ? 0 : h - 2;
    }
}










//// _________________________БЛОК ВСПОМОГАТЕЛЬНЫХ МЕТОДОВ

int[,] CreateRandom2dArray(int rows, int cols,int min, int max){
    int[,] array = new int[rows, cols];
    for (int i = 0; i < rows; i++)
        for (int j = 0; j < cols; j++)
            array[i,j] = new Random().Next(min, max + 1);
    return array;           }   

void Show2dArray(int[,] array){
    for(int i = 0; i<array.GetLength(0); i++){
        for(int j = 0; j<array.GetLength(1); j++){
            Console.Write(array[i,j]+ " ");
        }
        Console.WriteLine();
    }
}


Console.Write("Input numb of rows: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Input numb of cols: ");
int cols = Convert.ToInt32(Console.ReadLine());
Console.Write("Input min numb: ");
int min = Convert.ToInt32(Console.ReadLine());
Console.Write("Input max numb: ");
int max = Convert.ToInt32(Console.ReadLine());

int[,]array = CreateRandom2dArray(rows,cols,min,max);

Console.WriteLine("Изначальный массив : ");
Show2dArray(array);

Console.WriteLine();
SortRows(array,h);

Console.WriteLine("Массив заполненный спиралью : ");
Show2dArray(array);



