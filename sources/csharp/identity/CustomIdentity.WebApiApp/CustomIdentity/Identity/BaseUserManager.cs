using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using CustomIdentity.Entities;
using CustomIdentity.Abstraction;

namespace CustomIdentity.Identity
{
    public class BaseUserManager<TUser>
        : UserManager<TUser>, IUserManager<TUser>
        where TUser : class, IUser<string>
    {
        private readonly IUserStore<TUser> _store;

        public BaseUserManager(IUserStore<TUser> store)
            : base(store)
        {
            _store = store;
        }

        public IUserManager<TUser> Setup(
            IdentityFactoryOptions<IUserManager<TUser>> options,
            IOwinContext context
        )
        {
            // Configure validation logic for usernames
            UserValidator = new UserValidator<TUser>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                UserTokenProvider = new DataProtectorTokenProvider<TUser>(
                    dataProtectionProvider.Create("ASP.NET Identity")
                );
            }

            return this;
        }

        protected override void Dispose(bool disposing)
        {
            //base.Dispose(disposing);
        }

        public new void Dispose()
        {
            //base.Dispose();
        }
    }
}