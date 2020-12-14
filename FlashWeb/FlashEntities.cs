namespace FlashWeb
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class FlashEntities : DbContext
	{
		public FlashEntities()
			: base("name=FlashEntities")
		{
		}

		public virtual DbSet<Student> Students { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Student>()
				.Property(e => e.Id)
				.IsUnicode(false);

			modelBuilder.Entity<Student>()
				.Property(e => e.LastName)
				.IsUnicode(false);

			modelBuilder.Entity<Student>()
				.Property(e => e.FirstName)
				.IsUnicode(false);
		}
	}
}
