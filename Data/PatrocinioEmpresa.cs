using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppEFCore.Data
{
    public class PatrocinioEmpresa
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public int IdInstitucion { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "")]
        public DateTime Fecha { get; set; }
    }
}
