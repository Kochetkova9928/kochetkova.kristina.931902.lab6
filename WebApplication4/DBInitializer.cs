using WebApplication4.Data;
using WebApplication4.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4
{
    public class DBInitializer
    {
        public static async Task InitializeAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            if (!context.Folders.Any())
            {
                var folder = new Folder
                {
                    Name = "Root",
                    ParentId = null
                };

                context.Add(folder);
                await context.SaveChangesAsync();
            }

            if (await roleManager.FindByNameAsync("admin") == null &&
                await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
                await roleManager.CreateAsync(new IdentityRole("user"));

                var admin = new IdentityUser { Email = "admin@mail.com", UserName = "admin@mail.com" };
                var result = await userManager.CreateAsync(admin, "admin");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }

                var simpleUser = new IdentityUser { Email = "user@mail.com", UserName = "user@mail.com" };
                result = await userManager.CreateAsync(simpleUser, "user");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(simpleUser, "user");
                }

                var DateTimeNow = DateTime.Now;

                var topic1 = new Topic
                {
                    Name = "Nails",
                    CreatedTime = DateTimeNow.AddDays(-0.5),
                    Author = admin,
                    Posts = new List<Post>
                    {
                        new Post
                        {
                            Title = "Manicure color",
                            CreatedTime = DateTimeNow.AddDays(-0.4),
                            Author = admin,
                            Replies = new List<Reply>
                            {
                                new Reply
                                {
                                    Text = "Which manicure is better: nude or bright?",
                                    CreatedTime = DateTimeNow.AddDays(-0.4),
                                    EditTime = DateTimeNow.AddDays(-0.4),
                                    Author = admin
                                },
                                new Reply
                                {
                                    Text = "I love nude manicure",
                                    CreatedTime = DateTimeNow.AddDays(-0.3),
                                    EditTime = DateTimeNow.AddDays(-0.3),
                                    Author = simpleUser
                                },
                                new Reply
                                {
                                    Text = "Yes, I also like nude manicure",
                                    CreatedTime = DateTimeNow.AddDays(-0.2),
                                    EditTime = DateTimeNow.AddDays(-0.2),
                                    Author = admin
                                }
                            }
                        }
                    }
                };

                var topic2 = new Topic
                {
                    Name = "Serials",
                    CreatedTime = DateTimeNow.AddDays(-1),
                    Author = admin,
                    Posts = new List<Post>
                    {
                        new Post
                        {
                            Title = "Knock on my door",
                            CreatedTime = DateTimeNow.AddDays(-0.8),
                            Author = admin,
                            Replies = new List<Reply>
                            {
                                new Reply
                                {
                                    Text = "What's your favorite character?",
                                    CreatedTime = DateTimeNow.AddDays(-0.8),
                                    EditTime = DateTimeNow.AddDays(-0.8),
                                    Author = admin
                                },
                                new Reply
                                {
                                    Text = "I love Edu Yildiz very much",
                                    CreatedTime = DateTimeNow.AddDays(-0.7),
                                    EditTime = DateTimeNow.AddDays(-0.7),
                                    Author = simpleUser
                                },
                                new Reply
                                {
                                    Text = "Yea, so do I!",
                                    CreatedTime = DateTimeNow.AddDays(-0.65),
                                    EditTime = DateTimeNow.AddDays(-0.64),
                                    Author = admin
                                },
                                new Reply
                                {
                                    Text = "She and Serkan Bolat are the best couple!",
                                    CreatedTime = DateTimeNow.AddDays(-0.6),
                                    EditTime = DateTimeNow.AddDays(-0.6),
                                    Author = simpleUser
                                },
                                new Reply
                                {
                                    Text = "Yes, I especially liked it when Kiraz appeared",
                                    CreatedTime = DateTimeNow.AddDays(-0.59),
                                    EditTime = DateTimeNow.AddDays(-0.58),
                                    Author = simpleUser
                                },
                                new Reply
                                {
                                    Text = "You're right, they're just lovely",
                                    CreatedTime = DateTimeNow.AddDays(-0.5),
                                    EditTime = DateTimeNow.AddDays(-0.5),
                                    Author = admin
                                }
                            }
                        },
                        new Post
                        {
                            Title = "How I met your mother",
                            CreatedTime = DateTimeNow.AddMonths(-10),
                            Author = simpleUser,
                            Replies = new List<Reply>
                            {
                                new Reply
                                {
                                    Text = "How do you like the series? Is it worth a look?",
                                    CreatedTime = DateTimeNow.AddMonths(-10),
                                    EditTime = DateTimeNow.AddMonths(-10),
                                    Author = simpleUser
                                },
                                new Reply
                                {
                                    Text = "Definitely yes!",
                                    CreatedTime = DateTimeNow.AddMonths(-10),
                                    EditTime = DateTimeNow.AddMonths(-10),
                                    Author = admin
                                }
                            }
                        }
                    }
                };

                context.Add(topic1);
                context.Add(topic2);
                await context.SaveChangesAsync();
            }
        }
    }
}