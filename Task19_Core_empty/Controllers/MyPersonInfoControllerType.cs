using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Task19_Core_empty.Models;
namespace Task19_Core_empty.Controllers
{
    public record class PersonInfoDto(int Id, [BindRequired]string Name, [BindRequired]string Surname, string? Thirdname, [BindRequired]string PhoneNumber, string? Address, string? Description);
    public static class MyPersonInfoExt 
    {
        public static PersonInfoDto ToDTO(this PersonInfo p)
        {           
            return (new PersonInfoDto(p.Id, p.Name, p.Surname, p.ThirdName, p.PhoneNumber, p.Address, p.Description));
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

