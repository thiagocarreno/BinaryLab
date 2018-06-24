using CustomIdentity.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CustomIdentity.Identity
{
    public class BaseUserStore<TUser>
        : UserStore<TUser>, IUserStore<TUser>
        where TUser : IdentityUser
    {
        public BaseUserStore()
            : base()
        {
        }
    }

    public class BaseUserStore<TUser, TRole, TUserLogin, TUserRole, TUserClaim>
        : UserStore<TUser, TRole, string, TUserLogin, TUserRole, TUserClaim>, IUserStore<TUser>
        where TUser : IdentityUser<string, TUserLogin, TUserRole, TUserClaim>, new()
        where TRole : IdentityRole<string, TUserRole>, new()
        where TUserLogin : IdentityUserLogin<string>, new()
        where TUserRole : IdentityUserRole<string>, new()
        where TUserClaim : IdentityUserClaim<string>, new()
    {
        public BaseUserStore()
            : base(new IdentityEntityFrameworkContext<TUser, TRole, TUserLogin, TUserRole, TUserClaim>()) 
        {
        }

        public BaseUserStore(DbContext context) 
            : base(context)
        {
        }
    }
}