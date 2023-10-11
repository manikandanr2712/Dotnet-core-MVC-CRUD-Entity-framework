namespace Nice_CRUD.Models.Domain
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Add properties for CountryId, StateId, and CityId
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }

        //public virtual ICollection<Country> countriesList { get; set; }
        // Navigation properties
        //public Country CountryList { get; set; }
        //public State StateList { get; set; }
        //public City CityList{ get; set; }
        public virtual Country CountryList { get; set; }
        public virtual State StateList { get; set; }
        public virtual City CityList { get; set; }
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
