using IOC.FW.Repository.EF6.Abstraction.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CustomIdentity.Entities
{
    public class UserRole
        : IdentityUserRole, IModelCreating
    {
        public void OnCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<UserRole>()
                .Map(
                    c =>
                    {
                        c.ToTable("UserRole");
                        c.Properties(
                            p => new
                            {
                                p.UserId,
                                p.RoleId
                            }
                        );
                    }
                ).HasKey(
                    c => new
                    {
                        c.UserId,
                        c.RoleId
                    }
                );
        }
    }
}