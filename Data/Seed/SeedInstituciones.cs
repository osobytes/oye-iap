namespace OyeIap.Server.Data.Seed;
internal class SeedInstituciones : Seed
{
    private readonly string[] _nombres = [
        "Instituto Tecnológico",
        "Universidad Nacional",
        "Colegio de Ciencias",
        "Escuela de Artes",
        "Academia de Ingeniería",
        "Centro de Estudios Avanzados",
        "Facultad de Medicina",
        "Escuela de Negocios",
        "Universidad de Ciencias Aplicadas",
        "Instituto de Diseño"
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
        "Callejón Cuarto 012",
        "Paseo Quinto 345",
        "Camino Sexto 678",
        "Ruta Séptimo 901",
        "Vía Octavo 234",
        "Carretera Noveno 567",
        "Autopista Décimo 890"
    ];

    private Institucion MakeInstitucion()
    {
        var institucion = new Institucion
        {
            Nombre = RandomOne(_nombres),
            NombrePersona = RandomOne(_nombresPersona),
            ApellidoPersona = RandomOne(_apellidosPersona),
            Telefono = RandomOne(_telefonos),
            Descripcion = $"{RandomOne(_nombres)} Descripción",
            Correo = $"{RandomOne(_nombres).Replace(" ", "").ToLower()}@example.com",
            Relacion = $"{RandomOne(_nombres)} Relación",
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
