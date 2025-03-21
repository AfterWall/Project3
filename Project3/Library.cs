using System;
using System.Collections.Generic;
using System.Linq;

public class Library<T> : IMediaManager<T> where T : Media
{
    private List<T> items = new List<T>();
    private Dictionary<string, T> itemDictionary = new Dictionary<string, T>();

    public void Add(T item)
    {
        if (itemDictionary.ContainsKey(item.Title))
        {
            throw new Exception("Элемент с таким названием существует");
        }
        items.Add(item);
        itemDictionary[item.Title] = item;
    }

    public T FindByTitle(string title)
    {
        var item = items.FirstOrDefault(i => i.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        return item;
    }

    public bool Remove(string title)
    {
        if (!itemDictionary.ContainsKey(title)) return false;
        var item = itemDictionary[title];
        items.Remove(item);
        itemDictionary.Remove(title);
        return true;
    }

    public IEnumerable<T> FilterByYear(int year)
    {
        return items.Where(item => item.YearPublished == year);
    }

    public IEnumerable<T> GetAllAvailable()
    {
        return items.Where(item => item.IsAvailable);
    }

    public void PrintAll()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public void CheckOut(string title)
    {
        var item = FindByTitle(title);
        if (!item.IsAvailable)
        {
            throw new Exception("Элемент выдан");
        }
        item.IsAvailable = false;
    }

    public void Return(string title)
    {
        var item = FindByTitle(title);
        item.IsAvailable = true;
    }
}