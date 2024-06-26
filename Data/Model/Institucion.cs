﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OyeIap.Server.Data;

public class Institucion : Patrocinador
{
    public int Id { get; set; }

    //[Required]
    [StringLength(100, ErrorMessage = "El campo Nombre debe tener como máximo 100 caracteres.")]
    public string NombrePersona { get; set; } = string.Empty;

    //[Required]
    [StringLength(100, ErrorMessage = "El campo Nombre debe tener como máximo 100 caracteres.")]
    public string ApellidoPersona { get; set; } = string.Empty;

    //[Required]
    [StringLength(100, ErrorMessage = "El campo Nombre debe tener como máximo 100 caracteres.")]
    public string Nombre { get; set; } = string.Empty;

    //[Required]
    [StringLength(100, ErrorMessage = "El campo Correo debe tener como máximo 100 caracteres.")]
    [EmailAddress(ErrorMessage = "El campo Correo debe ser una dirección de correo válida.")]
    public string Correo { get; set; } = string.Empty;

    //[Required]
    [StringLength(150, ErrorMessage = "El campo Dirección debe tener como máximo 150 caracteres.")]
    public string Direccion { get; set; } = string.Empty;

    //[Required]
    [StringLength(15, ErrorMessage = "El campo Teléfono debe tener como máximo 15 caracteres.")]
    public string Telefono { get; set; } = string.Empty;

    //[Required(ErrorMessage = "El campo Descripción es obligatorio.")]
    [StringLength(200, ErrorMessage = "El campo Descripción debe tener como máximo 200 caracteres.")]
    public string Descripcion { get; set; } = string.Empty;

    //[Required(ErrorMessage = "El campo Relación es obligatorio.")]
    [StringLength(200, ErrorMessage = "El campo Relación debe tener como máximo 200 caracteres.")]
    public string Relacion { get; set; } = string.Empty;

    [Required(ErrorMessage = "El campo TipoEmpresas es obligatorio.")]
    [Column(TypeName = "varchar(50)")]
    public TipoEmpresa TipoEmpresas { get; set; }
}
