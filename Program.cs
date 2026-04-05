using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;


// Завдання 1: Прийом та відвантаження (Queue & Stack)
Console.WriteLine("Завдання 1: Прийом та відвантаження (Queue & Stack)");
Queue<string> collection_point = new Queue<string>();

collection_point.Enqueue("Яблоко");
collection_point.Enqueue("Груша");
collection_point.Enqueue("Помидор");

Stack<string> Unloading = new Stack<string>();


Console.WriteLine("Загрузка товаров");
while (collection_point.Count > 0)
{
    string Product = collection_point.Dequeue();
    Unloading.Push(Product);
    Console.WriteLine($"  Загружен: {Product}");
}

Console.WriteLine("Выгрузка в обратном порядке");


while (Unloading.Count > 0)
{
    string Product = Unloading.Pop();
    Console.WriteLine($"  Выгружен: {Product}");
}

//Завдання 2: Інвентаризація та пошук (Dictionary & SortedList)
Console.WriteLine("Завдання 2: Інвентаризація та пошук (Dictionary & SortedList)");
Dictionary<int, string> Products = new Dictionary<int, string>();

Products.Add(1231, "Ноутбук");
Products.Add(14351, "Планшет");
Products.Add(1661, "Телефон");

foreach (var Prod in Products)
{
    Console.WriteLine($"Штрих-код: {Prod.Key}, Товар: {Prod.Value}");
}

SortedList<int, string> vipClient = new SortedList<int, string>();

vipClient.Add(1, "Сюпюр Евгений");
vipClient.Add(4, "Хомутенко Андрей");
vipClient.Add(2, "Карпенко Ольга");
vipClient.Add(3, "Буяшенко Владислав");

foreach (var Client in vipClient)
{
    Console.WriteLine($"{Client.Key}  {Client.Value}");
}

//Завдання 3: Історія маніпуляцій (LinkedList)
Console.WriteLine("Завдання 3: Історія маніпуляцій (LinkedList)");
LinkedList<string> manipulations = new LinkedList<string>();

manipulations.AddLast("Прибытие на склад");
manipulations.AddLast("размещение");
manipulations.AddLast("Отправка");

var middle = manipulations.First;
for (int i = 0; i < manipulations.Count / 2; i++)
    middle = middle.Next;

manipulations.AddBefore(middle, "Проверка");

foreach (var m in manipulations)
    Console.WriteLine($"- {m}");

//Завдання 4: Порівняльний аналіз (List vs ArrayList)
Console.WriteLine("Завдання 4: Порівняльний аналіз (List vs ArrayList)");
const int elementsCount = 1_000_000;

        TestCollection("List<int>", () =>
        {
            var list = new List<int>();
            for (int i = 0; i < elementsCount; i++)
                list.Add(i);
            return list;
        });

        TestCollection("ArrayList", () =>
        {
            var arrayList = new ArrayList();
            for (int i = 0; i < elementsCount; i++)
                arrayList.Add(i);
            return arrayList;
        });


    static void TestCollection(string name, Func<object> createCollection)
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        long memoryBefore = GC.GetTotalMemory(true);

        Stopwatch stopwatch = Stopwatch.StartNew();

        object collection = createCollection();

        stopwatch.Stop();

        long memoryAfter = GC.GetTotalMemory(true);
        long memoryUsed = memoryAfter - memoryBefore;

        Console.WriteLine($"{name}:");
        Console.WriteLine($" Время: {stopwatch.ElapsedMilliseconds} мс");
        Console.WriteLine($" Использованная память: {memoryUsed} байт ");
    }
