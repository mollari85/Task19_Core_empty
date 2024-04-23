namespace Task19_Core_empty.Models
{
    [Serializable]
    public class PersonInfo : ICloneable
    {
        
        public int Id { get;  set; }
        public string Name { get; set; }

        public string Surname { get; set; }
        public string? ThirdName { get; set; }
        public string PhoneNumber { get; set; }

        public string? Address { get; set; }
        public string? Description { get; set; }

        public PersonInfo() { }
        public PersonInfo(int id, string name, string surname, string? thirdName, string phoneNumber, string? address, string? description)
        {
            Id = id;
            Name = name;
            Surname = surname;
            ThirdName = thirdName;
            PhoneNumber = phoneNumber;
            Address = address;
            Description = description;

        }
        public PersonInfo(PersonInfo person)
        {
            Id=person.Id;
            Name = person.Name;
            Surname = person.Surname;
            ThirdName = person.ThirdName;
            PhoneNumber = person.PhoneNumber;
            Address = person.Address;
            Description = person.Description;

        }


        public object Clone() => MemberwiseClone();



    }
}
