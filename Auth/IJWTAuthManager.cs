using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Auth
{
    public interface IJWTAuthManager
    {
        LoginResponse Authenticate(string user, string password, Context context);
    }
}
