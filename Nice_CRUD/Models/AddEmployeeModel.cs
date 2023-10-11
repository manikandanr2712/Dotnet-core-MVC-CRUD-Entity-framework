using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Nice_CRUD.Models
{
    public class AddEmployeeModel
    {
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

        // Add other properties as needed

        // Navigation properties for the dropdown lists
        public SelectList CountryList { get; set; }
        public SelectList StateList { get; set; }
        public SelectList CityList { get; set; }
    }
}
