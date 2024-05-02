using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Task19_Core_empty.Controllers
{
    public record class PersonModel     ( int Id,
     string Name,
     string Surname,
     string? Thirdname
);
}
