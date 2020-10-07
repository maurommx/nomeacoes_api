using System.Linq;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class AssociateImplementation : BaseRepository<AssociateEntity>, IAssociateRepository
    {
        private DbSet<AssociateEntity> _dataset;

        public AssociateImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<AssociateEntity>();
        }
    }
}
