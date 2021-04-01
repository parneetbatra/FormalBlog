using FormalBlog.Infrastructure.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FormalBlog.Core
{
    public class RoleAuthorization : AuthorizationHandler<RolesAuthorizationRequirement>, IAuthorizationHandler
    {
        private readonly DatabaseContext _context;

        public RoleAuthorization(DatabaseContext context)
        {
            _context = context;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement)
        {
            if (context.User == null || !context.User.Identity.IsAuthenticated)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var validRole = false;
            if (requirement.AllowedRoles == null ||
                requirement.AllowedRoles.Any() == false)
            {
                validRole = true;
            }
            else
            {
                var Claims = context.User.Claims;
                string Email = Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
                var roles = requirement.AllowedRoles;

                if (!string.IsNullOrEmpty(Email))
                {
                    validRole = true;
                }
                else
                {
                    validRole = false;
                }
                //validRole = _context.Users.Where(p => roles.Contains(p.Role) && p.Email == Email).Any();
            }

            if (validRole)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}