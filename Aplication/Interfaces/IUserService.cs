﻿using Aplication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    internal interface IUserService
    {
        Task<List<UserResponse>> GetAll();
    }
}
