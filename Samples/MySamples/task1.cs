using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ourGovernment = new Government();
            var ourGovernment = new SomeGovernment[] {new Government(), new SecretGovernment()};
            var rand = new Random();
            var badThings = 0;
            for (int i = 0; i < 25; i++)
            {
                if (rand.Next(100) % 2 == 0) //something bad happen
                {
                    Console.WriteLine(i + ". " + ourGovernment[0].SolveWordProblem());
                    badThings++;
                }
                else //something another happen
                {
                    Console.WriteLine(i + ". " + ourGovernment[0].Triumph());
                }

                if (badThings > 3)
                {
                    Console.WriteLine(i + ".1. " + ourGovernment[1].SolveWordProblem());
                    badThings = 0;
                }
            }
        }
    }

    public abstract class SomeGovernment
    {
        public abstract string SolveWordProblem();

        public string Triumph()
        {
            return "Well done government";
        }

        protected class People
        {
            public string Name { get; set; }
        }
    }

    public class Government : SomeGovernment
    {
        public override string SolveWordProblem()
        {
            var blamePeople = new List<People>
            {
                new People() {Name = "white"},
                new People() {Name = "terrorists"},
                new People() {Name = "mexicans"},
                new People() {Name = "chinese"},
                new People() {Name = "russian"}
            };

            var rand = new Random();
            return "Blame the " + blamePeople[rand.Next(blamePeople.Count)].Name;
        }
    }

    public class SecretGovernment : Government
    {
        public override string SolveWordProblem()
        {
            var blamePeople = new List<People>
            {
                new People() {Name = "society"},
                new People() {Name = "government"}
            };

            var rand = new Random();
            return "Blame the " + blamePeople[rand.Next(blamePeople.Count)].Name;
        }
    }
}
