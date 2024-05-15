using OyeIap.Server.Data;
using System.Linq.Expressions;

namespace OyeIap.Server.Grid;

public class AlumnoQueryAdapter : BaseGridQueryAdapter<Alumno>
{
    public AlumnoQueryAdapter(IBaseGridControls controls) : base(controls)
    {
    }

    protected override Expression<Func<Alumno, bool>> FilterByText(string text)
    {
        return data => data.Nombre.Contains(text) || data.Correo.Contains(text) || data.Id.ToString().Contains(text) || data.ApellidoPaterno.Contains(text) || data.ApellidoMaterno.Contains(text) || data.Direccion.Contains(text);
    }
}

