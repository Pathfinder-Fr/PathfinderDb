﻿using Microsoft.AspNet.Identity;
using PathfinderDb.Models;

namespace PathfinderDb.Datas
{
    public interface IApplicationUserStore : IUserStore<IApplicationUser>
    {
        IApplicationUser New();
    }
}
