using System.Linq;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class ElectionImplementation : BaseRepository<ElectionEntity>, IElectionRepository
    {
        private DbSet<ElectionEntity> _dataset;

        public ElectionImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<ElectionEntity>();
        }
    }
}
