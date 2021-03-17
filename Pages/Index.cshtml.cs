using DataAccess.Contexts;
using EFDataAccessLib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EFTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PeopleContext _peopleContext;

        public IndexModel(ILogger<IndexModel> logger, PeopleContext peopleContext)
        {
            _logger = logger;
            _peopleContext = peopleContext;
        }

        public void OnGet()
        {
            LoadSampleData();
            var people = _peopleContext.People
                .Include(a => a.Addresses)
                .Include(e => e.EmailsAddresses)
                .Where((x=>x.Age >= 18 && x.Age <= 65))
                .ToList();

        }

        private bool ApprovedAge(int age)
        {
            return (age >= 18 && age <= 65);
        }

        private void LoadSampleData()
        {
            if (_peopleContext.People.Count() == 0)
            {
                string file = System.IO.File.ReadAllText("persons.json");
                var people = JsonSerializer.Deserialize<List<Person>>(file);
                _peopleContext.AddRange(people);
                _peopleContext.SaveChanges();
            }
        }
    }
}
