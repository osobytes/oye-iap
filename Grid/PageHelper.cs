using OyeIap.Server.Data;

namespace OyeIap.Server.Grid;

// Holds the state for paging.
public class PageHelper : IPageHelper
{
    // Items on a page.
    public int PageSize { get; set; } = 20;

    // Current page, 1-based.
    public int Page { get;  set; }

    // True when previous page exists.
    public bool HasPrev => Page > 1;
    
    // Previous page number.
    public string PrevPageTut => Page > 1 ? $"tutores/{Page - 1}" : $"tutores/1";
    public string PrevPageAlum => Page > 1 ? $"alumnos/{Page - 1}" : $"alumnos/1";
    public string PrevPageInst => Page > 1 ? $"instituciones/{Page - 1}" : $"instituciones/1";


    // True when next page exists.
    public bool HasNext => Page < PageCount;

    // Next page number.
    public string NextPageTut => Page < PageCount ? $"tutores/{Page + 1}" : $"tutores/{Page}";
    public string NextPageAlum => Page < PageCount ? $"alumnos/{Page + 1}" : $"alumnos/{Page}";
    public string NextPageInst => Page < PageCount ? $"instituciones/{Page + 1}" : $"instituciones/{Page}";


    // Total items across all pages.
    public int TotalItemCount { get; set; }

    // Items on the current page (should be less than or equal to PageSize).
    public int PageItems { get; set; }

    // Current page, 0-based.
    public int DbPage => Page - 1;

    // How many records to skip to start current page.
    public int Skip => PageSize * DbPage;

    // Total number of pages.
    public int PageCount => (TotalItemCount + PageSize - 1) / PageSize;
}
