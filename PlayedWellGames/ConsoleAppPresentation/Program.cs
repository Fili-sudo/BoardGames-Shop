// See https://aka.ms/new-console-template for more information


using PlayedWellGames.Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PlayedWellGames.Application;
using PlayedWellGames.Application.Users.Querries;
using PlayedWellGames.Application.Users.Commands;
using PlayedWellGames.Application.Products.Commands;
using PlayedWellGames.Application.Products.Queries;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var diContainer = new ServiceCollection()
            .AddMediatR(typeof(IUserRepository))
            .AddScoped<IUserRepository, InMemoryUserRepository>()
            .AddScoped<IProductRepository, InMemoryProductRepository>()
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


        var deleted = await mediator.Send(new DeleteUserCommand { Id = 2 });
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
    }
}
