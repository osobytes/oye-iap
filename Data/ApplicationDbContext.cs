using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OyeIap.Server.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public const string OyeIapDbName = "OyeIapDb";
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Alumno>? Alumnos { get; set; }
    public DbSet<Tutor>? Tutores { get; set; }
    public DbSet<Institucion>? Instituciones { get; set; }
    public DbSet<AlumnoTutor>? AlumnoTutores { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlumnoTutor>()
        .HasKey(at => new { at.AlumnoId, at.TutorId });

        modelBuilder.Entity<AlumnoTutor>()
            .HasOne(at => at.Alumno)
            .WithMany(a => a.Tutores)
            .HasForeignKey(at => at.AlumnoId);

        modelBuilder.Entity<AlumnoTutor>()
            .HasOne(at => at.Tutor)
            .WithMany(t => t.Alumnos)
            .HasForeignKey(at => at.TutorId);

        base.OnModelCreating(modelBuilder);
    }

}
