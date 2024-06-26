﻿using System.ComponentModel.DataAnnotations;

namespace GesPark.Models
{
    public class Parks
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Adress { get; set; }
        public DateTime? CreateDate { get; set; }

        public Parks()
        {
               Id = 0;

        }

        public Parks(int id, string name, string adress, DateTime createdate)
        {
                Id = id;
                Name = name;
                Adress = adress;
                CreateDate = createdate;
        }
    }
}
