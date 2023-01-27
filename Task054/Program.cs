/*Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит 
по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
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
int[,] GenerateMatrix(int rows, int columns, int deviation)
{
    int[,] matrix = new int[rows,columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i,j] = new Random().Next(-deviation, deviation + 1);
        }        
    }
    return matrix;
}
void PrintMatrix(int[,] matrix)
{
    Console.Write("\t");
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        ColorizeText($" #{j}" + "\t", ConsoleColor.DarkYellow);
    }
    Console.WriteLine();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        ColorizeText($"#{i} |" + "\t", ConsoleColor.DarkYellow);
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i,j] < 0)
                ColorizeText(matrix[i,j] + "\t", ConsoleColor.White);
            else                
                ColorizeText($" {matrix[i,j]}" + "\t", ConsoleColor.White);
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}
int[,] ChangeElementsInMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int maximumElement = matrix[i,j];
            int indexMaximum = j;
            for (int k = j + 1; k < matrix.GetLength(1); k++)
            {
                if (matrix[i,k] > maximumElement)
                {
                    maximumElement = matrix[i,k];
                    indexMaximum = k;
                }
            }
            if (indexMaximum != j)
            {
                int temp = matrix[i,j];
                matrix[i,j] = matrix[i,indexMaximum];
                matrix[i,indexMaximum] = temp;
            }
        }
    }
    return matrix;
}
ColorizeText("Введите размерность матрицы", ConsoleColor.DarkBlue);
Console.WriteLine();
int rowLength = GetDataFromUser("Количество строк: ", "строк");
int columnLength = GetDataFromUser("Количество столбцов: ", "столбцов");
int[,] randomMatrix = GenerateMatrix(rowLength, columnLength, 20);
PrintMatrix(randomMatrix);
int[,] swapMatrix = ChangeElementsInMatrix(randomMatrix);
ColorizeText("Элементы каждой строки матрицы, упорядочены по убыванию", ConsoleColor.DarkBlue);
Console.WriteLine();
PrintMatrix(swapMatrix);