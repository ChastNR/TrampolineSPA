using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Repository.Interface;

namespace Repository.Models
{
    public class Record : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите Ваше имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите Ваш номер телефона")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Укажите дату посещения")]
        public string VisitDate { get; set; }

        [Required(ErrorMessage = "Укажите время посещения")]
        public string VisitTime { get; set; }

        [Required(ErrorMessage = "Укажите количество посетителей")]
        public int Quantity { get; set; }

        public string Time { get; set; } = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
    }
}