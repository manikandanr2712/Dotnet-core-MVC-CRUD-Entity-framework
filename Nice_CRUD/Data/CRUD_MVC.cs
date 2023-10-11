using Microsoft.EntityFrameworkCore;
using Nice_CRUD.Models.Domain;
using static Nice_CRUD.Models.Domain.EmployeeModel;

namespace Nice_CRUD.Data
{
    public class CRUD_MVC : DbContext
    {

        public CRUD_MVC(DbContextOptions<CRUD_MVC> options) : base(options)
        { }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }

    }
}
