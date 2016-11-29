using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityLibrary
{
    class BoekhoudingIdentityUser : IdentityUser<string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>, IUser, IUser<string>
    {
        public BoekhoudingIdentityUser()
        {
            Id = Guid.NewGuid().ToString();
        }

        public BoekhoudingIdentityUser(string userName) : this()
        {
            UserName = userName;
        }
    }
}
