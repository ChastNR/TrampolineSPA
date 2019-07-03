using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Repository.Interface;

namespace Repository.Models
{
    public class Client : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите Ваше имя!")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите Ваш Email адрес!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Укажите номер Вашего телефона!")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public string RegistrationDate { get; set; } = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

        public bool IsConfirmed { get; set; }

        public bool IsAdmin { get; set; }

        public ICollection<ClientServices> ClientServices { get; set; }
    }
}