
using BlazorWebAppEFCore.Data;

public class AlumnoTutor
{
    public int AlumnoId { get; set; }
    public Alumno Alumno { get; set; }

    public int TutorId { get; set; }
    public Tutor Tutor { get; set; }

    public bool EsPadre { get; set; }
}