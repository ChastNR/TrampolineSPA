using System;
using System.ComponentModel.DataAnnotations;

namespace TrampolineSPA.Models.Entity
{
    public class Blog
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите название поста")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Укажите мета данные")]
        public string MetaData { get; set; }

        [Required(ErrorMessage = "Напишите текст блога")]
        public string Body { get; set; }

        public string ImgPath { get; set; }

        public string PostDate { get; set; } = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
    }
}