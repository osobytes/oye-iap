using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppEFCore.Data
{
    public class PatrocinioTutor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "")]
        public int IdTutor { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "")]
        public DateTime Fecha { get; set; }
    }
}
