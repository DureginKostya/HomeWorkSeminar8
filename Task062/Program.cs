/*Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
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
int[,] GetSpiralMatrix(int rows, int columns)
{
    int[,] matrix = new int[rows,columns];
    int i = 0;
    int j = 0;
    int count = 0;
    bool right = true;
    bool down = false;
    bool left = false;
    bool up = false;
    while (count < rows*columns)
    {
        if (right)
        {
            if (j < columns && matrix[i,j] == 0)
            {
                count++;
                matrix[i,j] = count;
                j++;
            }
            else
            {
                right = false;
                down = true;
                j--;
                i++;
            }
        }
        if (down)
        {
            if (i < rows && matrix[i,j] == 0)
            {
                count++;
                matrix[i,j] = count;
                i++;
            }
            else
            {
                down = false;
                left = true;
                i--;
                j--;
            }
        }
        if (left)
        {
            if (j >= 0 && matrix[i,j] == 0)
            {
                count++;
                matrix[i,j] = count;
                j--;
            }
            else
            {
                left = false;
                up = true;
                j++;
                i--;
            }
        }
        if (up)
        {
            if (i >= 0 && matrix[i,j] == 0)
            {
                count++;
                matrix[i,j] = count;
                i--;
            }
            else
            {
                up = false;
                right = true;
                i++;
                j++;
            }
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
ColorizeText("Введите размерность матрицы", ConsoleColor.DarkBlue);
Console.WriteLine();
int rowLength = GetDataFromUser("Количество строк: ", "строк");
int columnLength = GetDataFromUser("Количество столбцов: ", "столбцов");
int[,] spiralMatrix = GetSpiralMatrix(rowLength, columnLength);
PrintMatrix(spiralMatrix);
