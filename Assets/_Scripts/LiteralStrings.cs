using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LiteralStrings
{
    public static List<string> firstNames;
    public static List<string> lastNames;
    public static List<string> quotes;

    public static void SetupLists()
    {
        SetupNames();
        SetupQuotes();
    }

    public static string GetRandomName()
    {
        int chosenFirstIndex = Random.Range(0, firstNames.Count);
        int chosenLastIndex = Random.Range(0, lastNames.Count);

        string chosenName = firstNames[chosenFirstIndex] + " " + lastNames[chosenLastIndex];

        if (GameManager.instance.tutorial == false)
        {
            firstNames.RemoveAt(chosenFirstIndex);
            lastNames.RemoveAt(chosenLastIndex);
        }

        return chosenName;
    }

    public static string GetRandomQuote()
    {
        int chosenIndex = Random.Range(0, quotes.Count);
        string chosenQuote = quotes[chosenIndex];

        if (GameManager.instance.tutorial == false)
        {
            quotes.RemoveAt(chosenIndex);
        }

        return chosenQuote;
    }

    private static void SetupNames()
    {
        SetupFirstNames();
        SetupLastNames();
    }

    private static void SetupFirstNames()
    {
        firstNames = new List<string>();

        firstNames.Add("Stephen");
        firstNames.Add("Andrew");
        firstNames.Add("Jared");
    }

    private static void SetupLastNames()
    {
        lastNames = new List<string>();

        lastNames.Add("Rogers");
        lastNames.Add("Smith");
        lastNames.Add("Astley");
    }

    private static void SetupQuotes()
    {
        quotes = new List<string>();

        quotes.Add("I'm stackin' paper like Jenga!");
        quotes.Add("Obviously that's the right option...");
        quotes.Add("If there is no gap between the stall, there will be no fun");
    }
}
