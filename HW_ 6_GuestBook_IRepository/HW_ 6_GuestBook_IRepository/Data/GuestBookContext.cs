using HW__6_GuestBook_IRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace HW__6_GuestBook_IRepository.Data
{
    public class GuestBookContext:DbContext
    {

      
        public DbSet<Message> messages {  get; set; }
        public DbSet<User> Users { get; set; }


        public GuestBookContext(DbContextOptions<GuestBookContext>option):base(option){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(m => m.Messages)
                .WithOne(m => m.User)
                .HasForeignKey(m => m.UserId)
                .IsRequired();
            modelBuilder.Entity<Message>().Property(d => d.DOP).HasDefaultValue(DateTime.Now).IsRequired();
            modelBuilder.Entity<Message>().Property(m => m.UserMessage).HasMaxLength(150).IsRequired();

            modelBuilder.Entity<User>().Property(l => l.Login).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<User>().Property(l => l.NickName).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<User>().HasIndex(l=>new {l.Login,l.NickName}).IsUnique(true);

            base.OnModelCreating(modelBuilder);
        }

    }
}
