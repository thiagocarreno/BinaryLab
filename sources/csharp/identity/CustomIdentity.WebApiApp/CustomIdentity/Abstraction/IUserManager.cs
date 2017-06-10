using CustomIdentity.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomIdentity.Abstraction
{
    public interface IUserManager<TUser>
        : IDisposable
        where TUser : class, IUser<string>
    {
        IUserManager<TUser> Setup(IdentityFactoryOptions<IUserManager<TUser>> options, IOwinContext context);
        Task<IdentityResult> CreateAsync(TUser user, string password);
    }
}