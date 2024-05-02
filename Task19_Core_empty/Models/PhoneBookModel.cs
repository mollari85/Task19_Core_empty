using Task19_Core_empty.Controllers;
using System.Text.Json;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace Task19_Core_empty.Models
{
    public class PhoneBookModel:IPhoneBookModel
    {
        List<PersonInfo> Book;
        object locker = new();
        public PhoneBookModel()
        {

            lock (locker)
            {
                using (FileStream fs = new FileStream("Data.json", FileMode.OpenOrCreate))
                {
                    List<PersonInfo>? tmp = JsonSerializer.Deserialize<List<PersonInfo>>(fs);

                    Book = tmp ?? new List<PersonInfo>();
                }
            }


        }

        public void Add(PersonInfo person) { Book.Add(person); SendModelToJson(); }
        public void Remove(PersonInfo person) { Book.Remove(person); SendModelToJson(); }
        public void Remove(int? id) 
        {
            PersonInfo? x = Book.FirstOrDefault(p => p.Id == id);
            if (x == null)
                throw new ArgumentNullException($"Person {id.ToString()} not found");
            Book.Remove(x); 
            SendModelToJson(); 
        }

        public void Update(PersonInfo personOld, PersonInfo personUpdated)
        {
            PersonInfo? x = Book.FirstOrDefault(p => personOld.Id == p.Id);
            if (x == null)
                throw new ArgumentNullException($"Person {personOld.ToString()} not found");
            x.CopyFieldsFrom(personUpdated);
            SendModelToJson();


        }
        public void Update( PersonInfo person)
        {
            PersonInfo? x = Book.FirstOrDefault(p => person.Id == p.Id);
            if (x == null)
                throw new ArgumentNullException($"Person {person.ToString()} not found");
            x.CopyFieldsFrom(person);
            SendModelToJson();
        }
        public IEnumerable<PersonInfo> GetAllPersons()
        {
            List<PersonInfo> Result = new List<PersonInfo>();
            foreach(var i in Book)
                Result.Add((PersonInfo)i.Clone());
            return Result;
        }
        public PersonInfo? GetPerson(int id)=> Book.FirstOrDefault(p => p.Id == id);

        void SendModelToJson()
        {
            lock (locker)
            {
                using (FileStream fs = new FileStream("Data.json", FileMode.Truncate))
                {
                    lock (fs)
                    {
                        JsonSerializer.Serialize<List<PersonInfo>>(fs, Book);
                    }
                   
                    
                }
            }
        }
    }
}
