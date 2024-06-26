﻿using System.ComponentModel.DataAnnotations;

namespace OyeIap.Server.Data;

public class Patrocinador
{
    [Required]
    public bool PatrocinioActivo { get; set; }

    [Required]
    [Range(0, 1000000, ErrorMessage = "El campo Donación debe estar entre 0 y 1000000.")]
    [DataType(DataType.Currency, ErrorMessage = "El campo Donación debe ser un valor numérico.")]
    public decimal Donacion { get; set; }

    [Required]
    [StringLength(200, ErrorMessage = "El campo Detalles Ayuda debe tener una longitud máxima de 200 caracteres.")]
    public string DetallesAyuda { get; set; } = string.Empty;

    public string MetodoPago { get; set; } = string.Empty;

    public string PeriocidadPago { get; set; } = string.Empty;

}
