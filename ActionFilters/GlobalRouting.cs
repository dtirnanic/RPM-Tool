﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RPM_Tool
{
    public class GlobalRouting : IActionFilter
    {
        private readonly ClaimsPrincipal _claimsPrincipal;
        private readonly UserManager<IdentityUser> _userManager;
        public GlobalRouting(ClaimsPrincipal claimsPrincipal, UserManager<IdentityUser> userManager)
        {
            _claimsPrincipal = claimsPrincipal;
            _userManager = userManager;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.RouteData.Values["controller"]; 
            if (controller.Equals("Home"))
            {
                if (_claimsPrincipal.IsInRole("Landlord"))
                {
                    context.Result = new RedirectToActionResult("BuildingsList", "Buildings", null);

                }
                else if (_claimsPrincipal.IsInRole("Tenant"))
                {
                    context.Result = new RedirectToActionResult("Details", "Tenants", null);

                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

    }
}
