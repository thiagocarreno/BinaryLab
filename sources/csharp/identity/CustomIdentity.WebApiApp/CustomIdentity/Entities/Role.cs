using IOC.FW.Repository.EF6.Abstraction.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CustomIdentity.Entities
{
    public class Role
        : IdentityRole<string, UserRole>, IModelCreating
    {
        public void OnCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Role>()
                .Map(
                    c =>
                    {
                        c.ToTable("Role");
                        c.Property(p => p.Id).HasColumnName("RoleId");
                        c.Properties(
                            p => new
                            {
                                p.Name
                            }
                        );
                    }
                ).HasKey(p => p.Id);

            modelBuilder
                .Entity<Role>()
                .HasMany(c => c.Users)
                .WithRequired()
                .HasForeignKey(c => c.RoleId);
        }
    }
}