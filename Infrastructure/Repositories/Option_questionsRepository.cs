using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class Option_questionsRepository : GenericRepository<Option_questions>, IOption_questionsRepository
    {
        protected readonly AppDbContext _context;

        public Option_questionsRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
