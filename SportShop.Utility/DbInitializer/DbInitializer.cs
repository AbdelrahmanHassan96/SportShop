using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using SportShop.DataAccess.Data;
using SportShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportShop.Utility.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public DbInitializer(UserManager<ApplicationUser> userManger, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManger = userManger;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }
            if (!_roleManager.RoleExistsAsync(WebSiteRole.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebSiteRole.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRole.Role_User)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRole.Role_Employee)).GetAwaiter().GetResult();

                _userManger.CreateAsync(new ApplicationUser
                {
                    UserName = "Admin",
                    Email = "Admin@Admin.com",
                    PhoneNumber = "0201234567899"
                }, "Admin@123").GetAwaiter().GetResult();
                ApplicationUser user = _context.Users.FirstOrDefault(x => x.Email == "Admin@Admin.com");
                _userManger.AddToRoleAsync(user, WebSiteRole.Role_Admin).GetAwaiter().GetResult();

            }
            return;
        }
    }
}
