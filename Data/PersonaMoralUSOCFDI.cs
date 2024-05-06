using System.ComponentModel;

namespace BlazorWebAppEFCore.Data
{
        public enum PersonaMoralUSOCFDI
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

            [Description("Sin efectos fiscales")]
            S01,

            [Description("Pagos")]
            CP01,
        }
}
