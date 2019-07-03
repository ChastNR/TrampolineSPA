using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Repository.Interface;

namespace Repository.Models
{
    public class ClientServices : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }
        public string CreationDate { get; set; } = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public Client Client { get; set; }
        public Service Service { get; set; }
    }
}