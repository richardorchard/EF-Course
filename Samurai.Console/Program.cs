using System;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System.Linq;

namespace Samurai.Console
{
    class Program
    {
        private static SamuraiContext context = new SamuraiContext();


        static void Main(string[] args)
        {

            context.Database.EnsureCreated();
            GetSamurais("Before Add:");
            AddSamurai();
            GetSamurais("After Add:");
            System.Console.Write("Press any key...");
            System.Console.ReadKey();

        }

        private static void AddSamurai()
        {

            var samurai = new SamuraiApp.Domain.Samurai { Name = "Sampson" };
            context.Samurais.Add(samurai);
            context.SaveChanges();
        }

        private static void GetSamurais(string text)
        {
            var samurais = context.Samurais.ToList();
            System.Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                System.Console.WriteLine(samurai.Name);
            }
        }



    }
}
