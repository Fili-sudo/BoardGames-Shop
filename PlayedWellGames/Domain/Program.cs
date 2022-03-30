﻿// See https://aka.ms/new-console-template for more information
using Domain;

List<string> tags1 = new List<string> { "Edible", "Fruits" };
List<string> tags2 = new List<string> { "Appliances", "TV's" };

Product product1 = new Product("Apple", 3.2, 70, tags1) { Id = 1};
//product1.AddCategory("Food");
//foreach (var tag in product1.Tags)
//{
//    Console.WriteLine(tag);
//}
//product1.UpdateCategoryName("Fruits", "Exotics");
//foreach (var tag in product1.Tags)
//{
//    Console.WriteLine(tag);
//}
//product1.RemoveCategory("Exotics");
//foreach (var tag in product1.Tags)
//{
//    Console.WriteLine(tag);
//}

Product product2 = new Product("Samsung", 3200, 20, tags2) { Id = 2};

List<OrderItem> orderitems1 = new List<OrderItem>
{
    new OrderItem(product1, 3),
    new OrderItem(product2, 1)
};
//OrderItem anItem = new OrderItem(new Product("Bannana", 2.7, 80, tags1), 5) { Id = 1 };
//Order order1 = new Order(orderitems1, States.Pending, "someAddress") { Id = 1 };
//Console.WriteLine(order1);
//order1.AddOrderItem(anItem);
//Console.WriteLine(order1);
//order1.UpdateOrderItemQuantity(anItem, 7);
//Console.WriteLine(order1);
//order1.UpdateOrderItemQuantity(anItem, 4);
//Console.WriteLine(order1);
//order1.RemoveOrderItem(anItem);
//Console.WriteLine(order1);
//order1.RemoveOrderItem(new OrderItem (product1, 3));
//Console.WriteLine(order1);
Console.WriteLine(product1.Id);
Console.WriteLine(product2.Id);
Console.WriteLine(product1.Equals(product2));
Product identicalProduct2 = new Product("Samsung", 3200, 20, tags2) { Id = 2 };
Console.WriteLine(identicalProduct2.Equals(product2));

OrderItem orderItem1 = new OrderItem(product1, 3) { Id = 1};
OrderItem orderItem2 = new OrderItem(product2, 2) { Id = 2};
Console.WriteLine(orderItem1.Equals(orderItem2));
OrderItem identicalOrderItem2 = new OrderItem(product2, 2) { Id = 2 };
Console.WriteLine(identicalOrderItem2.Equals(orderItem2));






