using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Task19_Core_empty.Models;

    public class PersonInfoContext : DbContext
    {
        public PersonInfoContext (DbContextOptions<PersonInfoContext> options)
            : base(options)
        {
        }

        public DbSet<Task19_Core_empty.Models.PersonInfo> PersonInfo { get; set; } = default!;
    }
