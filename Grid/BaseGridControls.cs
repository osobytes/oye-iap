
namespace OyeIap.Server.Grid;

public class BaseGridControls : IBaseGridControls
{
    // Keep state of paging.
    public IPageHelper PageHelper { get; set; }

    public BaseGridControls(IPageHelper pageHelper)
    {
        PageHelper = pageHelper;
    }

    // Avoid multiple concurrent requests.
    public bool Loading { get; set; }

    protected virtual string DefaultSortColumn => "Id";

    private string? _sortColumn;
    public string SortColumn
    {
        get => _sortColumn ?? DefaultSortColumn;
        set
        {
            if (_sortColumn != value)
            {
                _sortColumn = value;
                OnSortChanged?.Invoke();
            }
        }
    }

    private bool _sortAscending;
    public bool SortAscending
    {
        get => _sortAscending;
        set
        {
            if (_sortAscending != value)
            {
                _sortAscending = value;
                OnSortChanged?.Invoke();
            }
        }
    }

    // Text to filter on.
    public string? FilterText { get; set; }

    public event Action OnSortChanged;
}
