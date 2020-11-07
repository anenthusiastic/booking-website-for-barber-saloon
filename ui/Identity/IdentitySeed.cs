using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace ui.Identity
{
    public static class IdentitySeed
    {
        public static async Task Seed(UserManager<User> userManager,RoleManager<IdentityRole> roleManager,IConfiguration configuration){
            var username = configuration["Data:AdminUser:username"];
            var email = configuration["Data:AdminUser:email"];
            var password = configuration["Data:AdminUser:password"];
            var role = configuration["Data:AdminUser:role"];
            var role2 = "Çalışan";
            var role3 = "Müşteri";
            if(await userManager.FindByNameAsync(username)==null){
                await roleManager.CreateAsync(new IdentityRole(role));
                await roleManager.CreateAsync(new IdentityRole(role2));
                await roleManager.CreateAsync(new IdentityRole(role3));
                var user = new User(){
                    UserName = username,
                    Email = email,
                    FirstName = "Admin",
                    LastName = "Admin",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };
                var user2 = new User(){
                    UserName = "DoganYilmaz35",
                    Email = email,
                    FirstName = "Doğan",
                    LastName = "Yılmaz",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };

                var result = await userManager.CreateAsync(user,password);
                if(result.Succeeded){
                    await userManager.AddToRoleAsync(user,role);
                }

                var result2 = await userManager.CreateAsync(user2,password);
                if(result2.Succeeded){
                    await userManager.AddToRoleAsync(user2,role2);
                }
            }
        }
    }
}