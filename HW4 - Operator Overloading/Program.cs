using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("=== Завдання 1: Співробітник ===\n");

// Створення співробітників
var emp1 = new Employee("Іван", 50000m);
var emp2 = new Employee("Петро", 55000m);
var emp3 = new Employee("Олексій", 50000m);

Console.WriteLine("Початкові дані:");
Console.WriteLine(emp1);
Console.WriteLine(emp2);
Console.WriteLine(emp3);
Console.WriteLine();

// Оператор +
Console.WriteLine("Оператор + (збільшення зарплати):");
var emp1Increased = emp1 + 5000m;
Console.WriteLine($"{emp1.Name}: {emp1.Salary} + 5000 = {emp1Increased.Salary}");
Console.WriteLine();

// Оператор -
Console.WriteLine("Оператор - (зменшення зарплати):");
var emp2Decreased = emp2 - 3000m;
Console.WriteLine($"{emp2.Name}: {emp2.Salary} - 3000 = {emp2Decreased.Salary}");
Console.WriteLine();

// Оператори порівняння
Console.WriteLine("Оператори порівняння:");
Console.WriteLine($"{emp1.Name} (50000) == {emp3.Name} (50000): {emp1 == emp3}");
Console.WriteLine($"{emp1.Name} (50000) != {emp2.Name} (55000): {emp1 != emp2}");
Console.WriteLine($"{emp1.Name} (50000) < {emp2.Name} (55000): {emp1 < emp2}");
Console.WriteLine($"{emp2.Name} (55000) > {emp1.Name} (50000): {emp2 > emp1}");
Console.WriteLine();

// ============================================================
Console.WriteLine("=== Завдання 2: Місто ===\n");

// Створення міст
var city1 = new City("Київ", 2_900_000);
var city2 = new City("Львів", 721_000);
var city3 = new City("Одеса", 2_900_000);

Console.WriteLine("Початкові дані:");
Console.WriteLine(city1);
Console.WriteLine(city2);
Console.WriteLine(city3);
Console.WriteLine();

// Оператор +
Console.WriteLine("Оператор + (збільшення населення):");
var city1Increased = city1 + 100_000;
Console.WriteLine($"{city1.Name}: {city1.Population:N0} + 100,000 = {city1Increased.Population:N0}");
Console.WriteLine();

// Оператор -
Console.WriteLine("Оператор - (зменшення населення):");
var city2Decreased = city2 - 50_000;
Console.WriteLine($"{city2.Name}: {city2.Population:N0} - 50,000 = {city2Decreased.Population:N0}");
Console.WriteLine();

// Оператори порівняння
Console.WriteLine("Оператори порівняння:");
Console.WriteLine($"{city1.Name} (2,900,000) == {city3.Name} (2,900,000): {city1 == city3}");
Console.WriteLine($"{city1.Name} (2,900,000) != {city2.Name} (721,000): {city1 != city2}");
Console.WriteLine($"{city2.Name} (721,000) < {city1.Name} (2,900,000): {city2 < city1}");
Console.WriteLine($"{city1.Name} (2,900,000) > {city2.Name} (721,000): {city1 > city2}");
Console.WriteLine();

// ============================================================
Console.WriteLine("=== Завдання 3: Кредитна картка ===\n");

// Створення кредитних карток
var card1 = new CreditCard("4532-1234-5678-9010", "123", 5000m);
var card2 = new CreditCard("5555-4444-3333-2222", "456", 3500m);
var card3 = new CreditCard("6011-0009-9013-9424", "123", 8000m);

Console.WriteLine("Початкові дані:");
Console.WriteLine(card1);
Console.WriteLine(card2);
Console.WriteLine(card3);
Console.WriteLine();

// Оператор +
Console.WriteLine("Оператор + (поповнення картки):");
var card1Topped = card1 + 2000m;
Console.WriteLine($"{card1.CardNumber}: {card1.Balance:N2} + 2000 = {card1Topped.Balance:N2}");
Console.WriteLine();

// Оператор -
Console.WriteLine("Оператор - (зняття коштів):");
var card2Withdrawn = card2 - 500m;
Console.WriteLine($"{card2.CardNumber}: {card2.Balance:N2} - 500 = {card2Withdrawn.Balance:N2}");
Console.WriteLine();

// Оператори порівняння
Console.WriteLine("Оператори порівняння:");
Console.WriteLine($"Картка 1 (CVC: 123) == Картка 3 (CVC: 123): {card1 == card3}");
Console.WriteLine($"Картка 1 (CVC: 123) != Картка 2 (CVC: 456): {card1 != card2}");
Console.WriteLine($"Картка 2 (3500) < Картка 1 (5000): {card2 < card1}");
Console.WriteLine($"Картка 3 (8000) > Картка 1 (5000): {card3 > card1}");
Console.WriteLine();

