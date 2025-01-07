using IS_nal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IS_nal.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(FitnesContext context, IServiceProvider serviceProvider)
        {
            context.Database.EnsureCreated();

            // Check if roles exist, if not create them
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Admin", "Customer", "Trainer" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Create a default admin user
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var adminUser = new ApplicationUser
            {
                UserName = "admin@fitnessstudio.com",
                Email = "admin@fitnessstudio.com",
                FirstName = "Admin",
                LastName = "User"
            };

            string adminPassword = "Admin@123";
            var user = await userManager.FindByEmailAsync("admin@fitnessstudio.com");

            if (user == null)
            {
                var createAdminUser = await userManager.CreateAsync(adminUser, adminPassword);
                if (createAdminUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // Create a default customer user
            var customerUser = new ApplicationUser
            {
                UserName = "customer@fitnessstudio.com",
                Email = "customer@fitnessstudio.com",
                FirstName = "Customer",
                LastName = "User"
            };

            string customerPassword = "Customer@123";
            user = await userManager.FindByEmailAsync("customer@fitnessstudio.com");

            if (user == null)
            {
                var createCustomerUser = await userManager.CreateAsync(customerUser, customerPassword);
                if (createCustomerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(customerUser, "Customer");
                }
            }

            // Create a default trainer user
            var trainerUser = new ApplicationUser
            {
                UserName = "trainer@fitnessstudio.com",
                Email = "trainer@fitnessstudio.com",
                FirstName = "Trainer",
                LastName = "User"
            };

            string trainerPassword = "Trainer@123";
            user = await userManager.FindByEmailAsync("trainer@fitnessstudio.com");

            if (user == null)
            {
                var createTrainerUser = await userManager.CreateAsync(trainerUser, trainerPassword);
                if (createTrainerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(trainerUser, "Trainer");
                }
            }

            // Seed trainers and plans if not already seeded
            if (!context.Trainers.Any())
            {
                var trainers = new Trainer[]
                {
                    new Trainer { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "123-456-7890" },
                    new Trainer { FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", PhoneNumber = "234-567-8901" },
                    new Trainer { FirstName = "Michael", LastName = "Johnson", Email = "michael.johnson@example.com", PhoneNumber = "345-678-9012" },
                    new Trainer { FirstName = "Emily", LastName = "Davis", Email = "emily.davis@example.com", PhoneNumber = "456-789-0123" },
                    new Trainer { FirstName = "David", LastName = "Wilson", Email = "david.wilson@example.com", PhoneNumber = "567-890-1234" },
                    new Trainer { FirstName = "Sarah", LastName = "Brown", Email = "sarah.brown@example.com", PhoneNumber = "678-901-2345" }
                };
                context.Trainers.AddRange(trainers);
                context.SaveChanges();

                var plans = new Plan[]
                {
                    new Plan { Name = "Basic Plan", Description = "Access to gym facilities and group classes", Price = 30, TrainerID = 1 },
                    new Plan { Name = "Standard Plan", Description = "Includes personal training sessions and nutrition advice", Price = 50, TrainerID = 2},
                    new Plan { Name = "Premium Plan", Description = "All-inclusive membership with unlimited personal training", Price = 80, TrainerID = 3 }
                };
                context.Plans.AddRange(plans);
                context.SaveChanges();
            }

            var customers = new Customer[]
            {
                new Customer { FirstName = "Alice", LastName = "Green", Email = "alice.green@example.com", PhoneNumber = "789-012-3456", Address = "123 Green St", PlanID = 1 },
                new Customer { FirstName = "Bob", LastName = "White", Email = "bob.white@example.com", PhoneNumber = "890-123-4567", Address = "456 White St", PlanID = 2 },
                new Customer { FirstName = "Charlie", LastName = "Black", Email = "charlie.black@example.com", PhoneNumber = "901-234-5678", Address = "789 Black St", PlanID = 3 },
                new Customer { FirstName = "Diana", LastName = "Blue", Email = "diana.blue@example.com", PhoneNumber = "012-345-6789", Address = "012 Blue St", PlanID = 4 },
                new Customer { FirstName = "Ethan", LastName = "Gray", Email = "ethan.gray@example.com", PhoneNumber = "123-456-7891", Address = "345 Gray St", PlanID = 5 },
                new Customer { FirstName = "Fiona", LastName = "Red", Email = "fiona.red@example.com", PhoneNumber = "234-567-8902", Address = "678 Red St", PlanID = 1 },
                new Customer { FirstName = "George", LastName = "Yellow", Email = "george.yellow@example.com", PhoneNumber = "345-678-9013", Address = "901 Yellow St", PlanID = 2 },
                new Customer { FirstName = "Hannah", LastName = "Purple", Email = "hannah.purple@example.com", PhoneNumber = "456-789-0124", Address = "234 Purple St", PlanID = 3 },
                new Customer { FirstName = "Ian", LastName = "Orange", Email = "ian.orange@example.com", PhoneNumber = "567-890-1235", Address = "567 Orange St", PlanID = 4 },
                new Customer { FirstName = "Julia", LastName = "Pink", Email = "julia.pink@example.com", PhoneNumber = "678-901-2346", Address = "890 Pink St", PlanID = 5 }
            };
            context.Customers.AddRange(customers);
            context.SaveChanges();
        }
    }
}