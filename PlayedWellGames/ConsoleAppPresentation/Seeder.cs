//using Microsoft.EntityFrameworkCore;
//using PlayedWellGames.Core;
//using PlayedWellGames.Infrastructure.Data;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleAppPresentation
//{
//    public class Seeder
//    {
//        public static void SeedData()
//        {
//            var contextOptions = new DbContextOptionsBuilder<AppDbContext>()
//                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PlayedWellGamesDatabase")
//                .Options;
//            var context = new AppDbContext(contextOptions);

//            context.Database.EnsureDeleted();
//            context.Database.EnsureCreated();
        
//            var users = GetPreconfiguredUsers().ToList();
//            var products = GetPreconfiguredProducts().ToList();
//            var orderItems = GetPreconfiguredOrderItems(products).ToList();
//            var orders = GetPreconfiguredOrder(orderItems, users).ToList();
        
//            context.Users.AddRange(users);
//            context.Products.AddRange(products);
//            context.OrderItems.AddRange(orderItems);
//            context.Orders.AddRange(orders);
        
//            context.SaveChanges();
//        }
        
//        public static IEnumerable<User> GetPreconfiguredUsers()
//        {
//            List<User> users = new List<User>();
        
//            users.Add(new User 
//            { 
//                FirstName = "Geraldine", 
//                LastName = "Lewis", 
//                UserName = "geraldine.lewis",
//                Pass = "1234", 
//                Mail = "geraldine.lewis@gmail.com", 
//                Address = "61 Dover Road",
//                Phone = "(777)249-9909", 
//                Role = Role.Regular,
//            });
//            users.Add(new User
//            {
//                FirstName = "Eddie",
//                LastName = "Robertson",
//                UserName = "eddie.robertson",
//                Pass = "1234",
//                Mail = "eddie.robertson@gmail.com",
//                Address = "83 Balsham Road",
//                Phone = "(777)249-9910",
//                Role = Role.Regular,
//            });
//            users.Add(new User
//            {
//                FirstName = "Teresa",
//                LastName = "Figueroa",
//                UserName = "teresa.figueroa",
//                Pass = "1234",
//                Mail = "teresa.figueroa@gmail.com",
//                Address = "48 Bury Rd",
//                Phone = "(777)249-9911",
//                Role = Role.Regular,
//            });
//            users.Add(new User
//            {
//                FirstName = "Velma",
//                LastName = "Gibson",
//                UserName = "velma.gibson",
//                Pass = "1234",
//                Mail = "velma.gibson@gmail.com",
//                Address = "38 Argyll Street",
//                Phone = "(777)249-9912",
//                Role = Role.Regular,
//            });
//            users.Add(new User
//            {
//                FirstName = "Renee",
//                LastName = "Lopez",
//                UserName = "renee.lopez",
//                Pass = "1234",
//                Mail = "renee.lopez@gmail.com",
//                Address = "9 Ploughley Rd",
//                Phone = "(777)249-9913",
//                Role = Role.Regular,
//            });
//            users.Add(new User
//            {
//                FirstName = "Brenda",
//                LastName = "Carpenter",
//                UserName = "brenda.carpenter",
//                Pass = "1234",
//                Mail = "brenda.carpenter@gmail.com",
//                Address = "13 Earls Avenue",
//                Phone = "(777)249-9914",
//                Role = Role.Regular,
//            });
//            users.Add(new User
//            {
//                FirstName = "Austin",
//                LastName = "Shelton",
//                UserName = "austin.shelton",
//                Pass = "1234",
//                Mail = "austin.shelton@gmail.com",
//                Address = "72 Merthyr Road",
//                Phone = "(777)249-9915",
//                Role = Role.Regular,
//            });
//            users.Add(new User
//            {
//                FirstName = "Lucille",
//                LastName = "Craig",
//                UserName = "lucille.craig",
//                Pass = "1234",
//                Mail = "lucille.craig@gmail.com",
//                Address = "4 Wenlock Terrace",
//                Phone = "(777)249-9916",
//                Role = Role.Regular,
//            });
//            users.Add(new User
//            {
//                FirstName = "Mike",
//                LastName = "Holloway",
//                UserName = "mike.holloway",
//                Pass = "1234",
//                Mail = "mike.holloway@gmail.com",
//                Address = "99 Harrogate Road",
//                Phone = "(777)249-9917",
//                Role = Role.Regular,
//            });
//            users.Add(new User
//            {
//                FirstName = "Julius",
//                LastName = "Bryan",
//                UserName = "julius.bryan",
//                Pass = "1234",
//                Mail = "julius.bryan@gmail.com",
//                Address = "48 Seaford Road",
//                Phone = "(777)249-9918",
//                Role = Role.Regular,
//            });
//            return users;
//        }
//        public static IEnumerable<Product> GetPreconfiguredProducts()
//        {
//            List<Product> products = new List<Product>();
        
