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
            AddMulitSamurai();
            GetSamurais("After Add:");
            System.Console.Write("Press any key...");
            System.Console.ReadKey();

        }

        private static void AddMulitSamurai()
        {

            var samurai = new SamuraiApp.Domain.Samurai { Name = "Sampson2" };
            var samurai2 = new SamuraiApp.Domain.Samurai { Name = "Sampson3" };
            var samurai3 = new SamuraiApp.Domain.Samurai { Name = "Sampson4" };
            var samurai4 = new SamuraiApp.Domain.Samurai { Name = "Sampson5" };

            context.Samurais.AddRange(samurai, samurai2, samurai3, samurai4);
            context.SaveChanges();
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
