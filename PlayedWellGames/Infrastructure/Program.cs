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

InMemoryOrderRepository orderRepo = new InMemoryOrderRepository();

OrderItem orderItem1 = new OrderItem(product1, 3) { Id = 1 };
OrderItem orderItem2 = new OrderItem(product2, 4) { Id = 2 };
OrderItem orderItem3 = new OrderItem(product3, 2) { Id = 3 };
OrderItem updatedOrderItem = new OrderItem(product3, 5) { Id = 3 };
List<OrderItem> orderItemList1 = new List<OrderItem> { orderItem1, orderItem2 };
List<OrderItem> orderItemList2 = new List<OrderItem> { orderItem1, orderItem3 };
Order order1 = new Order(orderItemList1, States.Pending, "some Address") { Id = 1 };
Order order2 = new Order(orderItemList2, States.Pending, "another Address") { Id = 2 };

orderRepo.AddOrder(order1);
orderRepo.AddOrder(order2);
List<Order> orderList = orderRepo.GetOrders().ToList();
foreach (Order item in orderList)
{
    Console.WriteLine(item);
}
Console.WriteLine();
Console.WriteLine(orderRepo.GetOrderById(1));
Console.WriteLine();
orderRepo.UpdateOrder(2, orderItem3, updatedOrderItem);
foreach (Order item in orderList)
{
    Console.WriteLine(item);
}
Console.WriteLine();
orderRepo.DeleteOrderItem(2, updatedOrderItem);
foreach (Order item in orderList)
{
    Console.WriteLine(item);
}
Console.WriteLine();
orderRepo.DeleteOrder(2);
orderList = orderRepo.GetOrders().ToList();
foreach (Order item in orderList)
{
    Console.WriteLine(item);
}
