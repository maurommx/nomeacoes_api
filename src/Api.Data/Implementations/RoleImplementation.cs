using System.Linq;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class RoleImplementation : BaseRepository<RoleEntity>, IRoleRepository
    {
        private DbSet<RoleEntity> _dataset;

        public RoleImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<RoleEntity>();
        }
    }
}
