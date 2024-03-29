using System.Linq;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class MemberImplementation : BaseRepository<MemberEntity>, IMemberRepository
    {
        private DbSet<MemberEntity> _dataset;

        public MemberImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<MemberEntity>();
        }
    }
}
