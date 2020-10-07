using System.Linq;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class ElectedImplementation : BaseRepository<ElectedEntity>, IElectedRepository
    {
        private DbSet<ElectedEntity> _dataset;

        public ElectedImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<ElectedEntity>();
        }
    }
}
