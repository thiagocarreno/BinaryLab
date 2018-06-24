using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomIdentity.Abstraction
{
    public interface IIdentityContext<TUser, TRole, TUserLogin, TUserRole, TUserClaim>
        : IDisposable
        where TUser : IdentityUser<string, TUserLogin, TUserRole, TUserClaim>, new()
        where TRole : IdentityRole<string, TUserRole>, new()
        where TUserLogin : IdentityUserLogin<string>, new()
        where TUserRole : IdentityUserRole<string>, new()
        where TUserClaim : IdentityUserClaim<string>, new()
    {
        IDbSet<TRole> Roles { get; set; }
        IDbSet<TUser> Users { get; set; }
        bool RequireUniqueEmail { get; set; }
    }
}