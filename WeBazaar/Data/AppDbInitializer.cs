using WeBazaar.Data.Enums;
using WeBazaar.Models;

namespace WeBazaar.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) 
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Company
                if(!context.Companies.Any()) 
                {
                    context.Companies.AddRange(new List<Company>()
                    {
                        new Company()
                        {
                            Name = "Cinema 1",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Company()
                        {
                            Name = "Cinema 2",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Company()
                        {
                            Name = "Cinema 3",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Company()
                        {
                            Name = "Cinema 4",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Company()
                        {
                            Name = "Cinema 5",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of the first cinema"
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
                            FullName = "Actor 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Product()
                        {
                            FullName = "Actor 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Product()
                        {
                            FullName = "Actor 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Product()
                        {
                            FullName = "Actor 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Product()
                        {
                            FullName = "Actor 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
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
                            Bio = "This is the Bio of the first actor",
                            ProfilePicture = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Producer()
                        {
                            FullName = "Producer 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePicture = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePicture = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePicture = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePicture = "http://dotnethow.net/images/producers/producer-5.jpeg"
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
                            Name = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CompanyId = 3,
                            ProducerId = 3,
                            ItemCategory = ItemCategory.Grocery
                        },
                        new Item()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CompanyId = 1,
                            ProducerId = 1,
                            ItemCategory = ItemCategory.Household
                        },
                        new Item()
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CompanyId = 4,
                            ProducerId = 4,
                            ItemCategory = ItemCategory.Diary
                        },
                        new Item()
                        {
                            Name = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CompanyId = 1,
                            ProducerId = 2,
                            ItemCategory = ItemCategory.CannedGoods
                        },
                        new Item()
                        {
                            Name = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CompanyId = 1,
                            ProducerId = 3,
                            ItemCategory = ItemCategory.PersonalCare
                        },
                        new Item()
                        {
                            Name = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CompanyId = 1,
                            ProducerId = 5,
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
    }
}
