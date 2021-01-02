using System.Collections.Generic;
using System.Linq;
using BlazorComponentLibServer.Context;
using BlazorComponentLibServer.Models;

namespace BlazorComponentLib.Pages
{
    public partial class Pagination
    {
        private int NbEntity { get; set; }
        private bool Generated { get; set; }
        private List<Person> ListPersons { get; set; }
        private List<Person> ListPersonsFiltered { get; set; }

        private List<TrucNotEntity> ListTruc { get; set;  }

        protected override void OnInitialized()
        {
            using var context = new BlazorContext();
            if (!context.QueryCollection<Person>().Any()) return;
            ListPersons = context.QueryCollection<Person>().ToList();
            ListPersonsFiltered = ListPersons
                .Select(v => new Person
                {
                    FirstName = v.FirstName,
                    LastName = v.LastName,
                    Id = v.Id,
                })
                .ToList();

            ListTruc = new List<TrucNotEntity>();
            for (var i = 0; i < NbEntity ; i++)
            {
                var truc = new TrucNotEntity
                {
                    StrA = $"aa{i}",
                    StrB = $"bb{i}",
                    StrC = $"cc{i}",
                    StrD = $"dd{i}",
                    StrE = $"ee{i}",
                };
                ListTruc.Add(truc);
            }

            Generated = true;
        }

        private void Generate()
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
                    Adress = $"Address {i}",
                    Cp = $"Cp {i}",
                    City = $"City {i}"
                };
                listPerson.Add(person);
            }
            context.InsertAll(listPerson);

            ListPersons = context.QueryCollection<Person>().ToList();
            ListPersonsFiltered = ListPersons
                .Select(v => new Person
                {
                    FirstName = v.FirstName,
                    LastName = v.LastName,
                    Id = v.Id,
                })
                .ToList();

            ListTruc = new List<TrucNotEntity>(); 
            for (var i = 0; i < NbEntity; i ++)
            {
                var truc = new TrucNotEntity
                {
                    StrA = $"aa{i}",
                    StrB = $"bb{i}",
                    StrC = $"cc{i}",
                    StrD = $"dd{i}",
                    StrE = $"ee{i}",
                };
                ListTruc.Add(truc);
            }

            Generated = true;
            InvokeAsync(StateHasChanged);
        }
    }
}
