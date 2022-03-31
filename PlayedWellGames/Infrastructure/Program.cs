// See https://aka.ms/new-console-template for more information
using Domain;
using Infrastructure;



InMemoryUserRepository UserRepo = new InMemoryUserRepository();
User user1 = new User { Id = 1, FirstName = "Marcel", LastName = "Bogosel" };
User user2 = new User { Id = 2, FirstName = "Oana", LastName = "Aioanei" };
User updatedUser = new User { Id = 2, FirstName = "New", LastName = "One" };

UserRepo.AddUser(user1);
UserRepo.AddUser(user2);

List<User> userList = UserRepo.GetUsers().ToList();
foreach (User user in userList)
{
    Console.WriteLine(user);
}
Console.WriteLine();
Console.WriteLine(UserRepo.GetUserById(2));
Console.WriteLine();
UserRepo.UpdateUser(user1, updatedUser);
userList = UserRepo.GetUsers().ToList();
foreach (User user in userList)
{
    Console.WriteLine(user);
}
Console.WriteLine();
UserRepo.DeleteUser(1);
userList = UserRepo.GetUsers().ToList();
foreach (User user in userList)
{
    Console.WriteLine(user);
}
Console.WriteLine();

InMemoryProductRepository productRepo = new InMemoryProductRepository();
Product product1 = new Product { Id = 1, Tags = new List<string> { "4 players", "strategy", "dice" }, ProductName = "Catan", Price = 45, Quantity = 15 };
Product product2 = new Product { Id = 2, Tags = new List<string> { "4 players", "strategy", "cards", "dice" }, ProductName = "Root", Price = 60, Quantity = 10 };
Product product3 = new Product { Id = 3, Tags = new List<string> { "cards", "family", "fun" }, ProductName = "Uno", Price = 15, Quantity = 30 };
Product updatedProduct = new Product { Id = 3, Tags = new List<string> { "cards", "family", "fun" }, ProductName = "Saboteur", Price = 15, Quantity = 30 };

productRepo.AddProduct(product1);
productRepo.AddProduct(product2);
productRepo.AddProduct(product3);
List<Product> productList = productRepo.GetProducts().ToList();
foreach (Product product in productList)
{
    Console.WriteLine(product);
}
Console.WriteLine();
Console.WriteLine(productRepo.GetProductById(2));
Console.WriteLine();
productRepo.UpdateProduct(product3, updatedProduct);
foreach (Product product in productList)
{
    Console.WriteLine(product);
}
Console.WriteLine();
productRepo.DeleteProduct(1);
productList = productRepo.GetProducts().ToList();
foreach (Product product in productList)
{
    Console.WriteLine(product);
}

