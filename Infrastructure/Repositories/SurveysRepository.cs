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

    }
}