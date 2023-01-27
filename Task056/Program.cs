/*Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, 
которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
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
int[] GetSumElementInRow(int[,] matrix)
{
    int[] sumElement = new int[matrix.GetLength(0)];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sum += matrix[i,j];
        }
        sumElement[i] = sum;       
    }
    return sumElement;
}
void PrintArray(int[] array)
{    
    for (int i = 0; i < array.Length; i++)
    {
        ColorizeText($"#{i} |" + "\t", ConsoleColor.DarkYellow);
        if (array[i] < 0)
            ColorizeText($"{array[i]}", ConsoleColor.White);
        else                
            ColorizeText($" {array[i]}", ConsoleColor.White);
        Console.WriteLine();
    }
    Console.WriteLine();
}
void ShowMinimumSumRow(int[] array)
{
    int minimumSum = array[0];
    string indexMinimum = "0";
    bool key = false;
    for (int i = 1; i < array.Length; i++)
    {
        if (minimumSum > array[i])
        {
            indexMinimum = string.Empty;
            minimumSum = array[i];
            indexMinimum = Convert.ToString(i);
            key = false;
        }
        else if (minimumSum == array[i])
            {
                indexMinimum += ", " + Convert.ToString(i);
                key = true;
            }
    }
    if (key)
        ColorizeText($"Номера строк с наименьшей суммой элементов: {indexMinimum}", ConsoleColor.DarkGreen);
    else
        ColorizeText($"Номер строки с наименьшей суммой элементов: {indexMinimum}", ConsoleColor.DarkGreen);
    Console.WriteLine();  
}
ColorizeText("Введите размерность матрицы", ConsoleColor.DarkBlue);
Console.WriteLine();
int rowLength = GetDataFromUser("Количество строк: ", "строк");
int columnLength = GetDataFromUser("Количество столбцов: ", "столбцов");
int[,] randomMatrix = GenerateMatrix(rowLength, columnLength, 1);
PrintMatrix(randomMatrix);
int[] sumRow = GetSumElementInRow(randomMatrix);
ColorizeText("Сумма элементов матрицы в каждой строке", ConsoleColor.DarkBlue);
Console.WriteLine();
PrintArray(sumRow);
ShowMinimumSumRow(sumRow);