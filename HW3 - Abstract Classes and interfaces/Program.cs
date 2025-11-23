using System;
using System.Text;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("=== Завдання 1: IOutput ===");
        MyArray myArraySample = new MyArray(5);
        myArraySample.Show();
        Console.WriteLine();
        myArraySample.Show("Елементи масиву:");

        Console.WriteLine("\n=== Завдання 2: IMath ===");
        Console.WriteLine($"Max елемент: {myArraySample.Max()}");
        Console.WriteLine($"Min елемент: {myArraySample.Min()}");
        Console.WriteLine($"Середнє значення: {myArraySample.Avg()}");
        Console.WriteLine($"Чи містить 3? {myArraySample.Search(3)}");
        Console.WriteLine($"Чи містить 10? {myArraySample.Search(10)}");

        Console.WriteLine("\n=== Завдання 3: ISort ===");
        
        Console.WriteLine("Оригінальний масив:");
        myArraySample.Show();
        Console.WriteLine("\nПісля сортування за зростанням:");
        myArraySample.SortAscending();
        myArraySample.Show();
        Console.WriteLine("\nПісля сортування за спаданням:");
        myArraySample.SortDescending();
        myArraySample.Show();
    }
}
