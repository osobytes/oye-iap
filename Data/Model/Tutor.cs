using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OyeIap.Server.Data;

public class Tutor : Patrocinador
{
    [Required(ErrorMessage = "El campo Id es requerido.")]
    public int Id { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "El campo Nombre debe tener como máximo 100 caracteres.")]
    public string Nombre { get; set; }

    [StringLength(100, ErrorMessage = "El campo Apellido Paterno debe tener como máximo 100 caracteres.")]
    public string ApellidoPaterno { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "El campo Apellido Materno debe tener como máximo 100 caracteres.")]
    public string ApellidoMaterno { get; set; }

    [StringLength(100, ErrorMessage = "El campo Nombre debe tener como máximo 100 caracteres.")]
    public string NombreP1 { get; set; }

    [StringLength(100, ErrorMessage = "El campo Apellido Paterno debe tener como máximo 100 caracteres.")]
    public string ApellidoPaternoP1 { get; set; }

    [StringLength(100, ErrorMessage = "El campo Apellido Materno debe tener como máximo 100 caracteres.")]
    public string ApellidoMaternoP1 { get; set; }

    //Datos de contacto
    [Required]
    [StringLength(150, ErrorMessage = "El campo Dirección debe tener como máximo 150 caracteres.")]
    public string Direccion { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "El campo Correo debe tener como máximo 100 caracteres.")]
    [EmailAddress(ErrorMessage = "El campo Correo debe ser una dirección de correo válida.")]
    public string Correo { get; set; }

    [Required]
    [StringLength(15, ErrorMessage = "El campo del Teléfono de empresa debe tener como máximo 15 caracteres.")]
    public string TelefonoEmpresa { get; set; }

    [StringLength(15, ErrorMessage = "El campo Teléfono debe tener como máximo 15 caracteres.")]
    public string Telefono { get; set; }

    //Datos Fiscales
    [Required]
    [StringLength(100, ErrorMessage = "El campo del Nombre fiscal de empresa debe tener como máximo 100 caracteres.")]
    public string NombreFiscal { get; set; }

    [Required]
    [StringLength(13, ErrorMessage = "El campo del RFC de empresa debe tener como máximo 13 caracteres.")]
    public string RFC { get; set; }

    public bool PersonaF { get; set; }

    public bool PersonaM { get; set; }

    public string PersonaFisica { get; set; }

    public string PersonaMoral { get; set; }

    [Required]
    public string RegimenFiscal { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "El campo Correo debe tener como máximo 100 caracteres.")]
    [EmailAddress(ErrorMessage = "El campo Correo debe ser una dirección de correo válida.")]
    public string CorreoEmpresa { get; set; }

    [StringLength(300, ErrorMessage = "")]
    public string comentarios { get; set; }

    //Empresa
    [Required]
    [StringLength(100, ErrorMessage = "El campo del Nombre de LA empresa debe tener como máximo 15 caracteres.")]
    public string EmpresaNombre { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public TipoEmpresa TipoEmp { get; set; }

    [StringLength(300, ErrorMessage = "")]
    public string InformacionExtra { get; set; }

    public ICollection<AlumnoTutor> Alumnos { get; set; }
}
