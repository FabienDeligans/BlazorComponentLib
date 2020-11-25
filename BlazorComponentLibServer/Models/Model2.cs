using Core.Models;

namespace BlazorComponentLibServer.Models
{
    public class Model2 : Entity
    {
        public string Name { get; set; }
        public string Property1 { get; set; } = "1";
        public string Property2 { get; set; } = "2";
        public string Property3 { get; set; } = "3";
        public string Property4 { get; set; } = "4";
    }
}
