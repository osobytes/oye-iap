using BlazorWebAppEFCore.Data;
internal class SeedAlumnosTutores : Seed
{
    private readonly string[] _nombres = new[] {
        "Juan", "Ana", "Carlos", "Mar�a", "Pedro", "Laura", "Javier", "Sof�a", "Luis", "Carmen"
    };

    private readonly string[] _apellidos = new[] {
        "Gonz�lez", "Rodr�guez", "P�rez", "S�nchez", "Mart�nez", "Garc�a", "L�pez", "Hern�ndez", "Morales", "Castro"
    };

    private readonly string[] _direcciones = new[] {
        "Calle Principal 123",
        "Avenida Secundaria 456",
        "Boulevard Terciario 789",
        "Callej�n Cuarto 012",
        "Paseo Quinto 345",
        "Camino Sexto 678",
        "Ruta S�ptimo 901",
        "V�a Octavo 234",
        "Carretera Noveno 567",
        "Autopista D�cimo 890",
        "Calle Once 111",
        "Avenida Doce 222",
        "Boulevard Trece 333",
        "Callej�n Catorce 444",
        "Paseo Quince 555",
        "Camino Diecis�is 666",
        "Ruta Diecisiete 777",
        "V�a Dieciocho 888",
        "Carretera Diecinueve 999",
        "Autopista Veinte 000",
        "Calle Veintiuno 111",
        "Avenida Veintid�s 222",
        "Boulevard Veintitr�s 333",
        "Callej�n Veinticuatro 444",
        "Paseo Veinticinco 555",
        "Camino Veintis�is 666",
        "Ruta Veintisiete 777",
        "V�a Veintiocho 888",
        "Carretera Veintinueve 999",
        "Autopista Treinta 000"
    };

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
        };

        return alumno;
    }

    public async Task SeedDatabaseWithAlumnoCountOfAsync(OyeIapDbContext context, int totalCount)
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
                foreach(var alumno in list)
                {
                    await AddAlumnoWithTutorsAsync(context, alumno);
                }
            }
            currentCycle = 0;
        }
    }
    public async Task AddAlumnoWithTutorsAsync(OyeIapDbContext context, Alumno alumno)
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
                ApellidoPaterno = apellidoPaterno,
                ApellidoMaterno = RandomOne(_apellidos),
                Correo = $"{RandomOne(_nombres).Replace(" ", "").ToLower()}@example.com",
                Direccion = sameAddress ? alumno.Direccion : RandomOne(_direcciones),
                Telefono = $"123456789{i}",
                Pago = random.Next(100, 1000),
                PatrocinioActivo = random.Next(2) == 0,
                DetallesAyuda = "Detalles de ayuda",
                Donacion = random.Next(100, 1000),
            };

            context.Tutores?.Add(tutor);
            await context.SaveChangesAsync();

            var alumnoTutor = new AlumnoTutor
            {
                AlumnoId = alumno.Id,
                TutorId = tutor.Id,
                Parentesco = parentesco,
                Comentarios = $"Comentarios para la relaci�n entre el alumno {alumno.Nombre} y el tutor {tutor.Nombre}"
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
