using System;
using Repository.Interface;

namespace Repository.Models
{
    public class ClientServices : IEntity
    {
        public int Id { get; set; }
        public string CreationDate { get; set; } = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public Client Client { get; set; }
        public Service Service { get; set; }
    }
}