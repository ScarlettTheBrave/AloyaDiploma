using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Aloya.Core.Auth
{
    public class AuthProvider
    {
        protected AuthProvider() { }
        public static int GetCurrentId(ClaimsPrincipal? user)
           => Convert.ToInt32(user?.Claims.FirstOrDefault(c => c.Type == "userId")?.Value 
               ?? throw new ArgumentNullException("you are not authorized!"));
        
    }
}
