int[] StringToArray(string arrayrow, int size)
{
    string[] row = arrayrow.Split(" ", size);
    
    int[] rowarray = new int[size];

    for(int i = 0; i < size; i++)
    {
        while(true)
        {
            if(int.TryParse(row[i], out rowarray[i])) break;
            Console.WriteLine("Неправильно введена строка массива!");
        }
    }

    return rowarray;
}

string ArrayRow(int size, int numberrow)
{
    string[] nameofrow = {"первую", "вторую", "третью", "четвертую", "пятую"};

    if(numberrow < 5)
    {
        Console.Write($"Введите {nameofrow[numberrow]} строку массива (числа через пробел, количество чисел {size}:");
        string row = Console.ReadLine();
        return row;
    }
    else
    {
        Console.Write($"Введите следующую строку массива (числа через пробел, количество чисел {size}:");
        string row = Console.ReadLine();
        return row;
    }
}

int GetSizeColArray()
{
    int size = 0;
    while(true)
    {
        Console.Write("Введите количество столбцов массива:");
        if(int.TryParse(Console.ReadLine(), out size)) break;
        Console.WriteLine("Ошибка ввода!");
    }
    return size;
}

int GetSizeRowArray()
{
    int size = 0;
    while(true)
    {
        Console.Write("Введите количество строк массива:");
        if(int.TryParse(Console.ReadLine(), out size)) break;
        Console.WriteLine("Ошибка ввода!");
    }
    return size;
}

void PrintArray(int[,] arr)
{
    for(int i = 0; i < arr.GetLength(0); i++)
    {
        for(int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write($"{arr[i,j]} ");
        }
        Console.WriteLine();        
        }
}

int[,] ArrMultiply(int[,] arr1, int[,] arr2)
{
    int[,] arrmulti = new int[arr1.GetLength(0), arr2.GetLength(1)];
    Array.Clear(arrmulti);
    int n = arr1.GetLength(1);

    for(int i = 0; i < arrmulti.GetLength(0); i++)
        for(int j = 0; j < arrmulti.GetLength(1); j ++)
        {
            for(int s = 0; s < n; s++)
            arrmulti[i,j] = arrmulti[i,j] + arr1[i,s] * arr2[s,j];
        }
    return arrmulti;
}

/////////



Console.WriteLine("Введите размерность прямоугольного массива.");
int n = GetSizeColArray();
int m = GetSizeRowArray();

Console.WriteLine("Введите количество столбцов массива №2 (количество строк определено количеством столбцов массива №1");
int k = GetSizeColArray();

string strrow1 = string.Empty;
int[] arrrow1 = new int[n];
int[,] arr1 = new int[m, n];

string strrow2 = string.Empty;
int[] arrrow2 = new int[k];
int[,] arr2 = new int[n, k];

Console.WriteLine("Введите первый массив:");
for(int i = 0; i < m; i++)
{
    strrow1 = ArrayRow(n, i);
    arrrow1 = StringToArray(strrow1, n);
    for(int j = 0; j < n; j++)
    {
        arr1[i, j] = arrrow1[j];
    }
}

Console.WriteLine("Введите второй массив:");
for(int i = 0; i < n; i++)
{
    strrow2 = ArrayRow(k, i);
    arrrow2 = StringToArray(strrow2, k);
    for(int j = 0; j < k; j++)
    {
        arr2[i, j] = arrrow2[j];
    }
}

int[,] arrmulti = ArrMultiply(arr1, arr2);


Console.WriteLine("Результат перемножения двух массивов (матриц):")
PrintArray(arrmulti);
