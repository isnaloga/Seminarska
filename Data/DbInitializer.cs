using IS_nal.Data;
using IS_nal.Models;
using System;
using System.Linq;
namespace IS_nal.Data;
public static class DbInitializer{
    public static void Initialize(FitnesContext context){
        context.Database.EnsureCreated();
        if(context.Trainers.Any()){
            return;
        }
        var trainers = new Trainer[]{
        new Trainer { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "123-456-7890" },
        new Trainer { FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", PhoneNumber = "234-567-8901" },
        new Trainer { FirstName = "Michael", LastName = "Johnson", Email = "michael.johnson@example.com", PhoneNumber = "345-678-9012" },
        new Trainer { FirstName = "Emily", LastName = "Davis", Email = "emily.davis@example.com", PhoneNumber = "456-789-0123" },
        new Trainer { FirstName = "David", LastName = "Wilson", Email = "david.wilson@example.com", PhoneNumber = "567-890-1234" },
        new Trainer { FirstName = "Sarah", LastName = "Brown", Email = "sarah.brown@example.com", PhoneNumber = "678-901-2345" }
        };
        context.Trainers.AddRange(trainers);
        context.SaveChanges();
        var plans = new Plan[]{
            new Plan { Name = "Basic Plan", Description = "Access to gym facilities and group classes", Price = 30, TrainerID = 1 },
            new Plan { Name = "Standard Plan", Description = "Includes personal training sessions and nutrition advice", Price = 50, TrainerID = 2},
            new Plan { Name = "Premium Plan", Description = "All-inclusive membership with unlimited personal training", Price = 80, TrainerID = 3 },
            new Plan { Name = "Family Plan", Description = "Membership for up to 4 family members", Price = 100, TrainerID = 4},
            new Plan { Name = "Student Plan", Description = "Discounted membership for students", Price = 20, TrainerID = 5}
    };
        context.Plans.AddRange(plans);
        context.SaveChanges();
        var customers = new Customer[]{
            new Customer { FirstName = "Alice", LastName = "Green", Email = "alice.green@example.com", PhoneNumber = "789-012-3456", PlanID = 1 },
            new Customer { FirstName = "Bob", LastName = "White", Email = "bob.white@example.com", PhoneNumber = "890-123-4567", PlanID = 2 },
            new Customer { FirstName = "Charlie", LastName = "Black", Email = "charlie.black@example.com", PhoneNumber = "901-234-5678", PlanID = 3 },
            new Customer { FirstName = "Diana", LastName = "Blue", Email = "diana.blue@example.com", PhoneNumber = "012-345-6789", PlanID = 4 },
            new Customer { FirstName = "Ethan", LastName = "Gray", Email = "ethan.gray@example.com", PhoneNumber = "123-456-7891", PlanID = 5 },
            new Customer { FirstName = "Fiona", LastName = "Red", Email = "fiona.red@example.com", PhoneNumber = "234-567-8902", PlanID = 1 },
            new Customer { FirstName = "George", LastName = "Yellow", Email = "george.yellow@example.com", PhoneNumber = "345-678-9013", PlanID = 2 },
            new Customer { FirstName = "Hannah", LastName = "Purple", Email = "hannah.purple@example.com", PhoneNumber = "456-789-0124", PlanID = 3 },
            new Customer { FirstName = "Ian", LastName = "Orange", Email = "ian.orange@example.com", PhoneNumber = "567-890-1235", PlanID = 4 },
            new Customer { FirstName = "Julia", LastName = "Pink", Email = "julia.pink@example.com", PhoneNumber = "678-901-2346", PlanID = 5 }
    };
        context.Customers.AddRange(customers);
        context.SaveChanges();
    }
}