using Microsoft.EntityFrameworkCore;
using TrampolineSPA.Models.Entity;

namespace TrampolineSPA.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientServices> ClientServices { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Service> Services { get; set; }

        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().ToTable("Blogs");
            modelBuilder.Entity<Blog>().HasData(new Blog()
            {
                Id = 1, Title = "Мы открылись", MetaData = "Тихон",
                Body =
                    "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                ImgPath = "../../images/Blog/Opened.jpg", PostDate = "12.06.2019  13:40:00"
            });
            modelBuilder.Entity<Blog>().HasData(new Blog()
            {
                Id = 2, Title = "Увлекательные прыжки", MetaData = "Тихон",
                Body =
                    "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                ImgPath = "../../images/Blog/People.jpg", PostDate = "12.06.2019  13:40:00"
            });

            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<ClientServices>().ToTable("ClientServices");
            modelBuilder.Entity<Record>().ToTable("Records");

            modelBuilder.Entity<Service>().ToTable("Services");
            modelBuilder.Entity<Service>().HasData(new Service()
            {
                Id = 1, Name = "Свободные прыжки", Days = 12,
                Description = "Увлекательные прыжки на батутах! Дай волю своей фантазии!",
                ImgPath = "../../images/FreeJumps.jpg", Price = 32
            });
            modelBuilder.Entity<Service>().HasData(new Service()
            {
                Id = 2, Name = "Гимнастика для детей", Days = 8,
                Description = "Быстрее! Выше! Сильнее! Лучшее развитие для Вашего ребенка!",
                ImgPath = "../../images/KidsGym.jpg", Price = 24
            });
            modelBuilder.Entity<Service>().HasData(new Service()
            {
                Id = 3, Name = "Фитнес на батуте", Days = 12,
                Description = "Если хочешь быть в тонусе все 365 дней в году, то это просто!",
                ImgPath = "../../images/Fitness.jpg", Price = 32
            });
        }
        */
    }
}