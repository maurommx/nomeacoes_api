﻿using Domain.QueryOptions;

namespace Domain.Interfaces.QueryOptions
{
    public interface IQuery
    {
        string Field { get; set; }
        string Operator { get; set; }
        string Text { get; set; }

        string GetQueryString();
    }
}
