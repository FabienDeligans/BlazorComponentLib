using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using BlazorComponentLibServer.Context;
using BlazorComponentLibServer.Models;
using Microsoft.AspNetCore.Components;


namespace BlazorComponentLib.Pages
{
    public partial class Index
    {
        [Parameter]
        public int NbEntity { get; set; }

        public bool Generated { get; set; }

        public List<Person> ListPersons { get; set; }


        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        public void Generate()
        {
            Seed.Seeder(NbEntity);
            using var context = new BlazorContext();
            ListPersons = context.QueryCollection<Person>().ToList();
            
            Generated = true; 
            InvokeAsync(StateHasChanged);
        }
    }
}
