using System.ComponentModel.DataAnnotations;
using System.Data;
using WebApiStarter.Commons.ExtensionMethods;

namespace WebApiStarter.Components.Example
{
    public class Example : IModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Prop1 { get; set; }
        [Required]
        public string Prop2 { get; set; }

        public void Map(IDataReader reader)
        {
            Id    = reader.ParseField<int>("Id");
            Prop1 = reader.ParseField<string>("Prop1");
            Prop2 = reader.ParseField<string>("Prop2");
        }
    }
}