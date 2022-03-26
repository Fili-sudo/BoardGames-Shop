// See https://aka.ms/new-console-template for more information
using Domain;

List<string> categories1 = new List<string> { "Edible", "Fruits" };
List<string> categories2 = new List<string> { "Appliances", "TV's" };

Product product1 = new Product("Apple", 3.2, 70, categories1);
product1.AddCategory("Food");
foreach (var category in product1.Categories)
{
    Console.WriteLine(category);
}
product1.UpdateCategoryName("Fruits", "Exotics");
foreach (var category in product1.Categories)
{
    Console.WriteLine(category);
}
product1.RemoveCategory("Exotics");
foreach (var category in product1.Categories)
{
    Console.WriteLine(category);
}

Product product2 = new Product("Samsung", 3200, 20, categories2);

List<OrderItem> orderitems1 = new List<OrderItem>
{
    new OrderItem(product1, 3),
    new OrderItem(product2, 1)
};
OrderItem anItem = new OrderItem(new Product("Bannana", 2.7, 80, categories1), 5) { Id = 1 };
Order order1 = new Order(orderitems1, States.Pending, "someAddress") { Id = 1 };
Console.WriteLine(order1);
order1.AddOrderItem(anItem);
Console.WriteLine(order1);
order1.UpdateOrderItemQuantity(anItem, 7);
Console.WriteLine(order1);
order1.UpdateOrderItemQuantity(anItem, 4);
Console.WriteLine(order1);
order1.RemoveOrderItem(anItem);
Console.WriteLine(order1);
order1.RemoveOrderItem(new OrderItem (product1, 3));
Console.WriteLine(order1);




