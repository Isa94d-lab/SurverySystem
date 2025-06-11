using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Helpers
{
    public class UserAuthorization
    {
        public enum Rols
        {
            Administrator,
            Student,
            School
        }
        public const Rols rol_predeterminado = Rols.Student;
    }
}