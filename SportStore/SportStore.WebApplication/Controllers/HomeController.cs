using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using SportStore.Common;
using SportStore.Common.ModelDto;
using SportStore.WebApplication.Handler;
using SportStore.WebApplication.Models;

namespace SportStore.WebApplication.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult AddBusket(Nullable<int> id)
    {
        if (!id.HasValue)
            return NotFound();

        var typeAction = QueryHandler<QueryBasketType>.QueryTypeSerialize(QueryBasketType.Add);

        string json = QueryHandler<int>.Serialize((int)id, QueryType.Basket, typeAction);

        string answer = ConnectionHandler.ConnectionWithServ(json);

        var isAdded = JsonSerializer.Deserialize<bool>(answer);

        if (!isAdded)
            return NotFound();
        return RedirectPermanent("~/Goods/Index");
    }

    public IActionResult Basket()
    {
        var typeAction = QueryHandler<QueryBasketType>.QueryTypeSerialize(QueryBasketType.Get);

        string json = QueryHandler<int>.Serialize(0, QueryType.Basket, typeAction);

        string answer = ConnectionHandler.ConnectionWithServ(json);

        var basket = JsonSerializer.Deserialize<List<BasketDto>>(answer);

        return View(basket);
    }
    [HttpPost]
    public IActionResult DeleteBusket(Nullable<int> id)
    {
        if (!id.HasValue)
            return NotFound();

        var typeAction = QueryHandler<QueryBasketType>.QueryTypeSerialize(QueryBasketType.Delete);

        string json = QueryHandler<int>.Serialize((int)id, QueryType.Basket, typeAction);

        string answer = ConnectionHandler.ConnectionWithServ(json);

        var isDeleted = JsonSerializer.Deserialize<bool>(answer);

        if (!isDeleted)
            return NotFound();

        return RedirectToAction("Basket");
    }
    public IActionResult HistoryPayment()
    {
        var typeAction = QueryHandler<QueryHistoryType>.QueryTypeSerialize(QueryHistoryType.Get);

        string json = QueryHandler<int>.Serialize(0, QueryType.History, typeAction);

        string answer = ConnectionHandler.ConnectionWithServ(json);

        var history = JsonSerializer.Deserialize<List<HistoryDto>>(answer);
        
        return View(Enumerable.Reverse(history).ToList());
    }

    [HttpPost]
    public IActionResult Trash(int historyId)
    {
        var typeAction = QueryHandler<QueryHistoryType>.QueryTypeSerialize(QueryHistoryType.Delete);

        string json = QueryHandler<int>.Serialize(historyId, QueryType.History, typeAction);

        string answer = ConnectionHandler.ConnectionWithServ(json);

        var history = JsonSerializer.Deserialize<bool>(answer);

        return RedirectToActionPermanent("HistoryPayment", "Home");
    }

    [HttpPost]
    public IActionResult BuyFromBasket(Nullable<int> id)
    {
        if (!id.HasValue)
            return NotFound();

        var typeAction = QueryHandler<QueryBasketType>.QueryTypeSerialize(QueryBasketType.GetIdItem);

        string json = QueryHandler<int>.Serialize((int)id, QueryType.Basket, typeAction);

        string answer = ConnectionHandler.ConnectionWithServ(json);

        var detailId = JsonSerializer.Deserialize<int>(answer);

        BuyGoods(detailId);
        typeAction = QueryHandler<QueryBasketType>.QueryTypeSerialize(QueryBasketType.Delete);

        json = QueryHandler<int>.Serialize((int)id, QueryType.Basket, typeAction);

        answer = ConnectionHandler.ConnectionWithServ(json);

        var isDeleted = JsonSerializer.Deserialize<bool>(answer);

        if (!isDeleted)
            return NotFound();
        return RedirectToAction("Basket");

    }

    [HttpPost]
    public IActionResult BuyGoods(Nullable<int> id)
    {
        if (!id.HasValue)
            return NotFound();

        BuyGoods((int)id);

        return RedirectPermanent("~/Goods/Index");
    }
    private bool BuyGoods(int id)
    {
        var typeAction = QueryHandler<QueryHistoryType>.QueryTypeSerialize(QueryHistoryType.SyncGoods);

        string json = QueryHandler<int>.Serialize(id, QueryType.History, typeAction);

        string answer = ConnectionHandler.ConnectionWithServ(json);

        var isDone = JsonSerializer.Deserialize<bool>(answer);

        return isDone;
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

