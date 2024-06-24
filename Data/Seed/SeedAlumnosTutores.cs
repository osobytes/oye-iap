namespace OyeIap.Server.Data.Seed;
internal class SeedAlumnosTutores : Seed
{
    private readonly string[] _nombres = new[] {
        "Juan", "Ana", "Carlos", "María", "Pedro", "Laura", "Javier", "Sofía", "Luis", "Carmen"
    };

    private readonly string[] _apellidos = new[] {
        "González", "Rodríguez", "Pérez", "Sánchez", "Martínez", "García", "López", "Hernández", "Morales", "Castro"
    };

    private readonly string[] _direcciones = new[] {
        "Calle Principal 123",
        "Avenida Secundaria 456",
        "Boulevard Terciario 789",
        "Callejón Cuarto 012",
        "Paseo Quinto 345",
        "Camino Sexto 678",
        "Ruta Séptimo 901",
        "Vía Octavo 234",
        "Carretera Noveno 567",
        "Autopista Décimo 890",
        "Calle Once 111",
        "Avenida Doce 222",
        "Boulevard Trece 333",
        "Callejón Catorce 444",
        "Paseo Quince 555",
        "Camino Dieciséis 666",
        "Ruta Diecisiete 777",
        "Vía Dieciocho 888",
        "Carretera Diecinueve 999",
        "Autopista Veinte 000",
        "Calle Veintiuno 111",
        "Avenida Veintidós 222",
        "Boulevard Veintitrés 333",
        "Callejón Veinticuatro 444",
        "Paseo Veinticinco 555",
        "Camino Veintiséis 666",
        "Ruta Veintisiete 777",
        "Vía Veintiocho 888",
        "Carretera Veintinueve 999",
        "Autopista Treinta 000"
    };

    private readonly string[] _nombresEmpresa = [
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

    private Alumno MakeAlumno()
    {
        var alumno = new Alumno
        {
            Nombre = RandomOne(_nombres),
            ApellidoPaterno = RandomOne(_apellidos),
            ApellidoMaterno = RandomOne(_apellidos),
            Direccion = RandomOne(_direcciones),
            FechaIngreso = RandomDate(),
            Aparato = new Random().Next(2) == 0,
            Implante = new Random().Next(2) == 0,
            FechaAparato = RandomDate(),
            FechaImplante = RandomDate(),
            FechaConexion = RandomDate(),
            FechaProgramacion = RandomDate(),
            Activo = true,
            FechaEgreso = RandomDate(),
            Comentarios = $"Comentarios para {RandomOne(_nombres)} {RandomOne(_apellidos)}",
            Correo = $"{RandomOne(_nombres).Replace(" ", "").ToLower()}@example.com",
            Telefono = $"123456789{new Random().Next(10)}",
            ApellidoMaternoTutor = RandomOne(_apellidos),
            ApellidoPaternoTutor = RandomOne(_apellidos),
            NombreTutor = RandomOne(_nombres),
        };

        return alumno;
    }

    public async Task SeedDatabaseWithAlumnoCountOfAsync(ApplicationDbContext context, int totalCount)
    {
        var count = 0;
        var currentCycle = 0;
        while (count < totalCount)
        {
            var list = new List<Alumno>();
            while (currentCycle++ < 100 && count++ < totalCount)
            {
                list.Add(MakeAlumno());
            }
            if (list.Count > 0)
            {
                foreach (var alumno in list)
                {
                    await AddAlumnoWithTutorsAsync(context, alumno);
                }
            }
            currentCycle = 0;
        }
    }
    public async Task AddAlumnoWithTutorsAsync(ApplicationDbContext context, Alumno alumno)
    {
        // Crea un alumno
        context.Alumnos?.Add(alumno);
        await context.SaveChangesAsync();

        // Crea entre 1 y 3 tutores
        var apellidoPaternoAsignado = false;
        var apellidoMaternoAsignado = false;
        var random = new Random();
        var tutorCount = random.Next(1, 4);
        for (int i = 0; i < tutorCount; i++)
        {
            var sameAddress = random.Next(2) == 0;
            var parentesco = RandomEnumValue<Parentesco>();
            var apellidoPaterno = GetTutorFirstLastName(alumno, parentesco, ref apellidoPaternoAsignado, ref apellidoMaternoAsignado);
            var tutor = new Tutor
            {
                Nombre = RandomOne(_nombres),
                NombreFiscal = RandomOne(_nombres),
                ApellidoPaterno = apellidoPaterno,
                ApellidoMaterno = RandomOne(_apellidos),
                NombreP1 = RandomOne(_nombres),
                ApellidoPaternoP1 = apellidoPaterno,
                ApellidoMaternoP1 = RandomOne(_apellidos),
                Correo = $"{RandomOne(_nombres).Replace(" ", "").ToLower()}@example.com",
                Direccion = sameAddress ? alumno.Direccion : RandomOne(_direcciones),
                Telefono = $"123456789{i}",
                TelefonoEmpresa = $"123456789{i}",
                RFC = $"123456789{i}",
                PatrocinioActivo = random.Next(2) == 0,
                PersonaF = random.Next(2) == 0,
                PersonaM = random.Next(2) == 0,
                PersonaFisica = "Pago",
                PersonaMoral = "Pago",
                EmpresaNombre = RandomOne(_nombresEmpresa),
                TipoEmp = RandomEnumValue<TipoEmpresa>(),
                DetallesAyuda = "Detalles de ayuda",
                Donacion = random.Next(100, 1000),
                InformacionExtra = "Informacion Extra",
                comentarios = "comentarios",
                RegimenFiscal = "Demás ingresos",
                CorreoEmpresa = $"{RandomOne(_nombres).Replace(" ", "").ToLower()}@example.com"
            };

            context.Tutores?.Add(tutor);
            await context.SaveChangesAsync();

            var alumnoTutor = new AlumnoTutor
            {
                AlumnoId = alumno.Id,
                TutorId = tutor.Id,
                Parentesco = parentesco,
                Comentarios = $"Comentarios para la relación entre el alumno {alumno.Nombre} y el tutor {tutor.Nombre}"
            };

            context.AlumnoTutores?.Add(alumnoTutor);
        }

        await context.SaveChangesAsync();
    }

    private string GetTutorFirstLastName(Alumno alumno, Parentesco parentesco, ref bool apellidoPaternoAsignado, ref bool apellidoMaternoAsignado)
    {
        string apellido = RandomOne(_apellidos);
        if (parentesco == Parentesco.Padre && !apellidoPaternoAsignado)
        {
            if (!apellidoPaternoAsignado)
            {
                apellido = alumno.ApellidoPaterno;
                apellidoPaternoAsignado = true;
            }
            else if (!apellidoMaternoAsignado)
            {
                apellido = alumno.ApellidoMaterno;
                apellidoMaternoAsignado = true;
            }

        }
        else if (parentesco == Parentesco.Madre)
        {
            if (!apellidoMaternoAsignado)
            {
                apellido = alumno.ApellidoMaterno;
                apellidoMaternoAsignado = true;
            }
            else if (!apellidoPaternoAsignado)
            {
                apellido = alumno.ApellidoPaterno;
                apellidoPaternoAsignado = true;
            }
        }

        return apellido;
    }

    private static bool IsParent(Parentesco parentesco) =>
        parentesco == Parentesco.Padre || parentesco == Parentesco.Madre;
}