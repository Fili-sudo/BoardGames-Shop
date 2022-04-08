// See https://aka.ms/new-console-template for more information


using PlayedWellGames.Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PlayedWellGames.Application;
using PlayedWellGames.Application.Users.Querries;
using PlayedWellGames.Application.Users.Commands;
using PlayedWellGames.Application.Products.Commands;
using PlayedWellGames.Application.Products.Queries;
using PlayedWellGames.Application.OrderItems.Commands;
using PlayedWellGames.Application.OrderItems.Queries;
using PlayedWellGames.Application.Orders.Commands;
using PlayedWellGames.Application.Orders.Queries;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var diContainer = new ServiceCollection()
            .AddMediatR(typeof(IUserRepository))
            .AddScoped<IUserRepository, InMemoryUserRepository>()
            .AddScoped<IProductRepository, InMemoryProductRepository>()
            .AddScoped<IOrderItemRepository, OrderItemRepository>()
            .AddScoped<IOrderRepository, InMemoryOrderRepository>()
            .BuildServiceProvider();

        var mediator = diContainer.GetRequiredService<IMediator>();

        //var user_repo = new InMemoryUserRepository();
        //user_repo.AddUser(new PlayedWellGames.Core.User
        //{
        //    Id = 1, Address = "some Address", FirstName = "First Name", LastName = "Last Names" 
        //});
        var id1 = mediator.Send(new AddUserCommand
        {
            Id = 1,
            FirstName = "Gigel",
            LastName = "Ionut"
        });
        var id2 = mediator.Send(new AddUserCommand
        {
            Id = 2,
            FirstName = "Ana",
            LastName = "Maria"
        });

        var users = await mediator.Send(new GetUsersQuery());
        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
        Console.WriteLine();
        Console.WriteLine(await mediator.Send(new GetUserByIdQuery { Id = 2 }));
        Console.WriteLine();


        //var deletedUser = await mediator.Send(new DeleteUserCommand { Id = 2 });
        users = await mediator.Send(new GetUsersQuery());
        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
        Console.WriteLine();



        var productid1 = mediator.Send(new AddProductCommand
        {
            Id = 1,
            ProductName = "Catan",
            Description = "",
            Price = 45,
            Quantity = 20,
            Tags = new List<string> { "Family", "Dice", "Strategy"}
        });
        var productid2 = mediator.Send(new AddProductCommand
        {
            Id = 2,
            ProductName = "Uno",
            Description = "",
            Price = 15,
            Quantity = 25,
            Tags = new List<string> { "Cards", "Family", "Fun"}
        });

        var products = await mediator.Send(new GetAllProductsQuery());
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }
        Console.WriteLine();
        Console.WriteLine(await mediator.Send(new GetProductByIdQuery { Id = 1 }));
        Console.WriteLine();

        //var deletedProduct = await mediator.Send(new DeleteProductCommand { Id = 1 });
        products = await mediator.Send(new GetAllProductsQuery());
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }
        Console.WriteLine();


        var orderItemid1 = await mediator.Send(new AddOrderItemCommand
        {
            Id = 1,
            ProductId = 1,
            Product = await mediator.Send(new GetProductByIdQuery { Id = 1 }),
            Quantity = 1
        });
        var orderItemid2 = await mediator.Send(new AddOrderItemCommand
        {
            Id = 2,
            ProductId = 2,
            Product = await mediator.Send(new GetProductByIdQuery { Id = 2 }),
            Quantity = 1
        });
        var orderItemid3 = await mediator.Send(new AddOrderItemCommand
        {
            Id = 3,
            ProductId = 1,
            Product = await mediator.Send(new GetProductByIdQuery { Id = 1 }),
            Quantity = 2
        });
        var orderItemid4 = await mediator.Send(new AddOrderItemCommand
        {
            Id = 4,
            ProductId = 1,
            Product = await mediator.Send(new GetProductByIdQuery { Id = 2 }),
            Quantity = 2
        });
        var orderItems = await mediator.Send(new GetAllOrderItemsQuery());
        foreach (var orderItem in orderItems)
        {
            Console.WriteLine(orderItem);
        }
        Console.WriteLine();
        Console.WriteLine(await mediator.Send(new GetOrderItemByIdQuery { Id = 2 }));
        Console.WriteLine();


        //var deletedOrderItem = await mediator.Send(new DeleteOrderItemCommand { Id = 1 });
        orderItems = await mediator.Send(new GetAllOrderItemsQuery());
        foreach (var orderItem in orderItems)
        {
            Console.WriteLine(orderItem);
        }

        Console.WriteLine();
        var orderid1 = await mediator.Send(new AddOrderCommand
        {
            Id = 1,
            OrderItems = orderItems.GetRange(0,2),            
            State = 0,
            Price = 120,
            User = null,
            UserId = -1,
            ShippingAddress = "some Address"
        });
        var orderid2 = await mediator.Send(new AddOrderCommand 
        {
            Id = 2,
            OrderItems = orderItems.GetRange(2, 2),
            State = 0,
            Price = 220,
            User = null,
            UserId = -1,
            ShippingAddress = "some other Address"
        });

        var orders = await mediator.Send(new GetAllOrdersQuery());
        foreach(var order in orders)
        {
            Console.WriteLine(order);
        }
        Console.WriteLine();
        Console.WriteLine(await mediator.Send(new GetOrderByIdQuery { Id = 2 }));
    }
}
