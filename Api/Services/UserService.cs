using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Api.Helpers;
using Application.DTOs.Auth;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly JWT _jwt;
    private readonly IUnitOfWork _unitOfWork;

    // 🔹 Aquí va el constructor
    public UserService(IUnitOfWork unitOfWork, IOptions<JWT> jwt)
    {
        _unitOfWork = unitOfWork;
        _jwt = jwt.Value;
    }

    // 🔸 Aquí los métodos
    public Task<string> AddRoleAsync(AddRoleDto model)
    {
        throw new NotImplementedException();
    }

    public Task<DataUserDto> GetTokenAsync(LoginDto model)
    {
        throw new NotImplementedException();
    }

    public Task<string> RegisterAsync(RegisterDto model)
    {
        throw new NotImplementedException();
    }
}
