using System;
using System.Collections.Generic;
using Domain.Entities;
using Infrastructure.Data;
using Application.Interfaces;

namespace Infrastructure.Repositories
{
    public class SurveysRepository : GenericRepository<Surveys>, ISurveysRepository
    {
        protected readonly AppDbContext _context;

        public SurveysRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Surveys> GetByIdAsync(int id)
        {
            return await _context.Surveys
                .FirstOrDefaultAsync(p => p.Id == id) ?? throw new KeyNotFoundException($"Surveys with id {id} was not found.");
        }

    }
}