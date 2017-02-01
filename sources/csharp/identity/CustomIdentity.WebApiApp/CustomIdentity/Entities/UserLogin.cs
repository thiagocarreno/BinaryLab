using IOC.FW.Repository.EF6.Abstraction.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CustomIdentity.Entities
{
    public class UserLogin
        : IdentityUserLogin, IModelCreating
    {
        public void OnCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<UserLogin>()
                .Map(
                    c =>
                    {
                        c.ToTable("UserLogin");
                        c.Properties(
                            p => new
                            {
                                p.UserId,
                                p.LoginProvider,
                                p.ProviderKey
                            }
                        );
                    }
                ).HasKey(
                    p => new
                    {
                        p.LoginProvider,
                        p.ProviderKey,
                        p.UserId
                    }
                );
        }
    }
}