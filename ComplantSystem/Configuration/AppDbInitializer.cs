using ComplantSystem.Const;
using ComplantSystem.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace ComplantSystem.Configuration
{
    public class AppDbInitializer
    {
      
            public static void Seed(IApplicationBuilder applicationBuilder)
            {
                using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetService<AppCompalintsContextDB>();

                    context.Database.EnsureCreated();

                 
                    context.SaveChanges();
                    //}
                }

            }
            public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
            {
                using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
                {

                    //Roles
                    var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                    if (!await roleManager.RoleExistsAsync(UserRoles.AdminGeneralFederation))
                        await roleManager.CreateAsync(new IdentityRole(UserRoles.AdminGeneralFederation));
                    if (!await roleManager.RoleExistsAsync(UserRoles.Beneficiarie))
                        await roleManager.CreateAsync(new IdentityRole(UserRoles.Beneficiarie));

                    //Users
                    var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    string IdentityAdmin = "0010243124111";

                    var adminUser = await userManager.FindByEmailAsync(IdentityAdmin);
                    if (adminUser == null)
                    {
                        var newAdminUser = new ApplicationUser()
                        {


                            Email = IdentityAdmin,
                            UserName = IdentityAdmin,
                            PhoneNumber = "775115810",
                            FirstName = "عبدالرحمن",
                            LastName = "علي سرحان الدعيس",
                            EmailConfirmed = true,
                            PhoneNumberConfirmed = true,

                        };
                        await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                        await userManager.AddToRoleAsync(newAdminUser, UserRoles.AdminGeneralFederation);
                    }


                    string IdentityUser = "0010243124111";

                    var appUser = await userManager.FindByEmailAsync(IdentityUser);
                    if (appUser == null)
                    {
                        var newAppUser = new ApplicationUser()
                        {
                            Email = IdentityUser,
                            UserName = IdentityUser,
                            PhoneNumber = "77453534",
                            FirstName = "صلاح محمد",
                            LastName = "عامر سعد",
                            EmailConfirmed = true,
                            PhoneNumberConfirmed = true,
                        };
                        await userManager.CreateAsync(newAppUser, "B@ww11");
                        await userManager.AddToRoleAsync(newAppUser, UserRoles.Beneficiarie);
                    }
                }
            }


        }
    }
