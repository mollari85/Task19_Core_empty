using Microsoft.AspNetCore.Mvc.ModelBinding;

using Task19_Core_empty.Models;
namespace Task19_Core_empty.Controllers
{
    public class PersonInfoDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Thirdname { get; set;}
        public string PhoneNumber { get; set;  }
        public string? Address { get; set; }
        public string? Description { get; set; }
    };
    public static class MyPersonInfoExt 
    {
     
        public static PersonInfoDto ToDTO(this PersonInfo p)
        {           
            return new PersonInfoDto {Id=p.Id, Name=p.Name,Surname= p.Surname, Thirdname=p.ThirdName, 
                PhoneNumber=p.PhoneNumber, Address=p.Address, Description=p.Description };
        }
        public static void FromDTO(this PersonInfoDto p,PersonInfo person)
        {
            // return (new PersonInfo(p.Id, p.Name, p.Surname, p.Thirdname, p.PhoneNumber, p.Address, p.Description));
            person.Id = p.Id;
            person.Name = p.Name;
            person.Address = p.Address;
            person.Description = p.Description;
            person.Surname = p.Surname;
            person.ThirdName = p.Thirdname;
            person.PhoneNumber = p.PhoneNumber;
            
        }
        public static void CopyFieldsFrom(this PersonInfo p, PersonInfo person)
        {
            // return (new PersonInfo(p.Id, p.Name, p.Surname, p.Thirdname, p.PhoneNumber, p.Address, p.Description));
            p.Id = person.Id;
            p.Name = person.Name;
            p.Surname = person.Surname;
            p.ThirdName = person.ThirdName;
            p.PhoneNumber = person.PhoneNumber;
            p.Address = person.Address;
            p.Description = person.Description;

        }
     /*
            public static void CopyFields<T>(T source, T destination)
            {
                var fields = source.GetType().GetFields();
                foreach (var field in fields)
                {
                    field.SetValue(destination, field.GetValue(source));
                }
            }
        */
    }
}

