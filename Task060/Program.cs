/*Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, 
которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
*/
Console.Clear();
int GetDataFromUser(string msg, string value)
{
    ColorizeText(msg, ConsoleColor.White);
    int variable = 0;
    if (int.TryParse(Console.ReadLine()!, out variable) && variable > 0)
        return variable;
    else
    {
        ColorizeText("Введено недопустимое значение", ConsoleColor.DarkRed);
        Console.WriteLine();
        return variable = GetDataFromUser($"Введите повторно количество {value} (число должно быть целочисленным и больше нуля): ", value);
    }
}
void ColorizeText(string msg, ConsoleColor Color)
{
    Console.ForegroundColor = Color;
    Console.Write(msg);
    Console.ResetColor();
}
int[,,] GenerateMatrix(int rows, int columns, int layer, int start, int end)
{
    int[,,] matrix = new int[rows,columns,layer];
    int[] array = new int[90];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            int k = 0;
            while (k < layer)
            {
                int value = new Random().Next(start, end);
                if (array[value -10] == 0)
                {
                    matrix[i,j,k] = value;
                    array[value -10] = 1;
                    k++;
                }
            }
        }        
    }
    return matrix;
}
void ShowResult(int[,,] matrix)
{
    for (int k = 0; k < matrix.GetLength(2); k++)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                ColorizeText($"{matrix[i,j,k]}({i},{j},{k})" + "\t", ConsoleColor.White);
            }
            Console.WriteLine();
        }  
    }
    Console.WriteLine();
}
ColorizeText("Введите размерность трехмерной матрицы", ConsoleColor.DarkBlue);
Console.WriteLine();
int rowLength = GetDataFromUser("Количество строк: ", "строк");
int columnLength = GetDataFromUser("Количество столбцов: ", "столбцов");
int layerLength = GetDataFromUser("Количество слоев: ", "слоев");
Console.WriteLine();
if (rowLength * columnLength * layerLength <= 90)
{
    int[,,] matrix3D = GenerateMatrix(rowLength, columnLength, layerLength, 10, 100);
    ColorizeText("Матрица 3D", ConsoleColor.DarkYellow);
    Console.WriteLine();
    ShowResult(matrix3D);
}
else
    ColorizeText("Матрицу 3D, из неповторяющихся двузначных чисел, не получиться сформировать. Слишком большая размерность матрицы.", ConsoleColor.DarkRed);



