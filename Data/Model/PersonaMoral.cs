using System.ComponentModel;

namespace OyeIap.Server.Data;

public enum PersonaMoral
{
    [Description("General de Ley Personas Morales")]
    RF601,

    [Description("Personas Morales con Fines no Lucrativos")]
    RF603,

    [Description("Residentes en el Extranjero sin Establecimiento Permanente en Mexico")]
    RF610,

    [Description("Sociedades Cooperativas de Produccion que optan por diferir sus ingresos")]
    RF620,

    [Description("Actividades Agricolas, Ganaderas, Silvicolas y Pesqueras")]
    RF622,

    [Description("Opcional para Grupos de Sociedades")]
    RF623,

    [Description("Coordinados")]
    RF624,

    [Description("Regimen Simplificado de Confianza")]
    RF626
}
