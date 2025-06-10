using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ChaptersRepository : GenericRepository<Chapters>, IChaptersRepository
    {
        protected readonly AppDbContext _context;

        public ChaptersRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
