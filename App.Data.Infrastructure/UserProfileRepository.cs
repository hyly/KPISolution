using App.Data.Core;
using App.Data.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Infrastructure
{
    public class UserProfileRepository:GenericRepository<UserProfile>,IUserProfileRepository
    {
        public UserProfileRepository(DbContext context)
            : base(context)
        {

        }
    }
}
