using System.ComponentModel;

namespace BlazorWebAppEFCore.Data
{
    public enum PersonaFisicaUSOCFDI
    {
        [Description("Aquisicion de mercancias")]
        G01,

        [Description("Devoluciones, Descuentos o bonificaciones")]
        G02,

        [Description("Gastos en general")]
        G03,

        [Description("Construcciones")]
        I01,

        [Description("Mobiliarios y equipo de oficina por inversiones")]
        I02,

        [Description("Equipo de transporte")]
        I03,

        [Description("Equipo de computo y accesorios")]
        I04,

        [Description("Dados, troqueles, moldes, matrices y herramental")]
        I05,

        [Description("Comunicacion telefonicas")]
        I06,

        [Description("Comunicacion satelitales")]
        I07,

        [Description("Otro maquinaria y equipo")]
        I08,

        [Description("Honorarios medicos, dentales y gastos hospitalarios")]
        D01,

        [Description("Gastos medicos por incapacidad o discapacidad")]
        D02,

        [Description("Gastos funerales")]
        D03,

        [Description("Donativas")]
        D04,

        [Description("Intereses reales efectivamente pagados por creditos hipotecarios (casa habitacion))")]
        D05,

        [Description("Aportaciones voluntarios al SAR")]
        D06,

        [Description("Primas por seguros de gastos medicos")]
        D07,

        [Description("Gastos de transportacion escolar obligatoria")]
        D08,

        [Description("Depositos en cuentas para el ahorro, primas que tengan como base de planes de pensiones")]
        D09,

        [Description("Pagos por servicios educativos (Colegiaturas)")]
        D10,

        [Description("Sin efectos fiscales")]
        S01,

        [Description("Pagos")]
        CP01,

        [Description("Nomica")]
        CN01,
    }
}
