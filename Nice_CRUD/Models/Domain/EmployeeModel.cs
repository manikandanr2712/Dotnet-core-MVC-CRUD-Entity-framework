using System.ComponentModel.DataAnnotations;

namespace Nice_CRUD.Models.Domain
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [StringLength(20, ErrorMessage = "Phone cannot exceed 20 characters.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public int CountryId { get; set; } // Foreign key for Country

        [Required(ErrorMessage = "State is required.")]
        public int StateId { get; set; } // Foreign key for State

        [Required(ErrorMessage = "City is required.")]
        public int CityId { get; set; } // Foreign key for City

        //public virtual ICollection<Country> countriesList { get; set; }
        // Navigation properties
        //public Country CountryList { get; set; }
        //public State StateList { get; set; }
        //public City CityList{ get; set; }
        public Country CountryList { get; set; }
        public State StateList { get; set; }
        public City CityList { get; set; }
        public class Country
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<State> States { get; set; }
        }

        public class State
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int CountryId { get; set; }
            public Country Country { get; set; }
            public List<City> Cities { get; set; }
        }

        public class City
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int StateId { get; set; }
            public State State { get; set; }
        }

    }

}
