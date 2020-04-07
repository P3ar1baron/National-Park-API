using NationalParkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NationalParkAPI.Repository.IRepository
{
    interface IUserRepository
    {
        bool IsUniqueUser(string username);

        User Authenticate(string username, string password);

        User Register(string username, string password);
    }
}
