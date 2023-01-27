/* Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
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
int[,] MultiplyOfMatrices(int[,] matrix1, int[,] matrix2)
{
    int[,] matrix = new int[matrix1.GetLength(0),matrix2.GetLength(1)];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int sum = 0;
            for (int k = 0; k < matrix1.GetLength(1); k++)
            {
                sum += matrix1[i,k] * matrix2[k,j];
            }
            matrix[i,j] = sum;
        }
    }
    return matrix;
}
int[,] dimensionOfMatrices = new int[2,2];
for (int i = 0; i < 2; i++)
{
    ColorizeText($"Введите размерность матрицы {i + 1}", ConsoleColor.DarkBlue);
    Console.WriteLine();
    dimensionOfMatrices[i,0] = GetDataFromUser("Количество строк: ", "строк");
    dimensionOfMatrices[i,1] = GetDataFromUser("Количество столбцов: ", "столбцов");    
}
if (dimensionOfMatrices[0,1] == dimensionOfMatrices[1,0])
{
    int[,] matrixFirst = GenerateMatrix(dimensionOfMatrices[0,0], dimensionOfMatrices[0,1], 5);
    ColorizeText("\t" + "Первая матрица", ConsoleColor.DarkBlue);
    Console.WriteLine();
    PrintMatrix(matrixFirst);
    int[,] matrixSecond = GenerateMatrix(dimensionOfMatrices[1,0], dimensionOfMatrices[1,1], 5);
    ColorizeText("\t" + "Вторая матрица", ConsoleColor.DarkBlue);
    Console.WriteLine();
    PrintMatrix(matrixSecond);
    int[,] matrixThird = MultiplyOfMatrices(matrixFirst, matrixSecond);
    ColorizeText("\t" + "Результат умножения первой матрица на вторую матрицу", ConsoleColor.DarkBlue);
    Console.WriteLine();
    PrintMatrix(matrixThird);  
}
else
{
    ColorizeText($"Первую матрицу [{dimensionOfMatrices[0,0]},{dimensionOfMatrices[0,1]}] нельзя умножить на вторую матрицу [{dimensionOfMatrices[1,0]},{dimensionOfMatrices[1,1]}].", ConsoleColor.DarkRed);
    Console.WriteLine();
    ColorizeText("Количество столбцов первой матрицы не равно количеству строк второй матрицы.", ConsoleColor.DarkRed);
    Console.WriteLine();
}