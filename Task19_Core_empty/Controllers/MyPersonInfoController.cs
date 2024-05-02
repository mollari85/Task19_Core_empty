using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using Task19_Core_empty.Models;

namespace Task19_Core_empty.Controllers
{
    public class MyPersonInfoController : Controller
    {
        IPhoneBookModel Model;
        PersonInfo Person;
        public MyPersonInfoController(IPhoneBookModel model)
        {
            Model = model;
            Person = new PersonInfo();
        }
        public IActionResult Index(int id)
        {
            // PersonInfo person=new PersonInfo(id,"Denis", "Denvikov", "Denvikovis", "Denmark", "Dream", "Dom");
            Person = Model.GetPerson(id);
            if (Person == null)
            {
                Person = new PersonInfo();
            }
            return View(Person);
        }
        [HttpPost]
        public IActionResult Add(PersonInfoDto person)
        {
            // PersonInfo person=new PersonInfo(id,"Denis", "Denvikov", "Denvikovis", "Denmark", "Dream", "Dom");
            person.FromDTO(Person);
            Model.Add(Person);
            return RedirectToRoute(default, new { controller = "PhoneBook", action = "Index" });
        }
        [HttpPost]
        public IActionResult Update(PersonInfoDto person)
        {
            // person = new PersonInfo(id, "Denis", "Denvikov", "Denvikovis", "Denmark", "Dream", "Dom");
            person.FromDTO(Person);
            Model.Update(Person);
            return RedirectToRoute(default, new { controller = "PhoneBook", action = "Index" });
        }
        
        
        public IActionResult Delete(int Id)
        {
            // person = new PersonInfo(id, "Denis", "Denvikov", "Denvikovis", "Denmark", "Dream", "Dom");
            
            Model.Remove(Id);
            return RedirectToRoute(default, new { controller = "PhoneBook", action = "Index" });
        }


    }
}