//            products.Add(new Product
//            {
//                ProductName = "Catan",
//                Description = "Catan Description",
//                Price = 45,
//                Quantity = 10,
//                Tags = "Family, Dice, Strategy"
//            });
//            products.Add(new Product
//            {
//                ProductName = "Root",
//                Description = "Root Description",
//                Price = 70,
//                Quantity = 10,
//                Tags = "Cards, Dice, Strategy"
//            });
//            products.Add(new Product
//            {
//                ProductName = "Uno",
//                Description = "Uno Description",
//                Price = 10,
//                Quantity = 10,
//                Tags = "Family, Cards, Fun"
//            });
//            products.Add(new Product
//            {
//                ProductName = "Cluedo",
//                Description = "Cluedo Description",
//                Price = 30,
//                Quantity = 10,
//                Tags = "Mistery, Logoic, Strategy"
//            });
//            products.Add(new Product
//            {
//                ProductName = "Secret Hitler",
//                Description = "Secret Hitler Description",
//                Price = 40,
//                Quantity = 10,
//                Tags = "Strategy, Group, Fun"
//            });
//            products.Add(new Product
//            {
//                ProductName = "Exploding Kittens",
//                Description = "Exploding Kittens Description",
//                Price = 20,
//                Quantity = 10,
//                Tags = "Cards, Family, Short"
//            });
//            products.Add(new Product
//            {
//                ProductName = "Activity",
//                Description = "Activity Description",
//                Price = 10,
//                Quantity = 10,
//                Tags = "Family, Cards, Fun"
//            });
//            products.Add(new Product
//            {
//                ProductName = "Dixit",
//                Description = "Dixit Description",
//                Price = 35,
//                Quantity = 10,
//                Tags = "Cards, Quess, Group"
//            });
//            products.Add(new Product
//            {
//                ProductName = "Citadele",
//                Description = "Citadele Description",
//                Price = 25,
//                Quantity = 10,
//                Tags = "Strategy, Cards, Dynamic"
//            });
//            products.Add(new Product
//            {
//                ProductName = "Monopoly",
//                Description = "Monopoly Description",
//                Price = 20,
//                Quantity = 10,
//                Tags = "Dice, Family, Money"
//            });
        
//            return products;
//        }
        
//        public static IEnumerable<OrderItem> GetPreconfiguredOrderItems(List<Product> products)
//        {
//            var orderItems = new List<OrderItem>();
        
//            orderItems.Add(new OrderItem
//            {
//                Product = products.ElementAt(0),
//                Quantity = 1
//            });
//            orderItems.Add(new OrderItem
//            {
//                Product = products.ElementAt(1),
//                Quantity = 1
//            });
//            orderItems.Add(new OrderItem
//            {
//                Product = products.ElementAt(2),
//                Quantity = 2
//            });
//            orderItems.Add(new OrderItem
//            {
//                Product = products.ElementAt(3),
//                Quantity = 1
//            });
//            orderItems.Add(new OrderItem
//            {
//                Product = products.ElementAt(4),
//                Quantity = 1
//            });
//            orderItems.Add(new OrderItem
//            {
//                Product = products.ElementAt(5),
//                Quantity = 2
//            });
            
//            return orderItems;
//        }
        
//        public static IEnumerable<Order> GetPreconfiguredOrder(List<OrderItem> orderItems, List<User> users)
//        {
//            var orders = new List<Order>();
        
//            orders.Add(new Order(orderItems.GetRange(0, 2), States.Pending, users.ElementAt(0)));
//            orders.Add(new Order(orderItems.GetRange(2, 2), States.Pending, users.ElementAt(1)));
//            orders.Add(new Order(orderItems.GetRange(4, 2), States.Pending, users.ElementAt(2)));
        
        
//            return orders;
        
//        }
//    }
//}
