using System.Linq;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class OfficeImplementation : BaseRepository<OfficeEntity>, IOfficeRepository
    {
        private DbSet<OfficeEntity> _dataset;

        public OfficeImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<OfficeEntity>();
        }
    }
}
