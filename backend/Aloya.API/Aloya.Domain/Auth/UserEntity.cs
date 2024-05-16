using Aloya.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Aloya.Domain.Auth
{
    public class UserEntity
    {
        public UserEntity()
        {
            GetUsername();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public byte[] Avatar { get; set; } = new byte[0];
        public int PasswordId { get; set; }
        public int VerifyId { get; set; }
        public Password Password { get; set; } = null!;
        public Verify Verify { get; set; } = null!;
        public ICollection<UserAdmicy> Admicies { get; set; } = new List<UserAdmicy>();
        public void GetUsername()
        {
            if(Username is null) 
                Username = "user" + Id.ToString();
        }
    }
}
