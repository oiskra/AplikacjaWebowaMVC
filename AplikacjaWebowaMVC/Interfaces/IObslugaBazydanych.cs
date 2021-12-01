using AplikacjaWebowaMVC.DAL.Models;
using System.Collections.Generic;
namespace AplikacjaWebowaMVC.Interfaces
{
    public interface IObslugaBazydanych
    {
        Student DodajStudenta(string id, string imie, string nazwisko);

        Student UsunStudenta(string id);

        List<Student> PobierzListeStudentow();
    }
}