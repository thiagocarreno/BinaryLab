using CustomIdentity.Abstraction;
using IOC.FW.Repository.EF6.Abstraction.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Common;
using System.Data.Entity;
using System;

namespace CustomIdentity.Entity
{
    internal class IdentityEntityFrameworkContext<TUser, TRole, TUserLogin, TUserRole, TUserClaim>
        : IdentityDbContext<TUser, TRole, string, TUserLogin, TUserRole, TUserClaim>, IIdentityContext<TUser, TRole, TUserLogin, TUserRole, TUserClaim>
        where TUser : IdentityUser<string, TUserLogin, TUserRole, TUserClaim>, new()
        where TRole : IdentityRole<string, TUserRole>, new()
        where TUserLogin : IdentityUserLogin<string>, new()
        where TUserRole : IdentityUserRole<string>, new()
        where TUserClaim : IdentityUserClaim<string>, new()
    {
        public IdentityEntityFrameworkContext() 
            : base()
        {
            Setup();
        }

        public IdentityEntityFrameworkContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Setup();
        }

        public IdentityEntityFrameworkContext(DbConnection connection, bool destroyAfterUse)
            : base(connection, destroyAfterUse)
        {
            Setup();
        }

        private void Setup()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
            Database.CommandTimeout = 99999;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            TUser userModel = new TUser();
            if (userModel is IModelCreating)
            {
                ((IModelCreating)userModel).OnCreating(modelBuilder);
            }

            TRole roleModel = new TRole();
            if (roleModel is IModelCreating)
            {
                ((IModelCreating)roleModel).OnCreating(modelBuilder);
            }

            TUserLogin userLoginModel = new TUserLogin();
            if (userLoginModel is IModelCreating)
            {
                ((IModelCreating)userLoginModel).OnCreating(modelBuilder);
            }

            TUserRole userRoleModel = new TUserRole();
            if (userRoleModel is IModelCreating)
            {
                ((IModelCreating)userRoleModel).OnCreating(modelBuilder);
            }

            TUserClaim userClaimModel = new TUserClaim();
            if (userClaimModel is IModelCreating)
            {
                ((IModelCreating)userClaimModel).OnCreating(modelBuilder);
            }
        }
    }
}