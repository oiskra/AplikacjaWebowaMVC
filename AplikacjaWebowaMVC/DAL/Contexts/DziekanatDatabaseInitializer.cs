using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AplikacjaWebowaMVC.DAL.Models;

namespace AplikacjaWebowaMVC.DAL.Contexts
{
    public class DziekanatDatabaseInitializer
    {
        public static void Initialize(DziekanatContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Zajecia.Any())
            {
                return;   // DB has been seeded
            }

            var zajecia = new Zajecia[]
            {
                new Zajecia{NazwaZajec = "Programowanie .NET",      TerminZajec = DateTime.Now.AddDays(2)},
                new Zajecia{NazwaZajec = "Programowanie C#",        TerminZajec = DateTime.Now.AddDays(2).AddHours(4)},
                new Zajecia{NazwaZajec = "Programowanie Java",      TerminZajec = DateTime.Now.AddDays(1).AddHours(2)},
                new Zajecia{NazwaZajec = "Bazy danych",             TerminZajec = DateTime.Now.AddDays(3).AddHours(1)},
                new Zajecia{NazwaZajec = "Wzorce projektowe",       TerminZajec = DateTime.Now.AddDays(5).AddHours(6)},
                new Zajecia{NazwaZajec = "Zarządzanie projektem",   TerminZajec = DateTime.Now.AddDays(7).AddHours(3)},
                new Zajecia{NazwaZajec = "UX",                      TerminZajec = DateTime.Now.AddDays(4).AddHours(3)},
                new Zajecia{NazwaZajec = "Microsoft",               TerminZajec = DateTime.Now.AddDays(1).AddHours(2)}
            };
            
            context.AddRange(zajecia);
            context.SaveChanges();

            if (context.Student.Any())
            {
                return;   // DB has been seeded
            }

            var studenci = new Student[]
            {
                new Student("111", "Adam", "Nowak"),
                new Student("222", "Andrzej", "Duda"),
                new Student("333", "Anna", "Rożek"),
                new Student("444", "Justyna", "Dzik"),
                new Student("555", "Michał", "Lis"),
                new Student("666", "Daria", "Nowak"),
                new Student("777", "Mateusz", "Mostowiak")
            };

            context.AddRange(studenci);
            context.SaveChanges();

        }
    }
}

