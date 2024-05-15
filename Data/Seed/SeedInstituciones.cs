namespace OyeIap.Server.Data.Seed;
internal class SeedInstituciones : Seed
{
    private readonly string[] _nombres = [
        "Instituto Tecnol�gico",
        "Universidad Nacional",
        "Colegio de Ciencias",
        "Escuela de Artes",
        "Academia de Ingenier�a",
        "Centro de Estudios Avanzados",
        "Facultad de Medicina",
        "Escuela de Negocios",
        "Universidad de Ciencias Aplicadas",
        "Instituto de Dise�o"
    ];

    private readonly string[] _nombresPersona = [
        "Juan",
        "Jose",
        "Maria",
        "Paola",
        "Raul",
        "Suzie",
        "Nicole",
        "Samuel",
        "Rick",
        "Diana"
    ];

    private readonly string[] _apellidosPersona = [
        "Hernandez",
        "Gonzales",
        "De la cruz",
        "De luque",
        "Leyva",
        "Ruiz",
        "Rivera",
        "Osuna",
        "Torres",
        "Valenzuela"
];

    private readonly string[] _telefonos = [
        "1234567890",
        "0987654321",
        "1122334455",
        "2233445566",
        "3344556677",
        "4455667788",
        "5566778899",
        "6677889900",
        "7788990011",
        "8899001122"
    ];

    private readonly string[] _direcciones = [
        "Calle Principal 123",
        "Avenida Secundaria 456",
        "Boulevard Terciario 789",
        "Callej�n Cuarto 012",
        "Paseo Quinto 345",
        "Camino Sexto 678",
        "Ruta S�ptimo 901",
        "V�a Octavo 234",
        "Carretera Noveno 567",
        "Autopista D�cimo 890"
    ];

    private Institucion MakeInstitucion()
    {
        var institucion = new Institucion
        {
            Nombre = RandomOne(_nombres),
            NombrePersona = RandomOne(_nombresPersona),
            ApellidoPersona = RandomOne(_apellidosPersona),
            Telefono = RandomOne(_telefonos),
            Descripcion = $"{RandomOne(_nombres)} Descripci�n",
            Correo = $"{RandomOne(_nombres).Replace(" ", "").ToLower()}@example.com",
            Relacion = $"{RandomOne(_nombres)} Relaci�n",
            Direccion = RandomOne(_direcciones),
            TipoEmpresas = RandomEnumValue<TipoEmpresa>(),
            DetallesAyuda = "Detalles de ayuda",
            Donacion = new Random().Next(1000000),
            PatrocinioActivo = new Random().Next(2) == 0,
        };

        return institucion;
    }

    public async Task SeedDatabaseWithInstitucionCountOfAsync(ApplicationDbContext context, int totalCount)
    {
        var count = 0;
        var currentCycle = 0;
        while (count < totalCount)
        {
            var list = new List<Institucion>();
            while (currentCycle++ < 100 && count++ < totalCount)
            {
                list.Add(MakeInstitucion());
            }
            if (list.Count > 0)
            {
                context.Instituciones?.AddRange(list);
                await context.SaveChangesAsync();
            }
            currentCycle = 0;
        }
    }
}
