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

internal class Program
{
    private static async Task Main(string[] args)
    {
        var diContainer = new ServiceCollection()
            .AddMediatR(typeof(IUserRepository))
            .AddScoped<IUserRepository, InMemoryUserRepository>()
            .AddScoped<IProductRepository, InMemoryProductRepository>()
            .AddScoped<IOrderItemRepository, OrderItemRepository>()
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
        var orderItems = await mediator.Send(new GetAllOrderItemsQuery());
        foreach (var orderItem in orderItems)
        {
            Console.WriteLine(orderItem);
        }
        Console.WriteLine();
        Console.WriteLine(await mediator.Send(new GetOrderItemByIdQuery { Id = 2 }));

    }
}
