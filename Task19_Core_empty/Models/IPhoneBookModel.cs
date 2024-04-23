namespace Task19_Core_empty.Models
{
    public interface IPhoneBookModel
    {
        public void Add(PersonInfo person);
        public void Remove(PersonInfo person);
        public void Update(PersonInfo personOld, PersonInfo personUpdated);
        public void Update(PersonInfo personUpdated);
        public IEnumerable<PersonInfo> GetAllPersons();
        public PersonInfo? GetPerson(int id);


    }
}
