using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class SumaryoptionsRepository : GenericRepository<Sumaryoptions>, ISumaryoptionsRepository
    {
        protected readonly AppDbContext _context;

        public SumaryoptionsRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

    }
}