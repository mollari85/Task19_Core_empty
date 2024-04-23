using Microsoft.AspNetCore.Mvc;
using Task19_Core_empty.Models;

namespace Task19_Core_empty.Controllers
{
    public class PhoneBookController : Controller
    {

        IPhoneBookModel Model;
        public PhoneBookController(IPhoneBookModel model)
        {
            Model = model;
        }
        public IActionResult Index()
        {
            List<PersonModel> PersonMod = Model.GetAllPersons().Select(p => new PersonModel(p.Id, p.Name, p.Surname, p.ThirdName)).ToList();
            
            return View(PersonMod);
        }
        
    }
}
