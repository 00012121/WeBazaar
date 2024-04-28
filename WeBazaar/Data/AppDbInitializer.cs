using Microsoft.AspNetCore.Identity;
using System.Runtime.InteropServices;
using WeBazaar.Data.Enums;
using WeBazaar.Data.Static;
using WeBazaar.Models;

namespace WeBazaar.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();


                //Company
                if (!context.Companies.Any())
                {
                    context.Companies.AddRange(new List<Company>()
                    {
                        new Company()
                        {
                            Name = "Company 1",
                            Logo = "https://avatars.mds.yandex.net/i?id=19c3aa6de8bdab84643f218c5e421042a8754a0e-10350562-images-thumbs&n=13",
                            Description = "This is the description of the first company"
                        },
                        new Company()
                        {
                            Name = "Company 2",
                            Logo = "https://avatars.mds.yandex.net/i?id=de28469de23bbdbe39dc95744bc6ea57073d1f84-10702829-images-thumbs&n=13",
                            Description = "This is the description of the first company"
                        },
                        new Company()
                        {
                            Name = "Company 3",
                            Logo = "https://avatars.mds.yandex.net/i?id=c2a56810488a0ce4f9bd687dbed1c56ddb4a7203-10901265-images-thumbs&n=13",
                            Description = "This is the description of the first company"
                        },
                        new Company()
                        {
                            Name = "Company 4",
                            Logo = "https://avatars.mds.yandex.net/i?id=9ad8e4d7fdcf4110dd0428a00f62d632722f5fcc-9683825-images-thumbs&n=13",
                            Description = "This is the description of the first company"
                        },
                        new Company()
                        {
                            Name = "Company 5",
                            Logo = "https://avatars.mds.yandex.net/i?id=63d5e6b9c5d6a8b80f1db0d803f94c05eb4f17c9-6994724-images-thumbs&n=13",
                            Description = "This is the description of the first company"
                        },
                    });
                    context.SaveChanges();
                }

                //Products
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            FullName = "Product 1",
                            Bio = "This is the description of the first product",
                            ProfilePictureURL = "https://avatars.mds.yandex.net/i?id=44931657198a2ae842c89bb761723a4f6c0247be-5283588-images-thumbs&n=13"

                        },
                        new Product()
                        {
                            FullName = "Product 2",
                            Bio = "This is the description of the second product",
                            ProfilePictureURL = "https://avatars.mds.yandex.net/i?id=978b40132fca73190a2bd97cbfe32a0f5aaa6b30-9986976-images-thumbs&n=13"
                        },
                        new Product()
                        {
                            FullName = "Product 3",
                            Bio = "This is the description of the second product",
                            ProfilePictureURL = "https://avatars.mds.yandex.net/i?id=97430061f7f9fb1b65a38499daf0a83f63330e80-9099160-images-thumbs&n=13"
                        },
                        new Product()
                        {
                            FullName = "Product 4",
                            Bio = "This is the description of the second product",
                            ProfilePictureURL = "https://avatars.mds.yandex.net/i?id=57f0e79a09fc2a9dc4496646ca934ba2b51bb294-8750921-images-thumbs&n=13"
                        },
                        new Product()
                        {
                            FullName = "Product 5",
                            Bio = "This is the description of the second product",
                            ProfilePictureURL = "https://avatars.mds.yandex.net/i?id=a98d887241cebd321ea3b333a208debde0195220-9854329-images-thumbs&n=13"
                        }
                    });
                    context.SaveChanges();
                }

                //Producer
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Producer 1",
                            Bio = "This is the Bio of the first producer",
                            ProfilePicture = "https://avatars.mds.yandex.net/i?id=0ed29228343570bf6e648001fe6e3275b0c1d01c-5251286-images-thumbs&n=13"
                        },
                        new Producer()
                        {
                            FullName = "Producer 2",
                            Bio = "This is the Bio of the second producer",
                            ProfilePicture = "https://avatars.mds.yandex.net/i?id=6d3a5e80b2656fd1990b21fb1a6eda4695b14551-4556252-images-thumbs&n=13"
                        },
                        new Producer()
                        {
                            FullName = "Producer 3",
                            Bio = "This is the Bio of the second producer",
                            ProfilePicture = "https://avatars.mds.yandex.net/i?id=1b0152e9a1a00954f3f159aafdef986c-4592506-images-thumbs&n=13"
                        },
                        new Producer()
                        {
                            FullName = "Producer 4",
                            Bio = "This is the Bio of the second producer",
                            ProfilePicture = "https://avatars.mds.yandex.net/i?id=f600bef15a6b14e111f06ccb99f6b57417c2ee85-10638002-images-thumbs&n=13"
                        },
                        new Producer()
                        {
                            FullName = "Producer 5",
                            Bio = "This is the Bio of the second producer",
                            ProfilePicture = "https://avatars.mds.yandex.net/i?id=9369a3518777f54756da32dc4661975ff0fa9d63-10806524-images-thumbs&n=13"
                        }
                    });
                    context.SaveChanges();
                }


                //Items
                if (!context.Items.Any())
                {
                    context.Items.AddRange(new List<Item>()
                    {
                        new Item()
                        {
                            Name = "iPhone 13 pro",
                            Description = "This is the phone description",
                            Price = 39.50,
                            ImageURL = "https://avatars.mds.yandex.net/i?id=b3179fb65f58ae84b963126ff6b07348a962b73b-10114558-images-thumbs&n=13",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CompanyId = 1,
                            ProducerId = 1,
                            ItemCategory = ItemCategory.Grocery,
                            //Products_Items = new List<Product_Item>()
                        },
                        new Item()
                        {
                            Name = "iPhone 11",
                            Description = "This is the phone description",
                            Price = 29.50,
                            ImageURL = "https://avatars.mds.yandex.net/i?id=cfa59205825b4acbe14fccd8669a5b41a8b2fe7e-9832347-images-thumbs&n=13",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CompanyId = 2,
                            ProducerId = 2,
                            ItemCategory = ItemCategory.Household
                        },
                        new Item()
                        {
                            Name = "Lip stick",
                            Description = "This is the product description",
                            Price = 39.50,
                            ImageURL = "https://avatars.mds.yandex.net/i?id=f096fd6b970a9b7d7f1444a20b53d974-5886407-images-thumbs&n=13",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CompanyId = 3,
                            ProducerId = 3,
                            ItemCategory = ItemCategory.Diary
                        },
                        new Item()
                        {
                            Name = "Cream",
                            Description = "This is the cream description",
                            Price = 39.50,
                            ImageURL = "https://avatars.mds.yandex.net/i?id=fea9e0fb3dcc139146140c6711ced01d231e61c8-5669034-images-thumbs&n=13",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CompanyId = 4,
                            ProducerId = 4,
                            ItemCategory = ItemCategory.CannedGoods
                        },
                        new Item()
                        {
                            Name = "Snicker",
                            Description = "This is the shoe description",
                            Price = 39.50,
                            ImageURL = "https://avatars.mds.yandex.net/i?id=b1dec33206bb582cbb32e6d4e9661495af0b5df3-5233733-images-thumbs&n=13",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CompanyId = 5,
                            ProducerId = 5,
                            ItemCategory = ItemCategory.PersonalCare
                        },
                        new Item()
                        {
                            Name = "Roller",
                            Description = "This is the roller description",
                            Price = 39.50,
                            ImageURL = "https://avatars.mds.yandex.net/i?id=37f93a9b42e424d0cec760d9af011fc75c1be8d2-9231415-images-thumbs&n=13",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CompanyId = 1,
                            ProducerId = 1,
                            ItemCategory = ItemCategory.Diary
                        }
                    });
                    context.SaveChanges();
                }

                //Products & Items
                if (context.Products_Items.Any())
                {
                    context.Products_Items.AddRange(new List<Product_Item>()
                    {
                        new Product_Item()
                        {
                            ProductId = 1,
                            ItemId = 1
                        },
                        new Product_Item()
                        {
                            ProductId = 3,
                            ItemId = 1
                        },

                         new Product_Item()
                        {
                            ProductId = 1,
                            ItemId = 2
                        },
                         new Product_Item()
                        {
                            ProductId = 4,
                            ItemId = 2
                        },

                        new Product_Item()
                        {
                            ProductId = 1,
                            ItemId = 3
                        },
                        new Product_Item()
                        {
                            ProductId = 2,
                            ItemId = 3
                        },
                        new Product_Item()
                        {
                            ProductId = 5,
                            ItemId = 3
                        },


                        new Product_Item()
                        {
                            ProductId = 2,
                            ItemId = 4
                        },
                        new Product_Item()
                        {
                            ProductId = 3,
                            ItemId = 4
                        },
                        new Product_Item()
                        {
                            ProductId = 4,
                            ItemId = 4
                        },


                        new Product_Item()
                        {
                            ProductId = 2,
                            ItemId = 5
                        },
                        new Product_Item()
                        {
                            ProductId = 3,
                            ItemId = 5
                        },
                        new Product_Item()
                        {
                            ProductId = 4,
                            ItemId = 5
                        },
                        new Product_Item()
                        {
                            ProductId = 5,
                            ItemId = 5
                        },


                        new Product_Item()
                        {
                            ProductId = 3,
                            ItemId = 6
                        },
                        new Product_Item()
                        {
                            ProductId = 4,
                            ItemId = 6
                        },
                        new Product_Item()
                        {
                            ProductId = 5,
                            ItemId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string adminUserEmail = "admin@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        
                
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "adminpassword@12");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }



                string appUserEmail = "user@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "userpassword@12");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
