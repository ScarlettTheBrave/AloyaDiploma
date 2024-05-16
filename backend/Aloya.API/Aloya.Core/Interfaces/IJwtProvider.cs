using Aloya.Domain.Auth;
using Aloya.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aloya.Core.Interfaces
{
    public interface IJwtProvider
    {
        //public string GenerateToken(UserEntity user, List<UserAdmicy> admicies);
        public string GenerateToken(UserEntity user);
    }
}
