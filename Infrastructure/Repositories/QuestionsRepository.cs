using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class QuestionsRepository : GenericRepository<Questions>, IQuestionsRepository
    {
        protected readonly AppDbContext _context;

        public QuestionsRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        
    }
}