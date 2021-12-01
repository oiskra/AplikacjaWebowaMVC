using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using AplikacjaWebowaMVC.DAL.Models;
using AplikacjaWebowaMVC.Services;
using AplikacjaWebowaMVC.Interfaces;
using AplikacjaWebowaMVC.DAL.Contexts;
using System.Linq;

public class HomeController : Controller
{
    public readonly IObslugaBazydanych obslugaBazydanych;

    public HomeController(IObslugaBazydanych obslugaBazydanych)
    {
        this.obslugaBazydanych = obslugaBazydanych;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    [Route("Studenci")]
    public IActionResult PobierzListeStudentow()
    {   
        return View(obslugaBazydanych.PobierzListeStudentow());
    }

    [HttpPost]
    [Route("DodajStudenta/{id}/{imie}/nazwisko")]
    public IActionResult DodajStudenta(string id, string imie, string nazwisko)
    {
        Student student = obslugaBazydanych.DodajStudenta(id, imie, nazwisko);

        if (student == null)
            return BadRequest(new { komunikat = $"Nie udało się dodać studenta o indeksie: {student.NumerIndeksu}" });

        return Ok(new {komunikat = $"Dodano studenta o indeksie: {student.NumerIndeksu}" });
    }

    [HttpPost]
    [Route("UsunStudenta/{id}")]
    public IActionResult UsunStudenta(string id)
    {
        Student student = obslugaBazydanych.UsunStudenta(id);
        if (student == null)
            return BadRequest($"Nie udało się usunąć studenta o indeksie: {student.NumerIndeksu}");

        return Ok($"Usunięto studenta o indeksie: {student.NumerIndeksu}");

    }
}
