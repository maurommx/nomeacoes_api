namespace Api.Domain.Interfaces.QueryOptions
{
    public interface ISortBy
    {
        string Field { get; set; }
        bool Desc { get; set; }
    }
}
