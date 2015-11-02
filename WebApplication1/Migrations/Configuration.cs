namespace WebApplication1.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebApplication1.Models.ApplicationDbContext";
        }

        protected override void Seed(WebApplication1.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Administrators"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Administrators" };
                manager.Create(role); }
            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "teszt@teszt.hu",
                    EmailConfirmed = true }; manager.Create(user, "Password1"); manager.AddToRole(user.Id, "Administrators"); }
        }
    }
}
