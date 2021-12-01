using AplikacjaWebowaMVC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplikacjaWebowaMVC.DAL.Models;
using AplikacjaWebowaMVC.DAL.Contexts;
using System.Diagnostics;

namespace AplikacjaWebowaMVC.Services
{
    public class ObslugaBazydanych : IObslugaBazydanych
    {
        private readonly DziekanatContext bazaDanychDziekanatu;

        public ObslugaBazydanych(DziekanatContext bazaDanychDziekanatu)
        {
            this.bazaDanychDziekanatu = bazaDanychDziekanatu;
        }

        public Student DodajStudenta(string id, string imie, string nazwisko)
        {
            using var transaction = bazaDanychDziekanatu.Database.BeginTransaction();

            try
            {

                if (int.Parse(id) > 1000)
                    throw new Exception("Zły indeks");
                Student student = new Student(id, imie, nazwisko);
                Debug.WriteLine($"Id: {student.ID}");

                bazaDanychDziekanatu.Student.Add(student);
                bazaDanychDziekanatu.SaveChanges();

                transaction.Commit();
                return student;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
                transaction.Rollback();
                return null;
            }
        }
        public List<Student> PobierzListeStudentow()
            => bazaDanychDziekanatu.Student.ToList();

        public Student UsunStudenta(string id)
        {
            var transaction = bazaDanychDziekanatu.Database.BeginTransaction();

            try
            {
                if (int.Parse(id) > 1000)
                    throw new Exception();


                Student student = (Student)bazaDanychDziekanatu.Student.Where(x => x.NumerIndeksu == id).FirstOrDefault();
                bazaDanychDziekanatu.Student.Remove(student);
                bazaDanychDziekanatu.SaveChanges();

                transaction.Commit();
                return student;
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Exeption: " + ex.Message);
                transaction.Rollback();
                return null;
            }   
        }
    }
}
