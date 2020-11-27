using Core.Models;

namespace BlazorComponentLibServer.Models
{
    public class Person : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string Cp { get; set; }
        public string City { get; set; }
        
    }
}
