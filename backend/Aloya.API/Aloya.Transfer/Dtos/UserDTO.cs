using Aloya.Domain.Auth;
using Aloya.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aloya.Transfer.Dtos
{
    public record UserDTO
    { 
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string Email { get; set; }
        public string Photo { get;set; }
        public ICollection<UserAdmicy> Admicies { get; set; } = new List<UserAdmicy>();
        public Verify Verify { get; set; }
    }
}
