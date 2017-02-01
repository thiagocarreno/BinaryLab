using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomIdentity.Abstraction
{
    public interface IIdentityContextFactory<TUser, TRole, TUserLogin, TUserRole, TUserClaim>
        where TUser : IdentityUser<string, TUserLogin, TUserRole, TUserClaim>, new()
        where TRole : IdentityRole<string, TUserRole>, new()
        where TUserLogin : IdentityUserLogin<string>, new()
        where TUserRole : IdentityUserRole<string>, new()
        where TUserClaim : IdentityUserClaim<string>, new()
    {
        IIdentityContext<TUser, TRole, TUserLogin, TUserRole, TUserClaim> GetContext();

        IIdentityContext<TUser, TRole, TUserLogin, TUserRole, TUserClaim> GetContext(
            string nameOrConnectionString
        );

        IIdentityContext<TUser, TRole, TUserLogin, TUserRole, TUserClaim> GetContext(
            DbConnection connection,
            bool destroyAfterUse
        );
    }
}