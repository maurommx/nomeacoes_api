using System.Linq;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class PermissionImplementation : BaseRepository<PermissionEntity>, IPermissionRepository
    {
        private DbSet<PermissionEntity> _dataset;

        public PermissionImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<PermissionEntity>();
        }
    }
}
