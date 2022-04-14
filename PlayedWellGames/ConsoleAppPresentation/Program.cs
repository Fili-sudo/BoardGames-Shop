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
using PlayedWellGames.Infrastructure.Data;
using ConsoleAppPresentation;
using Microsoft.EntityFrameworkCore;
using PlayedWellGames.Core;

internal class Program
{
    private static async Task Main(string[] args)
    {

        var diContainer = new ServiceCollection()
            .AddDbContext<AppDbContext>(options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PlayedWellGamesDatabase"))
            .AddMediatR(typeof(IUserRepository))
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IOrderItemRepository, OrderItemRepository>()
            .AddScoped<IOrderRepository, OrderRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .BuildServiceProvider();

        var mediator = diContainer.GetRequiredService<IMediator>();

        var user = await mediator.Send(new GetUserByIdQuery { Id = 1 });

        user.Address = "Another Address";
        await mediator.Send(new UpdateUserCommand { Id = 1, NewUser = user});

        var product = await mediator.Send(new GetProductByIdQuery { Id = 2 });

        product.Price = 60;
        await mediator.Send(new UpdateProductCommand { Id = 2, NewProduct = product });

        await mediator.Send(new UpdateOrderItemQuantityCommand { Id = 1, newQuantity = 3 });

        var order = await mediator.Send(new GetOrderByIdQuery { Id = 1 });
        order.State = States.Confirmed;
        await mediator.Send(new UpdateOrderCommand { Id = 1, NewOrder = order });


        // var id1 = await mediator.Send(new AddUserCommand
        // {
        //     FirstName = "Ovidiu",
        //     LastName = "Bogosel",
        //     UserName = "ovidiu.bogosel",
        //     Pass = "1234",
        //     Mail = "ovidiu.bogosel@gmail.com",
        //     Address = "some Address",
        //     Phone = "(777)249-9909",
        //     Role = Role.Regular,
        // });


        //var id2 = mediator.Send(new AddUserCommand
        //{
        //    Id = 2,
        //    FirstName = "Ana",
        //    LastName = "Maria"
        //});
        //
        //var users = await mediator.Send(new GetUsersQuery());
        //foreach (var user in users)
        //{
        //    Console.WriteLine(user);
        //}
        //Console.WriteLine();
        //Console.WriteLine(await mediator.Send(new GetUserByIdQuery { Id = 11 }));
        //Console.WriteLine();
        //
        //
        //var deletedUser = await mediator.Send(new DeleteUserCommand { Id = 11 });
        //
        //
        //var productid1 = await mediator.Send(new AddProductCommand
        //{
        //    ProductName = "Alias",
        //    Description = "Alias description",
        //    Price = 20,
        //    Quantity = 10,
        //    Tags = "Family, Fun, Interaction"
        //});
        //var productid2 = mediator.Send(new AddProductCommand
        //{
        //    Id = 2,
        //    ProductName = "Uno",
        //    Description = "",
        //    Price = 15,
        //    Quantity = 25,
        //    Tags = "Cards, Family, Fun"
        //});
        //
        //var products = await mediator.Send(new GetAllProductsQuery());
        //foreach (var product in products)
        //{
        //    Console.WriteLine(product);
        //}
        //Console.WriteLine();
        //Console.WriteLine(await mediator.Send(new GetProductByIdQuery { Id = 1 }));
        //Console.WriteLine();
        //
        //var deletedProduct = await mediator.Send(new DeleteProductCommand { Id = 3 });

        //
        //
        //
        //var orderItemid1 = await mediator.Send(new AddOrderItemCommand
        //{
        //    Product = await mediator.Send(new GetProductByIdQuery { Id = 3 }),
        //    Quantity = 1
        //});
        //var orderItemid2 = await mediator.Send(new AddOrderItemCommand
        //{
        //    Id = 2,
        //    ProductId = 2,
        //    Product = await mediator.Send(new GetProductByIdQuery { Id = 2 }),
        //    Quantity = 1
        //});
        //var orderItemid3 = await mediator.Send(new AddOrderItemCommand
        //{
        //    Id = 3,
        //    ProductId = 1,
        //    Product = await mediator.Send(new GetProductByIdQuery { Id = 1 }),
        //    Quantity = 2
        //});
        //var orderItemid4 = await mediator.Send(new AddOrderItemCommand
        //{
        //    Id = 4,
        //    ProductId = 1,
        //    Product = await mediator.Send(new GetProductByIdQuery { Id = 2 }),
        //    Quantity = 2
        //});
        //Console.WriteLine();
        //var orderItems = await mediator.Send(new GetAllOrderItemsQuery());
        //foreach (var orderItem in orderItems)
        //{
        //    Console.WriteLine(orderItem);
        //}
        //Console.WriteLine();
        //Console.WriteLine(await mediator.Send(new GetOrderItemByIdQuery { Id = 1 }));
        //Console.WriteLine();
        //
        //
        //var deletedOrderItem = await mediator.Send(new DeleteOrderItemCommand { Id = 4 });
        //
        //Console.WriteLine();
        //var orderid1 = await mediator.Send(new AddOrderCommand
        //{
        //    OrderItems = orderItems.GetRange(7, 1),
        //    State = PlayedWellGames.Core.States.Pending,
        //    Price = 120,
        //    User = await mediator.Send(new GetUserByIdQuery { Id = 10 }),
        //    ShippingAddress = "some Address"
        //});
        //var orderid2 = await mediator.Send(new AddOrderCommand 
        //{
        //    Id = 2,
        //    OrderItems = orderItems.GetRange(2, 2),
        //    State = PlayedWellGames.Core.States.Pending,
        //    Price = 220,
        //    User = null,
        //    UserId = -1,
        //    ShippingAddress = "some other Address"
        //});

        //Console.WriteLine();
        //var orders = await mediator.Send(new GetAllOrdersQuery());
        //foreach(var order in orders)
        //{
        //    Console.WriteLine(order);
        //}
        //Console.WriteLine();
        //Console.WriteLine(await mediator.Send(new GetOrderByIdQuery { Id = 2 }));
        //
        //Console.WriteLine();
        //var deletedOrder = await mediator.Send(new DeleteOrderCommand { Id = 2 });


        //context.Database.EnsureDeleted();
        //context.Database.EnsureCreated();
        //await context.Users.AddAsync(new PlayedWellGames.Core.User
        //{
        //    FirstName = "Ovidiu",
        //    LastName = "Bogosel",
        //    UserName = "ovidiu.bogosel",
        //    Pass = "1234",
        //    Mail = "ovidiu.bogosel@gmail.com",
        //    Role = PlayedWellGames.Core.Role.Regular,
        //    Phone = "0755030799",
        //    Address = "some Address"
        //});
        //await context.Users.AddAsync(new PlayedWellGames.Core.User
        //{
        //    FirstName = "Timi",
        //    LastName = "Bogosel",
        //    UserName = "timi.bogosel",
        //    Pass = "1234",
        //    Mail = "timi.bogosel@gmail.com",
        //    Role = PlayedWellGames.Core.Role.Regular,
        //    Phone = "0755030800",
        //    Address = "some Address"
        //});
        //context.SaveChanges();



        //var usersFromDb = context.Users.ToList();
        //foreach(var user in usersFromDb)
        //{
        //    Console.Write(user.Id);
        //    Console.WriteLine(user);
        //}

        //Seeder.SeedData();

    }

    
}
