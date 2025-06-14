using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MemberRolsRepository : GenericRepository<MemberRols>, IMemberRolsRepository
    {
        protected readonly AppDbContext _context;
        public MemberRolsRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<MemberRols> GetByIdAsync(int id)
        {
            return await _context.MemberRols
                .FirstOrDefaultAsync(mr => mr.UserMemberId == id) ?? throw new KeyNotFoundException($"Member Rols with id {id} was not found");
        }
        
    }
}