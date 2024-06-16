using System.ComponentModel.DataAnnotations.Schema;
namespace OyeIap.Server.Data;

public class AlumnoTutor
{
    public int AlumnoId { get; set; }
    public Alumno Alumno { get; set; }

    public int TutorId { get; set; }
    public Tutor Tutor { get; set; }

    [Column(TypeName = "nvarchar(50)")]
    public Parentesco Parentesco { get; set; }

    public string? Comentarios { get; set; } = string.Empty;
}
