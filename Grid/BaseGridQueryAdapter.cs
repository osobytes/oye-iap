using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace OyeIap.Server.Grid;

public abstract class BaseGridQueryAdapter<TData>
    where TData : class
{
    // Holds state of the grid.
    private readonly IBaseGridControls _controls;
    private readonly Dictionary<string, Func<IQueryable<TData>, IQueryable<TData>>> _filterQueries = new();
    private readonly Dictionary<string, Expression<Func<TData, object>>> _expressions = new();

    public BaseGridQueryAdapter(IBaseGridControls controls)
    {
        _controls = controls;

        // Use reflection to get the public properties of TData
        var properties = typeof(TData).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        // Create an expression for each property
        foreach (var property in properties)
        {
            // Skip non-string properties
            //if (property.PropertyType != typeof(string))
            //    continue;

            // Create a parameter expression
            var parameter = Expression.Parameter(typeof(TData), "x");

            var propertyExpression = Expression.Property(parameter, property);
            var convertedExpression = Expression.Convert(propertyExpression, typeof(object));
            
            var lambda = Expression.Lambda<Func<TData, object>>(convertedExpression, parameter);

            // Add the lambda expression to the dictionary
            _expressions.Add(property.Name, lambda);
        }
    }
    
    public async Task<ICollection<TData>> FetchAsync(IQueryable<TData> query)
    {
        query = FilterAndQuery(query);
        await CountAsync(query);
        var collection = await FetchPageQuery(query)
            .ToListAsync();
        _controls.PageHelper.PageItems = collection.Count;
        return collection;
    }

    public async Task CountAsync(IQueryable<TData> query)
    {
        _controls.PageHelper.TotalItemCount = await query.CountAsync();
    }

    public IQueryable<TData> FetchPageQuery(IQueryable<TData> query)
    {
        return query
            .Skip(_controls.PageHelper.Skip)
            .Take(_controls.PageHelper.PageSize)
            .AsNoTracking();
    }

    protected abstract Expression<Func<TData, bool>> FilterByText(string text);

    private IQueryable<TData> FilterAndQuery(IQueryable<TData> root)
    {
        var sb = new System.Text.StringBuilder();

        // Apply a filter?
        if (!string.IsNullOrWhiteSpace(_controls.FilterText))
        {
            // Filter the query
            var filter = this.FilterByText(_controls.FilterText);
            root = root.Where(filter);

            sb.Append($"Filter: '{_controls.FilterText}' ");
        }

        // Apply the expression.
        var expression = _expressions[_controls.SortColumn];
        sb.Append($"Sort: '{_controls.SortColumn}' ");

        var sortDir = _controls.SortAscending ? "ASC" : "DESC";
        sb.Append(sortDir);

        Debug.WriteLine(sb.ToString());

        // Return the unfiltered query for total count, and the filtered for fetching.
        return _controls.SortAscending ? root.OrderBy(expression)
            : root.OrderByDescending(expression);
    }
}
