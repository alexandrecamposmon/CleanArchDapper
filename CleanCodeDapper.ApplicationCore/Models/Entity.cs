using System.ComponentModel.DataAnnotations.Schema;

namespace CleanCodeDapper.ApplicationCore.Models
{
    public abstract class Entity
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
    }
}