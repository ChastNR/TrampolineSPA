using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrampolineSPA.Models.Entity
{
    public class Service
    {
        public int Id { get; set; }

        [Required] [StringLength(50)] public string Name { get; set; }

        [Required] public int Days { get; set; }

        public string Description { get; set; }

        public string ImgPath { get; set; }

        [Required] public int Price { get; set; }

        public ICollection<ClientServices> ClientServices { get; set; }
    }
}