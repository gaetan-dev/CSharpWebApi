using System.ComponentModel.DataAnnotations;
using System.Data;
using WebApiStarter.Commons.ExtensionMethods;

namespace WebApiStarter.Components.Example
{
    public class Example : Model
    {
        [Required]
        public string Prop1 { get; set; }
        [Required]
        public string Prop2 { get; set; }

        public override void Map(IDataReader reader)
        {
            Id    = reader.ParseField<int>("Id");
            Prop1 = reader.ParseField<string>("Prop1");
            Prop2 = reader.ParseField<string>("Prop2");
        }
    }
}