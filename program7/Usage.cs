using System;

class Program
{
    static void Main()
    {
        SinglyLinkedList list = new SinglyLinkedList();

        Console.WriteLine("Adding elements: 10, 5, 20, 15, 3");
        list.AddAfterFirst(10);
        list.AddAfterFirst(5);
        list.AddAfterFirst(20);
        list.AddAfterFirst(15);
        list.AddAfterFirst(3);

        Console.WriteLine("\nList elements:");
        foreach (int value in list)
        {
            Console.Write(value + " ");
        }

        Console.WriteLine("\n\nElement at index 2: " + list[2]);

        int? firstGreater = list.FindFirstGreaterThan(10);
        Console.WriteLine("\nFirst element greater than 10: " + (firstGreater.HasValue ? firstGreater.Value.ToString() : "Not found"));

        int sumLess = list.SumLessThan(15);
        Console.WriteLine("Sum of elements less than 15: " + sumLess);

        SinglyLinkedList greaterThanList = list.GetElementsGreaterThan(10);
        Console.WriteLine("\nElements greater than 10:");
        foreach (int value in greaterThanList)
        {
            Console.Write(value + " ");
        }

        Console.WriteLine("\n\nRemoving element at index 1");
        list.RemoveAt(1);
        Console.WriteLine("List after removal:");
        foreach (int value in list)
        {
            Console.Write(value + " ");
        }

        Console.WriteLine("\n\nRemoving elements after maximum");
        list.RemoveAfterMax();
        Console.WriteLine("List after removing elements after maximum:");
        foreach (int value in list)
        {
            Console.Write(value + " ");
        }
    }
}
