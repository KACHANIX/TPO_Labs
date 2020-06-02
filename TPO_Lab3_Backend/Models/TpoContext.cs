using Microsoft.EntityFrameworkCore;

namespace TPO_Lab3_Backend.Models
{
    public partial class TpoContext : DbContext
    {
        public TpoContext()
        {
        }

        public TpoContext(DbContextOptions<TpoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Almsgiving> Almsgiving { get; set; }
        public virtual DbSet<Bearer> Bearer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http: //go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=PEKA;Initial Catalog=TPO3;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Almsgiving>(entity =>
            {
                entity.Property(e => e.BearerId).HasColumnName("Bearer_id");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).HasColumnType("varchar(max)");

                entity.Property(e => e.Name).HasColumnType("varchar(max)");

                entity.Property(e => e.Photo).HasColumnType("varchar(max)");

                entity.Property(e => e.Type).HasColumnType("varchar(max)");

                entity.HasOne(d => d.Bearer)
                    .WithMany(p => p.Almsgiving)
                    .HasForeignKey(d => d.BearerId)
                    .HasConstraintName("FK_Almsgiving_Bearer");
            });

            modelBuilder.Entity<Bearer>(entity =>
            {
                entity.Property(e => e.Nickname).HasColumnType("varchar(max)");

                entity.Property(e => e.Password).HasColumnType("varchar(max)");

                entity.Property(e => e.Phone).HasColumnType("varchar(max)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}