﻿namespace OyeIap.Server.Grid;

public interface IBaseGridControls
{
    // Loading indicator.
    bool Loading { get; set; }

    // The text of the filter.
    string? FilterText { get; set; }

    // Paging state in PageHelper.
    IPageHelper PageHelper { get; set; }

    // Gets or sets a value indicating if the sort is ascending or descending.
    bool SortAscending { get; set; }

    event Action OnSortChanged;

    // The Column being sorted.
    string SortColumn { get; set; }
}
