using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserMemberRepository : IGenericRepository<UserMember>
    {
        Task<UserMember> GetByUsernameAsyn(string username);
        Task<UserMember> GetByRefreshTokenAsync(string refreshToken);

    }
}