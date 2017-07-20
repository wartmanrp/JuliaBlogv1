namespace JuliaBlogv1.Migrations
{
   using JuliaBlogv1.Models;
   using Microsoft.AspNet.Identity;
   using Microsoft.AspNet.Identity.EntityFramework;
   using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JuliaBlogv1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(JuliaBlogv1.Models.ApplicationDbContext context)
        {
         var roleManager = new RoleManager<IdentityRole>(
            new RoleStore<IdentityRole>(context));

         //creates admin if doesn't exist.
         if (!roleManager.RoleExists("Admin"))
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
               roleManager.Create(new IdentityRole { Name = "Admin" });
            }

         //creates moderator role if doesn't exist
         if (!context.Roles.Any(r => r.Name == "Moderator"))
         {
            roleManager.Create(new IdentityRole { Name = "Moderator" });
         }

         var uStore = new UserStore<ApplicationUser>(context);
         var userManager = new UserManager<ApplicationUser>(uStore);

         //creates new user
         if (userManager.FindByEmail("powers.wartman@gmail.com") == null)
         {
            userManager.Create(new ApplicationUser
            {
               UserName = "julia.i.pelly@gmail.com",
               Email = "julia.i.pelly@gmail.com",
               FirstName = "Julia",
               LastName = "Pelly"
            }, "Password-1");
         }

         //assigns person to given role (admin || moderator), if not already in it.
         var userId = userManager.FindByEmail("julia.i.pelly@gmail.com").Id;
         if (!userManager.IsInRole(userId, "Admin"))
         {
            userManager.AddToRole(userId, "Admin");
         }

        }
    }
}
