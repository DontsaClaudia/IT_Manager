using System.ComponentModel.DataAnnotations;

namespace GesParck.Models
{
    public class Mapping
    {
        [Key]
        public int Id { get; set; }
        public int Position { get; set; }
    }
}
