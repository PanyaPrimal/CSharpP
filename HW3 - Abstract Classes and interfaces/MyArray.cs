using System;
using System.Linq;

public class MyArray : IOutput, IMath, ISort
{
    private int[] array;
    public MyArray(int size)
    {
        array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = i + 1;
        }
    }

    // Реалізація IOutput
    public void Show()
    {
        Console.WriteLine(string.Join(", ", array));
    }
    public void Show(string info)
    {
        Console.WriteLine(info);
        Show();
    }

    // Реалізація IMath
    public int Max()
    {
        return array.Max();
    }

    public int Min()
    {
        return array.Min();
    }

    public float Avg()
    {
        return (float)(array.Sum() / array.Length);
    }

    public bool Search(int valueToFind)
    {
        return array.Contains(valueToFind);
    }

    // Реалізація ISort
    public void SortAscending()
    {
        Array.Sort(array);
    }

    public void SortDescending()
    {
        Array.Sort(array);
        Array.Reverse(array);
    }
    public void SortByParam(bool isAscending)
    {
        if (isAscending)
        {
            SortAscending();
        }
        else
        {
            SortDescending();
        }
    }
}
