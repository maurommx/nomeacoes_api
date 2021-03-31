using Domain.QueryOptions;

namespace Domain.Interfaces.QueryOptions
{
    public interface IQuery
    {
        string Field { get; set; }
        OperatorsEnum Operator { get; set; }
        string Text { get; set; }

        string GetQueryString();
    }
}
