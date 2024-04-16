using BlazorWebAppEFCore.Data;
using System.Linq.Expressions;

namespace BlazorWebAppEFCore.Grid;
public class TutorQueryAdapter : BaseGridQueryAdapter<Tutor>
{
    public TutorQueryAdapter(IBaseGridControls controls) : base(controls)
    {
    }

    protected override Expression<Func<Tutor, bool>> FilterByText(string text)
    {
        return data => data.Nombre.Contains(text) || data.Correo.Contains(text) || data.Id.ToString().Contains(text);
    }
}


