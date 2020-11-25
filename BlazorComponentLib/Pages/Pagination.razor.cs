using System.Collections.Generic;
using System.Linq;
using BlazorComponentLibServer.Context;
using BlazorComponentLibServer.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorComponentLib.Pages
{
    public partial class Pagination
    {
        [Parameter]
        public int NbEntity { get; set; }

        public bool Generated { get; set; }

        public List<Person> ListPersons { get; set; }
        public List<Person> ListPersonsFiltered { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        public void Generate()
        {
            using var context = new BlazorContext();
            context.DropDatabase();

            var listPerson = new List<Person>();
            for (var i = 0; i < NbEntity; i++)
            {
                var person = new Person
                {
                    FirstName = $"FirstName {i}",
                    LastName = $"LastName {i}",
                    Adress = $"Adresse {i}",
                    Cp = $"Cp {i}",
                    City = $"City {i}"
                };
                listPerson.Add(person);
            }
            context.InsertAll(listPerson);

            ListPersons = context.QueryCollection<Person>().ToList();
            ListPersonsFiltered = ListPersons
                .Take(15)
                .Select(v => new Person
                {
                    FirstName = v.FirstName,
                    LastName = v.LastName,
                })
                .ToList();

            Generated = true;

            StateHasChanged();
        }
    }
}
