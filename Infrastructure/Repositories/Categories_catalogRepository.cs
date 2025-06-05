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
    public class Categories_catalogRepository : GenericRepository<Categories_catalog>, ICategories_catalogRepository
    {
        protected readonly AppDbContext _context;

        public Categories_catalogRepository(AppDbContext context) : base(context)
        {
            _context = context;
            
        }
        
    }
}