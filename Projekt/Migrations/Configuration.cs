namespace Projekt.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Projekt.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Projekt.Models.ApplicationDbContext context)
        {
            SeedRoles(context);
            SeedUsers(context);
        }
        private void SeedRoles(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>());

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Pracownik"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Pracownik";
                roleManager.Create(role);
            }
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            //  var store = new UserStore<User>(context);
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);
            

            if (!context.Users.Any(u => u.UserName == "Marek"))
            {
                var user = new ApplicationUser { UserName = "marek@wp.pl" };
                var adminresult = manager.Create(user, "lol");

                if (adminresult.Succeeded)
                    manager.AddToRole(user.Id, "Pracownik");
            }

            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                var user = new ApplicationUser { UserName = "admin@admin.pl" };
                var adminresult = manager.Create(user, "adminadmin");

                if (adminresult.Succeeded)
                    manager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
