using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace WebApiStarter.Components.Example
{
    public class Example : Model
    {
        public int    Id   { get; set; }
        [Required]
        public string Prop1 { get; set; }
        [Required]
        public string Prop2 { get; set; }

        public override void Mapping(IDataReader reader)
        {
            Id    = (HasColumn(reader, "Id"))    ? Convert.ToInt32(reader["Id"].ToString()) : Id;
            Prop1 = (HasColumn(reader, "Prop1")) ? reader["Prop1"].ToString()               : Prop1;
            Prop2 = (HasColumn(reader, "Prop2")) ? reader["Prop2"].ToString()               : Prop2;
        }
    }
}