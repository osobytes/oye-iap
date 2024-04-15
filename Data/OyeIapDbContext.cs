using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppEFCore.Data;

// Context for the contacts database.
public class OyeIapDbContext : DbContext
{
    // Magic string.
    public static readonly string RowVersion = nameof(RowVersion);

    // Magic strings.
    public static readonly string OyeIapDb = nameof(OyeIapDb).ToLower();

    // Inject options.
    // options: The DbContextOptions{ContactContext} for the context.
    public OyeIapDbContext(DbContextOptions<OyeIapDbContext> options)
        : base(options)
    {  
        Debug.WriteLine($"{ContextId} context created.");
    }

    // List of Contact.
    public DbSet<Contact>? Contacts { get; set; } // TODO: borrar esta tabla
    public DbSet<Alumno>? Alumnos { get; set; }
    public DbSet<Tutor>? Tutores { get; set; }
    public DbSet<Institucion>? Instituciones { get; set; }
    public DbSet<AlumnoTutor>? AlumnoTutores { get; set; }

    // Define the model.
    // modelBuilder: The ModelBuilder.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // This property isn't on the C# class,
        // so we set it up as a "shadow" property and use it for concurrency.
        modelBuilder.Entity<Contact>()
            .Property<byte[]>(RowVersion)
            .IsRowVersion();
        modelBuilder.Entity<Alumno>()
            .Property<byte[]>(RowVersion)
            .IsRowVersion();
        modelBuilder.Entity<Tutor>()
            .Property<byte[]>(RowVersion)
            .IsRowVersion();

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

    // Dispose pattern.
    public override void Dispose()
    {
        Debug.WriteLine($"{ContextId} context disposed.");
        base.Dispose();
    }

    // Dispose pattern.
    public override ValueTask DisposeAsync()
    {
        Debug.WriteLine($"{ContextId} context disposed async.");
        return base.DisposeAsync();
    }
}
