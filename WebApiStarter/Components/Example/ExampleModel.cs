using System.ComponentModel.DataAnnotations;
using System.Data;
using WebApiStarter.Commons.ExtensionMethods;

namespace WebApiStarter.Components.Example
{
    public class ExampleModel : IModel
    {
        public string Id { get; set; }
        [Required]
        public string Prop1 { get; set; }
        [Required]
        public string Prop2 { get; set; }

        public void Map(IDataReader reader)
        {
            Id    = reader.ParseField<string>("Id");
            Prop1 = reader.ParseField<string>("Prop1");
            Prop2 = reader.ParseField<string>("Prop2");
        }

        protected bool Equals(ExampleModel other)
        {
            return string.Equals(Id, other.Id) && string.Equals(Prop1, other.Prop1) && string.Equals(Prop2, other.Prop2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ExampleModel) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Prop1 != null ? Prop1.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Prop2 != null ? Prop2.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}