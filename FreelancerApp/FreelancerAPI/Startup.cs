using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(FreelancerAPI.Startup))]

namespace FreelancerAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateAdmin();
        }
        private void CreateAdmin()
        {
            ApplicationDbContext ctx = new ApplicationDbContext();
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ctx));

            if (!roleManager.RoleExists("Employer"))
            {
                roleManager.Create(new IdentityRole("Employer"));
            }
            if (!roleManager.RoleExists("Freelancer"))
            {
                roleManager.Create(new IdentityRole("Freelancer"));
            }

        }
    }
}
