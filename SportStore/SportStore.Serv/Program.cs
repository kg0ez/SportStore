using System.Net;
using System.Net.Sockets;
using AutoMapper;
using SportStore.BusinessLogic.Mapper;
using SportStore.BusinessLogic.Services;
using SportStore.Models;
using SportStore.Serv;
using SportStore.Serv.Services;
using Microsoft.Extensions.DependencyInjection;
using SportStore.Serv.Handler;

var mapperConfiguration = new MapperConfiguration(x =>
{
    x.AddProfile<MappingProfile>();
});

mapperConfiguration.AssertConfigurationIsValid();
IMapper mapper = mapperConfiguration.CreateMapper();

var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddSingleton<IActionClientService, ActionClientService>()
            .AddSingleton<SportStoreContext, SportStoreContext>()
            .AddSingleton<IBasketService, BasketService>()
            .AddSingleton<IBasketJService, BasketJService>()
            .AddSingleton<IGoodsService, GoodsService>()
            .AddSingleton<IGoodsJService, GoodsJService>()
            .AddSingleton<IStoreJService, StoreJService>()
            .AddSingleton<IStoreService, StoreService>()
            .AddSingleton<IHistoryJService, HistoryJService>()
            .AddSingleton<IHistoryService, HistoryService>()
            .AddSingleton(mapper)
            .BuildServiceProvider();

var goodsService = serviceProvider.GetService<IGoodsService>();
var actionClientService = serviceProvider.GetService<IActionClientService>();

//goodsService.Sync();
//Console.WriteLine("sex good");
//Console.ReadLine();

TcpListener listener = null;

string IP = "127.0.0.1";
int PORT = 8080;

try
{
    listener = new TcpListener(IPAddress.Parse(IP), PORT);
    listener.Start();

    while (true)
    {
        //Для входящих
        TcpClient client = listener.AcceptTcpClient();

        ConnectionHandler connection = new ConnectionHandler(
            client, actionClientService);

        Thread clientThread = new Thread(new ThreadStart(connection.ConnectionWithClient));
        clientThread.Start();
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    if (listener != null)
        listener.Stop();
}
