using BlazorWebAppEFCore.Data;
using System.Linq.Expressions;

namespace BlazorWebAppEFCore.Grid;

public class InstitucionQueryAdapter : BaseGridQueryAdapter<Institucion>
{
    public InstitucionQueryAdapter(IBaseGridControls controls) : base(controls)
    {
    }

    protected override Expression<Func<Institucion, bool>> FilterByText(string text)
    {
        return data => data.Nombre.Contains(text) || data.Correo.Contains(text) || data.Id.ToString().Contains(text);
    }
}
