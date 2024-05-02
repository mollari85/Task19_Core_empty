using System;
using Task19_Core_empty.Controllers;
using Task19_Core_empty.Entitys;

namespace Task19_Core_empty.Models
    
{
    public class PhoneBookModelSQL : IPhoneBookModel
    {
        public void Add(PersonInfo person)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Persons.Add(person);
                db.SaveChanges();
            }
        }

        public IEnumerable<PersonInfo> GetAllPersons()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Persons.ToList();
            }
        }

        public PersonInfo? GetPerson(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {

                    return db.Persons.SingleOrDefault(p => p.Id == id);
                
            }
        }

        public void Remove(PersonInfo person)
        {
            using (ApplicationContext db = new ApplicationContext())
            {

                 db.Persons.Remove(person);
                db.SaveChanges();

            }
        }
        public async void Remove(int? id)
        {

                if (id == null)
                {
                    return;
                }

                using (ApplicationContext db = new ApplicationContext())
                {
                var PersonTemp = db.Persons.FirstOrDefault(p => p.Id == id);
                db.Persons.Remove(PersonTemp);
                db.SaveChanges();

            }
        }

        public void Update(PersonInfo personOld, PersonInfo personUpdated)
        {
            
            using (ApplicationContext db = new ApplicationContext())
            {
                PersonInfo? x =db.Persons.FirstOrDefault(p => personOld.Id == p.Id);     
                if (x == null)
                    throw new ArgumentNullException($"Person {personOld.ToString()} not found");
                x.CopyFieldsFrom(personUpdated);
                db.SaveChanges();
            }
        }

        public void Update(PersonInfo personUpdated)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                PersonInfo? x = db.Persons.FirstOrDefault(p => personUpdated.Id == p.Id);
                if (x == null)
                    throw new ArgumentNullException($"Person {personUpdated.ToString()} not found");
                x.CopyFieldsFrom(personUpdated);
                db.SaveChanges();
            }
        }
    }
}
