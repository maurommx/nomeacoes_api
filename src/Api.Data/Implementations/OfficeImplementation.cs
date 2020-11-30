using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<OfficeEntity>> SelectFullAsync()
        {
            try
            {
                return await _dataset.Include(p => p.Election).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<OfficeEntity>> SelectWithIncludeAsync()
        {
            try
            {
                return await _dataset.Include(p => p.Election).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // public async Task<IEnumerable<OfficeEntity>> SelectWithIncludeAsync()
        // {
        //     try
        //     {
        //         return await _dataset.Include(p => p.Election).ToListAsync();
        //     }
        //     catch (Exception ex)
        //     {
        //         throw ex;
        //     }
        // }

    }
}
