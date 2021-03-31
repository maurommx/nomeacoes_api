using Domain.QueryOptions;

namespace Domain.Interfaces.QueryOptions
{
    public interface IOrderBy
    {
        string Field { get; set; }
        string Direction { get; set; }
        
        string GetOrderString();
    }
}
