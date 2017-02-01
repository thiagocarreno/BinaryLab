using CustomIdentity.Abstraction;
using CustomIdentity.Entities;
using CustomIdentity.Identity;
using CustomIdentity.WebApiApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CustomIdentity.WebApiApp.Controllers
{
    public class TestController : ApiController
    {
        private readonly IUserManager<User> _userManager;

        public TestController()
        {
            _userManager = new BaseUserManager<User>(
                new BaseUserStore<User, Role, UserLogin, UserRole, UserClaim>()
            );
        }
        
        // POST api/<controller>
        public async Task<IHttpActionResult> Post([FromBody]RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User() { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.ToArray()[0]);
            }

            return Ok();
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing
        //        && _userManager != null
        //    )
        //    {
        //        _userManager.Dispose();
        //    }

        //    base.Dispose(disposing);
        //}

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}