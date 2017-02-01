using CustomIdentity.Identity;
using IOC.FW.Repository.EF6.Abstraction.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;

namespace CustomIdentity.Entities
{
    public class User
        : IdentityUser<string, UserLogin, UserRole, UserClaim>, IModelCreating
    {
        public User()
        {
            Id = Guid.NewGuid()
                .ToString();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(BaseUserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
            BaseUserManager<User> manager,
            string authenticationType
        )
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }

        public void OnCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .Map(
                    c =>
                    {
                        c.ToTable("User");
                        c.Property(p => p.Id).HasColumnName("Id");
                        c.Properties(
                            p => new
                            {
                                p.AccessFailedCount,
                                p.Email,
                                p.EmailConfirmed,
                                p.PasswordHash,
                                p.PhoneNumber,
                                p.PhoneNumberConfirmed,
                                p.TwoFactorEnabled,
                                p.SecurityStamp,
                                p.LockoutEnabled,
                                p.LockoutEndDateUtc,
                                p.UserName
                            }
                        );
                    }
                ).HasKey(c => c.Id);

            modelBuilder
                .Entity<User>()
                .HasMany(c => c.Logins)
                .WithOptional()
                .HasForeignKey(c => c.UserId);

            modelBuilder
                .Entity<User>()
                .HasMany(c => c.Claims)
                .WithOptional()
                .HasForeignKey(c => c.UserId);

            modelBuilder
                .Entity<User>()
                .HasMany(c => c.Roles)
                .WithRequired()
                .HasForeignKey(c => c.UserId);
        }
    }
}