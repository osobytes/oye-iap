using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppEFCore.Data
{
    public class PatrocinioEmpresa
    {
        public int Id { get; set; }
        public int IdInstitucion { get; set; }

        [Required(ErrorMessage = "El campo Fecha es requerido.")]
        [DataType(DataType.Date, ErrorMessage = "El campo Fecha debe ser una fecha válida.")]
        public DateTime Fecha { get; set; }
    }
}
