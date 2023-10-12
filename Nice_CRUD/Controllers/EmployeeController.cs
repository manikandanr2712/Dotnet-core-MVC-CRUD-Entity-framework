using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nice_CRUD.Data;
using Nice_CRUD.Models;
using Nice_CRUD.Models.Domain;
using System.Text;
using static Nice_CRUD.Models.Domain.EmployeeModel;
using DinkToPdf;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Nice_CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly CRUD_MVC _context;

        public EmployeeController(CRUD_MVC context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetStates(int countryId)
        {
            // Fetch states based on the selected countryId
            var states = _context.States
                .Where(s => s.CountryId == countryId)
                .Select(s => new { s.Id, s.Name })
                .ToList();

            return Json(states); // Return the states as JSON
        }


        [HttpGet]
        public IActionResult GetCities(int stateId)
        {
            // Fetch cities based on the selected stateId
            var cities = _context.Cities
                .Where(c => c.StateId == stateId)
                .Select(c => new { c.Id, c.Name })
                .ToList();

            return Json(cities); // Return the cities as JSON
        }

        [HttpGet]
        public IActionResult Create()
        {
            // Populate the initial list of countries for the dropdown
            var countries = _context.Countries.ToList();

            ViewBag.Countries = countries;

            var viewModel = new AddEmployeeModel
            {
                CountryList = new SelectList(countries, "CountryId", "CountryName"),
                StateList = new SelectList(new List<State>(), "StateId", "StateName"), // Initialize StateList as empty
                CityList = new SelectList(new List<City>(), "CityId", "CityName")       // Initialize CityList as empty
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddEmployeeModel viewModel)
        {
            // Repopulate the dropdown lists based on the selected Country and State
            ViewBag.Countries = _context.Countries.ToList();

            if (viewModel.Name != null && viewModel.Email != null && viewModel?.CountryId != null && viewModel?.StateId != null && viewModel?.CityId != null)
            {
                // Create an Employee entity and populate its properties from the ViewModel
                var employee = new EmployeeModel()
                {
                    Name = viewModel.Name,
                    Email = viewModel.Email,
                    Phone = viewModel.Phone,
                    CountryId = viewModel.CountryId,
                    StateId = viewModel.StateId,
                    CityId = viewModel.CityId,

                };

                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index"); // Redirect to the desired page after successful submission
            }

            return View(viewModel);
        }


        [HttpGet]
        public IActionResult Index()
        {
            // Retrieve a list of all employees from the database
            //var employees = _context.Employees.ToList();
            var employees = _context.Employees
        .Include(e => e.CountryList)
        .Include(e => e.StateList)
        .Include(e => e.CityList)
        .ToList();

            return View(employees);
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            // Retrieve the employee to delete from the database
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound(); // Employee not found
            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(Guid id)
        {
            // Retrieve the employee to delete from the database
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound(); // Employee not found
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound(); // Employee not found
            }

            // Populate the initial list of countries
            ViewBag.Countries = _context.Countries.ToList();
            ViewBag.States = _context.States.ToList();
            ViewBag.Cities = _context.Cities.ToList();

            // Set the selected CountryId, StateId, and CityId in the ViewBag or EmployeeModel
            ViewBag.SelectedCountryId = employee.CountryId;
            ViewBag.SelectedStateId = employee.StateId;
            ViewBag.SelectedCityId = employee.CityId;

            // You may also need to populate States and Cities based on the employee's existing Country, State, and City

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeModel viewModel)
        {
            if (viewModel.Name != null && viewModel.Email != null && viewModel?.CountryId != null && viewModel?.StateId != null && viewModel?.CityId != null)

            {
                // Retrieve the existing employee from the database
                var existingEmployee = _context.Employees.Find(viewModel.Id);

                if (existingEmployee == null)
                {
                    return NotFound(); // Employee not found
                }

                // Update the properties of the existing employee with the values from the ViewModel
                existingEmployee.Name = viewModel.Name;
                existingEmployee.Email = viewModel.Email;
                existingEmployee.Phone = viewModel.Phone;
                existingEmployee.CountryId = viewModel.CountryId; // Update selected CountryId
                existingEmployee.StateId = viewModel.StateId; // Update selected StateId
                existingEmployee.CityId = viewModel.CityId; // Update selected CityId

                // Save changes to the database
                _context.SaveChanges();

                return RedirectToAction("Index"); // Redirect to the employee list page
            }

            // If ModelState is not valid, redisplay the form with validation errors
            ViewBag.Countries = _context.Countries.ToList();
            return View(viewModel);
        }

        
        }

   
}