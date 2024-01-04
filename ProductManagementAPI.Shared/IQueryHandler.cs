 

namespace ProductManagementAPI.Shared
{
    public interface IQueryHandler<Q, R>
    {
        Task<R> Execute(Q query);
    }

}
