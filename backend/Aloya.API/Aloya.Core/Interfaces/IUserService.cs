using Aloya.Domain.Auth;
using Aloya.Transfer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aloya.Core.Interfaces
{
    public interface IUserService
    {
        public Task<bool> Register(string username, string email, string password);
        public Task<(string token, UserDTO userDTO)> Login(string email, string password);
        public Task<bool> Verify(int id, string phone);
        public Task<bool> ChangeUser(int id, byte[] avatar, string username, string firstname, string lastname);
        public Task<bool> ChangePassword(int id, string password,string confirm);
    }
}
