using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Category_optionsRepository : GenericRepository<Category_options>, ICategory_optionsRepository
    {
        protected readonly AppDbContext _context;

        public Category_optionsRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

    }
}