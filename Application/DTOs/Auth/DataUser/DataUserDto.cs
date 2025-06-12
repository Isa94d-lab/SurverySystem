using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Application.DTOs.Auth.DataUser
{
    public class DataUserDto
    {
        public string? Mensaje { get; set; }
        public bool EstaAutenticado { get; set; }
        public string? UserName { get; set; } 
        public string? Email { get; set; }
        public List<string>? Rols { get; set; }
        public string? Token { get; set; }
        [JsonIgnore]
        public string? RefreshToken  { get; set; } // Sirve para que no se tenga que estar iniciando sesion cada cierto tiempo
        public DateTime RefreshTokenExpiration { get; set; }
    
    }
}