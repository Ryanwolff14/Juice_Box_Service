using BoxService.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoxService.Startup))]
namespace BoxService
{
    public partial class Startup
    {

        


        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //if (!roleManager.RoleExists("Admin"))
            //{
            //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //    role.Name = "Admin";
            //    roleManager.Create(role);

            //    var user = new ApplicationUser();
            //    user.UserName = "lostpanda";
            //    user.Email = "Ryan.Wolff14@Outlook.com";

            //    string userPWD = ":)burnedpanda04";

            //    var chkUser = UserManager.Create(user, userPWD);

            //    if (chkUser.Succeeded)
            //    {
            //        var result1 = UserManager.AddToRole(user.Id, "Admin");

            //    }
            //}


            //if (!roleManager.RoleExists("Customer"))
            //{
            //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //    role.Name = "Customer";
            //    roleManager.Create(role);

            //}
        }
    }
}
