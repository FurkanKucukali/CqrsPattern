using Microsoft.EntityFrameworkCore;

namespace CqrsPattern.Data
{
	public class StudentContext : DbContext
	{
		public StudentContext(DbContextOptions<StudentContext> options) : base(options)
		{
		}
		public DbSet<Student> Students { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Student>().HasData(new Student[]
			{
				new Student{ Name = "Furkan",Age= 20,Surname = "Küçükali",Id = 1},
				new Student{ Name = "Faruk",Age= 25,Surname = "Küçükali",Id = 2}});
		}
	}
}
