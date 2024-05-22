using System.ComponentModel.DataAnnotations;

namespace GesPark.Models
{
    public class Mapping
    {
        [Key]
        public int Id { get; set; }
        public int Position { get; set; }
    }
}
