using CustomIdentity.Abstraction;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace CustomIdentity.Entity
{
    public class IdentityEntityFrameworkContextFactory<TUser, TRole, TUserLogin, TUserRole, TUserClaim>
        : IIdentityContextFactory<TUser, TRole, TUserLogin, TUserRole, TUserClaim>
        where TUser : IdentityUser<string, TUserLogin, TUserRole, TUserClaim>, new()
        where TRole : IdentityRole<string, TUserRole>, new()
        where TUserLogin : IdentityUserLogin<string>, new()
        where TUserRole : IdentityUserRole<string>, new()
        where TUserClaim : IdentityUserClaim<string>, new()
    {
        public IIdentityContext<TUser, TRole, TUserLogin, TUserRole, TUserClaim> GetContext()
        {
            return new IdentityEntityFrameworkContext<TUser, TRole, TUserLogin, TUserRole, TUserClaim>();
        }

        public IIdentityContext<TUser, TRole, TUserLogin, TUserRole, TUserClaim> GetContext(
            string nameOrConnectionString
        )
        {
            return new IdentityEntityFrameworkContext<TUser, TRole, TUserLogin, TUserRole, TUserClaim>(nameOrConnectionString);
        }

        public IIdentityContext<TUser, TRole, TUserLogin, TUserRole, TUserClaim> GetContext(
            DbConnection connection,
            bool destroyAfterUse
        )
        {
            return new IdentityEntityFrameworkContext<TUser, TRole, TUserLogin, TUserRole, TUserClaim>(connection, destroyAfterUse);
        }
    }
}