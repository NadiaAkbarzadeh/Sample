using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Sample.Models;

namespace Sample.Controllers
{
    public class DefaultController : Controller
    {
        public static List<Person> People { get; set; }
        public DefaultController()
        {
            if (People == null)
            {
                People = new List<Person>();
                People.Add(new Person()
                {
                    Id = 1,
                    FirstName = "Jafar",
                    LastName = "Ashrafi",
                    Gender = 1,
                    FatherName = "Mohammad",
                    Age = 35,
                    PhoneNumber = "+90123334234",
                    CreatedTime = DateTime.Now,
                });
            }
        }
        public IActionResult Index()
        {
            return View(People);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Person person)
        {
            person.Id = People.Any() ?  (People.Max(x => x.Id) + 1) : 1;
            person.CreatedTime= DateTime.Now;
            People.Add(person);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var person = People.Single(x => x.Id == id);
            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            var existedPerson = People.FirstOrDefault(x => x.Id == person.Id);
            int index = People.IndexOf(existedPerson);
            People[index].FirstName = person.FirstName;
            People[index].LastName = person.LastName;
            People[index].Gender = person.Gender;
            People[index].FatherName = person.FatherName;
            People[index].Age = person.Age;
            People[index].PhoneNumber = person.PhoneNumber;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var person = People.Single(x => x.Id == id);
            return View(person);
        }
        [HttpPost]
        public IActionResult Delete(Person person)
        {
            var existedPerson = People.Single(x => x.Id == person.Id);
            People.Remove(existedPerson);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult IsValid(string PhoneNumber)
        {
            if (PhoneNumber.Length< 12)
            {
                return View("PhoneNUmber chouldn't be lee than 12 number");
            }
            if (People.Any(x => x.PhoneNumber == PhoneNumber))
            {
                return Json("PhoneNumber Exists");
            }
            return Json(true);

        }
        

    }
}
