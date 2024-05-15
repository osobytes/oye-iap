using System.ComponentModel.DataAnnotations;

namespace OyeIap.Server.Data;

public class PatrocinioTutor
{
    public int Id { get; set; }
    public int IdTutor { get; set; }
    public int Donacion { get; set; }

    [Required(ErrorMessage = "El campo Fecha es requerido.")]
    [DataType(DataType.Date, ErrorMessage = "El campo Fecha debe ser una fecha válida.")]
    public DateTime Fecha { get; set; }
}
