using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;

namespace linq_practice_2
{

    
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            

            //Given an array of integers, write a query that returns list of numbers greater than 30 and less than 100.

            List<int> lst = new List<int> { 2,4,67, 92, 153, 15 };
            Console.WriteLine("Hello, World!");
            string s = "oh ohhhh ohkaaay!";

            Console.WriteLine(lst.Where(a => a > 30 && a < 100).Count());
            lst.Where(a => a > 30 && a < 100).ToList().ForEach(a => Console.WriteLine(a));

            //Write a query that returns words at least 5 characters long and make them uppercase.
            List<string> lst2 = new List<string> { "mango", "cake", "lemon", "watermelon" };
            lst2.Where(a => a.Length > 5).
            Select(a => a.ToUpper()).ToList().
            ForEach(a => Console.WriteLine(a));


            //Write a query that returns top 5 numbers from the list of integers in descending order.

            lst.OrderByDescending(a => a).Take(2).ToList().ForEach((a) => Console.WriteLine(a));


            //Write a query that returns list of numbers and their squares only if square is greater than 20
            lst.Where(a => a * a > 20).Select(a => a).
                ToList().
                ForEach((a) => Console.WriteLine("square of {0} is {1}", a, a * a));

            //write a query that replaces 'ea' substring with questionmark(?) in given list of words.
            lst2.Where(a => a.Contains('e')).
                Select(a => a.Replace('e', '?')).
                ToList().
                ForEach(a => Console.WriteLine(a));


            //same as above but the where condition is missing hence it will also print the elements
            //who does not contains 'e'
            lst2.
                Select(a => a.Replace('e', '?')).
                ToList().
                ForEach(a => Console.WriteLine(a));


            //Given a non - empty list of words, sort it alphabetically and return a word that contains letter 'e'.
            lst2.OrderBy(a => a).
                Where(a => a.Contains('e')).
                Select(a => a).
                ToList().
                ForEach(a => Console.WriteLine(a));

            //Write a query that returns most frequent character in string.
            //Assume that there is only one such character.
           
       
    }
}