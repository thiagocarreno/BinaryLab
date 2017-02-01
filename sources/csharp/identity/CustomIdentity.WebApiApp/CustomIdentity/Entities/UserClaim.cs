using IOC.FW.Repository.EF6.Abstraction.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CustomIdentity.Entities
{
    public class UserClaim
        : IdentityUserClaim, IModelCreating
    {
        public void OnCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<UserClaim>()
                .Map(
                    c =>
                    {
                        c.ToTable("UserClaim");
                        c.Property(p => p.Id).HasColumnName("UserClaimId");
                        c.Properties(
                            p => new
                            {
                                p.UserId,
                                p.ClaimValue,
                                p.ClaimType
                            }
                        );
                    }
                ).HasKey(c => c.Id);
        }
    }
}