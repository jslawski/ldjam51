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
        firstNames.Add("Billiam");
        firstNames.Add("Jack");
        firstNames.Add("Nancy");
        firstNames.Add("Jethro");
        firstNames.Add("Ed");
        firstNames.Add("Tom");
        firstNames.Add("Dan");
        firstNames.Add("DJ");
        firstNames.Add("Dana");
        firstNames.Add("Theo");
        firstNames.Add("Wendy");
        firstNames.Add("John");
        firstNames.Add("Namiel");
        firstNames.Add("Nathan");
        firstNames.Add("Sabrina");
        firstNames.Add("Dawn");
        firstNames.Add("Evan");
        firstNames.Add("Justin");
        firstNames.Add("Ronny");
        firstNames.Add("Nick");
        firstNames.Add("David");
        firstNames.Add("Zach");
        firstNames.Add("Jerry");
        firstNames.Add("Harry");
        firstNames.Add("Jerg");
        firstNames.Add("Jose");
        firstNames.Add("Yummi");
        firstNames.Add("Gail");
        firstNames.Add("Tinkywinky");
        firstNames.Add("Edgar");
        firstNames.Add("Miles");
        firstNames.Add("Jonah");
        firstNames.Add("Louis");
        firstNames.Add("Lara");
        firstNames.Add("Daisy");
        firstNames.Add("Sheila");
        firstNames.Add("Leslie");
        firstNames.Add("Angela");
        firstNames.Add("Pam");
        firstNames.Add("Emily");
        firstNames.Add("Rose");
        firstNames.Add("Tamara");
        firstNames.Add("Thelma");
        firstNames.Add("Simon");
        firstNames.Add("Rick");
        firstNames.Add("Sam");
        firstNames.Add("Stanley");
        firstNames.Add("Anne");
        firstNames.Add("Maria");
        firstNames.Add("Arnold");
        firstNames.Add("Lauren");
        firstNames.Add("Junior");
        firstNames.Add("Nina");
        firstNames.Add("Hayden");
        firstNames.Add("Oslo");
        firstNames.Add("Ewan");
        firstNames.Add("Racecar");
        firstNames.Add("Serena");
        firstNames.Add("Jamie");
        firstNames.Add("Egg");

    }

    private static void SetupLastNames()
    {
        lastNames = new List<string>();

        lastNames.Add("Rogers");
        lastNames.Add("Smith");
        lastNames.Add("Astley");
        lastNames.Add("Richardson");
        lastNames.Add("Thornton");
        lastNames.Add("Williams");
        lastNames.Add("Hittington");
        lastNames.Add("Davis");
        lastNames.Add("Garcia");
        lastNames.Add("Mcdanial");
        lastNames.Add("Cruz");
        lastNames.Add("Henderson");
        lastNames.Add("Tran");
        lastNames.Add("Jones");
        lastNames.Add("Cruise");
        lastNames.Add("Buppin Jr.");
        lastNames.Add("Hayes");
        lastNames.Add("Ketchum");
        lastNames.Add("Griffin");
        lastNames.Add("The God");
        lastNames.Add("Arthur");
        lastNames.Add("Croft");
        lastNames.Add("Shepard");
        lastNames.Add("Irons");
        lastNames.Add("The Snail");
        lastNames.Add("Freeman");
        lastNames.Add("Aran");
        lastNames.Add("Fisher");
        lastNames.Add("Lannister");
        lastNames.Add("Stark");
        lastNames.Add("Mihoff");
        lastNames.Add("Jacobs");
        lastNames.Add("Magoobian");
        lastNames.Add("Robinson");
        lastNames.Add("Manta");
        lastNames.Add("Ween");
        lastNames.Add("Junior Jr. II");
        lastNames.Add("Wang");
        lastNames.Add("Cross");
        lastNames.Add("Baker");
        lastNames.Add("Butts");
        lastNames.Add("Meaboals");
        lastNames.Add("Felton");
        lastNames.Add("Dickinson");
        lastNames.Add("Fanny");
        lastNames.Add("Held");
        lastNames.Add("Izkul");
        lastNames.Add("Crunch");
        lastNames.Add("Casey");
        lastNames.Add("Gupper");
        lastNames.Add("Potter");
        lastNames.Add("Jenkins");
        lastNames.Add("Yelnats IV");
        lastNames.Add("Holmes");
        lastNames.Add("Godfreid");
        lastNames.Add("Elbowrubber");
        lastNames.Add("Biscuits");
        lastNames.Add("Jammytrousers");
        lastNames.Add("Heathcliff");
        lastNames.Add("Durin");
        lastNames.Add("Fowler");
        lastNames.Add("Whatson");
    }

    private static void SetupQuotes()
    {
        quotes = new List<string>();

        quotes.Add("I'm stackin' paper like Jenga!");
        quotes.Add("Obviously that's the right option...");
        quotes.Add("If there is no gap between the stall, there will be no fun");
        quotes.Add("I don’t even go to this school");
        quotes.Add("Hello I’m a Gorilla");
        quotes.Add("*whispers* I don’t have any weapons - Hayes");
        quotes.Add("Have a great summer! Wait a minute… this isn’t the signiture page!");
        quotes.Add("You miss 100% of the shots you don’t take. - Wayne Gretsky - Michael Scott");
        quotes.Add("For the sort of people who like that sort of thing, that’s the sort of thing they like");
        quotes.Add("My name is actually Nancy Jackson, this is a typo");
        quotes.Add("You have no idea how high I can fly");
        quotes.Add("I am getting this picture taken inside of the closet of the person next to me");
        quotes.Add("[REDACTED]");
        quotes.Add("My uncle works for Nintendo, so you have to do what I tell you");
        quotes.Add("Get my OnlyHands %10 off with coupon code COLESTASTYTREATS10");
        quotes.Add("It’s a puppet eat puppet world out there");
        quotes.Add("I can’t tell if I’m made of felt or just took too much");
        quotes.Add("To that homeless man who lives in the dumpster outside, call me");
        quotes.Add("I love school so much I’m going to do more school after this school is all schooled out");
        quotes.Add("PARTY TIME!");
        quotes.Add("Can’t wait to get back on the water and catch me a delicious bass");
        quotes.Add("All Hail the Black Bass!");
        quotes.Add("Can you tell that I’ve had work done?");
        quotes.Add("On a scale from 1-10, how do you rate them?");
        quotes.Add("Get a cousin!");
        quotes.Add("The number 10 is the worst number");
        quotes.Add("Congratulations on a successful Jam!");
        quotes.Add("The Earth is flat, trust me, my dad is a warlock");
        quotes.Add("Im either a puppet or someone scheduled a prostate exam for me without telling me");
        quotes.Add("Movin right along");
        quotes.Add("Don't look at me, I'm shy");
        quotes.Add("I'm trapped in this box, please... help me");
        quotes.Add("Keep Calm, its just my Mom");
        quotes.Add("I like turtles");
        quotes.Add("I'm actually right behind you");
        quotes.Add("Hey! Wanna see my tattoo!");
        quotes.Add("What a long strange trip it's been");
        quotes.Add("And his name is JOHN CENA!");
        quotes.Add("For that 10 seconds or less, I'm free");
        quotes.Add("I can't think of anything");
        quotes.Add("If I don't say something inspirational here I lose all respect");
        quotes.Add("Can you repeat the question?");
        quotes.Add("Goodbye, everyone! I'll remember you all in therapy");
        quotes.Add("$%@#$ y'all I'm out!");
        quotes.Add("I once fed a hobo but then I was followed home by some stealthy vagrants asking for seconds");
        quotes.Add("I'm leaving here with more questions than answers");
        quotes.Add("I've been held back 6 times, but this year is my year");
        quotes.Add("Catch you on the flippity flip...");

    }
}
