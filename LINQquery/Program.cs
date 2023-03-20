
using System;
using System.Linq;
using System.Collections.Generic;
namespace LINQ
{
    class famousPeople
    {
        public string Name { get; set; }
        public int? BirthYear { get; set; } = null;
        public int? DeathYear { get; set; } = null;
    }




    class Program
    {
        public static void Main() { 

            IList<famousPeople> stemPeople = new List<famousPeople>() {
                        new famousPeople() { Name= "Michael Faraday", BirthYear=1791,DeathYear=1867 },
                        new famousPeople() { Name= "James Clerk Maxwell", BirthYear=1831,DeathYear=1879 },
                        new famousPeople() { Name= "Marie Skłodowska Curie", BirthYear=1867,DeathYear=1934 },
                        new famousPeople() { Name= "Katherine Johnson", BirthYear=1918,DeathYear=2020 },
                        new famousPeople() { Name= "Jane C. Wright", BirthYear=1919,DeathYear=2013 },
                        new famousPeople() { Name = "Tu YouYou", BirthYear= 1930 },
                        new famousPeople() { Name = "Françoise Barré-Sinoussi", BirthYear=1947 },
                        new famousPeople() {Name = "Lydia Villa-Komaroff", BirthYear=1947},
                        new famousPeople() {Name = "Mae C. Jemison", BirthYear=1956},
                        new famousPeople() {Name = "Stephen Hawking", BirthYear=1942,DeathYear=2018 },
                        new famousPeople() {Name = "Tim Berners-Lee", BirthYear=1955 },
                        new famousPeople() {Name = "Terence Tao", BirthYear=1975 },
                        new famousPeople() {Name = "Florence Nightingale", BirthYear=1820,DeathYear=1910 },
                        new famousPeople() {Name = "George Washington Carver", DeathYear=1943 },
                        new famousPeople() {Name = "Frances Allen", BirthYear=1932,DeathYear=2020 },
                        new famousPeople() {Name = "Bill Gates", BirthYear=1955 }
             };

            //birthdate after 1900
            Console.WriteLine("People born after 1900: ");
            var queryA = from p in stemPeople
                         where p.BirthYear > 1900
                         select p;
            
            foreach (var person in queryA)
            {
                Console.WriteLine(person.Name);
            }

            //lowercase l
            Console.WriteLine("People who have a lowercase l in their name");
            var queryB = from p in stemPeople
                         where p.Name.ToLower().Count(c => c == 'l') == 2
                         select p;

            foreach (var person in queryB)
            {
                Console.WriteLine(person.Name);
            }

            //count birthdays after 1950
            var queryC = (from p in stemPeople
                          where p.BirthYear > 1950
                          select p).Count();

            Console.WriteLine("Number of people with birthdays after 1950: " + queryC);

            //between 1920-2000
            var people1920to2000 = from person in stemPeople
                                   where person.BirthYear >= 1920 && (person.DeathYear == null || person.DeathYear > 2000)
                                   orderby person.Name
                                   select person;

            Console.WriteLine("People with birth years between 1920 and 2000:");
            foreach (var person in people1920to2000)
            {
                Console.WriteLine(person.Name);
            }

            var count1920to2000 = people1920to2000.Count();

            Console.WriteLine("Number of people with birth years between 1920 and 2000: " + count1920to2000);
        }

    }
}
