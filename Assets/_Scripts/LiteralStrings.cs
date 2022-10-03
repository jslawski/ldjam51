using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LiteralStrings
{
    public static List<string> names;
    public static List<string> quotes;

    //private static List<string> chosenNames;
    //private static List<string> chosenQuotes;

    public static void SetupLists()
    {
        SetupNames();
        SetupQuotes();
    }

    public static string GetRandomName()
    {
        int chosenIndex = Random.Range(0, names.Count);
        string chosenName = names[chosenIndex];
        names.RemoveAt(chosenIndex);

        return chosenName;
    }

    public static string GetRandomQuote()
    {
        int chosenIndex = Random.Range(0, quotes.Count);
        string chosenQuote = quotes[chosenIndex];
        quotes.RemoveAt(chosenIndex);

        return chosenQuote;
    }

    private static void SetupNames()
    {
        names = new List<string>();
        //chosenNames = new List<string>();

        names.Add("Stephen Rudd");
        names.Add("Andrew Rudd");
        names.Add("Jared Slawski");
    }

    private static void SetupQuotes()
    {
        quotes = new List<string>();
        //chosenQuotes = new List<string>();

        quotes.Add("I'm stackin' paper like Jenga!");
        quotes.Add("Obviously that's the right option...");
        quotes.Add("If there is no gap between the stall, there will be no fun");
    }
}
