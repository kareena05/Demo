using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel;

namespace linq_practice_with_class
{
    internal class Program
    {
        class Demo
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Score { get; set; }

            

        }
        class OtherInfo
        {
            public int Oid { get; set; }
            public int Salary { get; set; }
            public List<string> Langs { get; set; }
        }


            static void Main(string[] args)
        {
            Console.WriteLine("Linq with classes!");
            List<Demo> list = new List<Demo>();
            list.Add( new Demo { Id = 21,Name="kareena",Score=77 });
            list.Add(new Demo { Id = 22, Name = "joyson", Score = 57 });
            list.Add(new Demo { Id = 23, Name = "sofiya", Score = 98 });
            list.Add(new Demo { Id = 24, Name = "JOHN", Score = 85 });
            list.Add(new Demo { Id = 25, Name = "nick", Score = 42 });
            list.Add(new Demo { Id = 26, Name = "joe", Score = 76 });
            list.Add(new Demo { Id = 27, Name = "nick", Score = 42 });

            List<OtherInfo> olist = new List<OtherInfo>();
            olist.Add(new OtherInfo { Oid = 21, Salary = 25000,Langs=new List<string> { "c++","java"} });
            olist.Add(new OtherInfo { Oid = 26, Salary = 34000, Langs = new List<string> { "PHP", "c#","python" } });
            olist.Add(new OtherInfo { Oid = 27, Salary = 10000 , Langs = new List<string> { "c", "Go" } });

            int[] ids = new int[3] { 21, 24, 25 };
            list.Where(a => ids.Contains(a.Id)).Select(a => $"{a.Id} => {a.Name}").ToList().
                ForEach(a => Console.WriteLine(a));
           

            Console.WriteLine(list.Where(a => a.Score > 60 && a.Score < 100).Count());

            list.Where(a => a.Score > 60 && a.Score < 100).ToList().ForEach(a => Console.WriteLine(a.Name+ " "+ a.Score));


            ////Write a query that returns words at least 5 characters long and make them uppercase.
            list.Where(a => a.Name.Length > 5).
                Select(a => $"name :{a.Name.ToUpper()}").
                ToList().
                ForEach(a => Console.WriteLine(a));

            ///Write a query that returns top 3 scores from the list of integers in descending order.
            list.OrderByDescending(a => a.Score).Take(3).
                Select(a => $"score:{a.Score} ").ToList().
                ForEach(a => Console.WriteLine(a));


            //write a query that replaces 'ea' substring with questionmark(?) in given list of words.
            list.Where(a => a.Name.Contains('e')).
                Select(a => $"Replaced 'e' with '?' =>>>> {a.Name.Replace('e', '?')}").
                ToList().
                ForEach(a => Console.WriteLine(a));

            ///same as above but the where condition is missing hence it will also print the elements
            //who does not contains 'e'
            Console.WriteLine("Without where condition");
            list.
                Select(a => $"Replaced 'e' with '?' =>>>> {a.Name.Replace('e', '?')}").
                ToList().
                ForEach(a => Console.WriteLine(a));

            //Given a non - empty list of words, sort it alphabetically and return a word that contains letter 'e'.
            Console.WriteLine("sort it alphabetically and return a word that contains letter 'e'");
            list.OrderBy(a=>a.Name).
                Where(a => a.Name.Contains('e')).
                Select(a => a).
                ToList().
                ForEach(a => Console.WriteLine(a.Name));

            //This is also fine,when you pass a specific field of object rather than entire 
            //object and print simply object in forEach loop

            Console.WriteLine();
            //Write a query that returns most frequent character in string.
            //Assume that there is only one such character.

            list.GroupBy(a => a.Name).
                Select(a => new { a.Key, cnt =a.Key.Count()}).
                ToList().ForEach(a => Console.WriteLine(a));

            //return a list that contains only unique (non-duplicate) strings
            Console.WriteLine("unique (non-duplicate) strings- using group by");
            list.GroupBy(a => a.Name).
                Select(a => a.Key).
                ToList().ForEach(a => Console.WriteLine(a));

            Console.WriteLine("unique (non-duplicate) strings- without group by");
            list.
                Select(a => $"Distinct name : {a.Name}").Distinct().
                ToList().ForEach(a => Console.WriteLine(a));

            //return a list that contains only upper case strings
            Console.WriteLine("contains only upper case strings");
            list.Where(a => a.Name.Equals(a.Name.ToUpper())).
                Select(a => a).ToList().ForEach(a=> Console.WriteLine(a.Name));


            Console.WriteLine("display the number and frequency of number");
            list.GroupBy(a => a.Score).
                Select(a => new { score = a.Key, appears = a.Count() }).ToList().
                ForEach(a => Console.WriteLine(a.score+" appears " +a.appears+ " Times"));


            Console.WriteLine("display numbers, multiplication of number with frequency and frequency of a number");
            list.GroupBy(a => a.Score).
                Select(a =>new {score= a.Key, appears = a.Count() }).
                ToList().
                ForEach(a =>Console.WriteLine(a.score+ " appears "+ a.appears +" times,  multiplication is: "+ a.score*a.appears));
            Console.WriteLine("\t Joins");
            var result = from a in list
                         join s in olist
                         on a.Id equals s.Oid
                         select new
                         {
                             new_id = a.Id,
                             new_name = a.Name,
                             salary = s.Salary
                         };
            foreach(var indexer in result)
            {
                Console.WriteLine(indexer.new_id+"\t"+indexer.new_name+"\t" +indexer.salary);
            }

            Console.WriteLine("Select Many");
            olist.SelectMany(a => a.Langs).ToList().ForEach(a => Console.WriteLine(a));
        }
    }
}