using System.ComponentModel;

namespace OyeIap.Server.Data;

public enum PersonaFisica
{
    [Description("Sueldos y Slarios e ingresos Aimilados a Salarios")]
    RF605,

    [Description("Arrendamiento")]
    RF606,

    [Description("Regimen de Enajenacion o Adquisicion de Bienes")]
    RF617,

    [Description("Demas Ingresos")]
    RF608,

    [Description("Residentes en el Extranjero sin Establecimiento Permanente en Mexico")]
    RF610,

    [Description("Ingresos por Dividendos (Socios y accionistas)")]
    RF611,

    [Description("Personas Fisicascon Actividades Empresariales y Profesionales")]
    RF612,

    [Description("Ingresos por intereses")]
    RF614,

    [Description("Regimen de los ingresos por obtencion de premios")]
    RF615,

    [Description("Sin obligaciones fiscales")]
    RF616,

    [Description("Incorporacion Fiscal")]
    RF621,

    [Description("Regimen de las Actividades Empresariales con Ingresos a traves de Plataformas Tecnologicas")]
    RF625,

    [Description("Regimen Simplicado de Confianza")]
    RF626,
}
