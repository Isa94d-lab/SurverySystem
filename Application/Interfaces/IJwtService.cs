using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(UserMember usermember, IEnumerable<string> roles);
    }
}