using System;
using System.Collections.Generic;

class Repository<T>
{
    public delegate bool Criteria<T>(T item);

    private List<T> elements = new List<T>();

    public void Add(T item)
    {
        elements.Add(item);
    }

    public List<T> Find(Criteria<T> criteria)
    {
        List<T> results = new List<T>();

        foreach (T item in elements)
        {
            if (criteria(item))
            {
                results.Add(item);
            }
        }

        return results;
    }
}

class Program
{
    static void Main()
    {
        Repository<int> intRepository = new Repository<int>();

        intRepository.Add(1);
        intRepository.Add(2);
        intRepository.Add(3);
        intRepository.Add(4);
        intRepository.Add(5);

        // Find all even numbers
        Repository<int>.Criteria<int> evenCriteria = x => x % 2 == 0;
        List<int> evenNumbers = intRepository.Find(evenCriteria);

        Console.WriteLine("Even Numbers:");
        foreach (int number in evenNumbers)
        {
            Console.WriteLine(number);
        }

        Repository<string> stringRepository = new Repository<string>();

        stringRepository.Add("apple");
        stringRepository.Add("banana");
        stringRepository.Add("cherry");
        stringRepository.Add("date");

        // Find all strings with length greater than 5
        Repository<string>.Criteria<string> lengthCriteria = s => s.Length > 5;
        List<string> longStrings = stringRepository.Find(lengthCriteria);

        Console.WriteLine("Strings with Length > 5:");
        foreach (string str in longStrings)
        {
            Console.WriteLine(str);
        }
    }
}
