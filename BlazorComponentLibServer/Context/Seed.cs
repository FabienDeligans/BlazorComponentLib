using System.Collections.Generic;
using BlazorComponentLibServer.Models;

namespace BlazorComponentLibServer.Context
{
    public class Seed
    {
        public static void Seeder(int nb)
        {
            using var context = new BlazorContext();
            context.DropDatabase();


            var listModel1 = new List<Model1>();
            for (var i = 0; i < nb; i++)
            {
                var model1 = new Model1 {Name = $"Name {i}"};

                listModel1.Add(model1);
            }

            context.InsertAll(listModel1);


            var listModel2 = new List<Model2>();
            for (var i = 0; i < nb; i++)
            {
                var model2 = new Model2 {Name = $"Name {i}"};
                listModel2.Add(model2);
            }

            context.InsertAll(listModel2);

            var listPerson = new List<Person>();
            for (var i = 0; i < nb; i++)
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
        }
    }
}
