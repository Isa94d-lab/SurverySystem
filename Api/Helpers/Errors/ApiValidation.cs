using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Helpers.Errors
{
    public class ApiValidation
    {
        public string[] Errors { get; set; } = Array.Empty<string>();     
    }
}