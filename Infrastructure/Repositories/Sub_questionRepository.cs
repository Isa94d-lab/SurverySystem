using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class Sub_questionsRepository : GenericRepository<Sub_questions>, ISub_questionsRepository
    {
        protected readonly AppDbContext _context;

        public Sub_questionsRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        
    }
}