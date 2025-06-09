using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class Options_responseRepository : GenericRepository<Options_response>, IOptions_responseRepository
    {
        protected readonly AppDbContext _context;

        public Options_responseRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

    }
}