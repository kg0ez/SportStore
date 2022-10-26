using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportStore.Common;
using SportStore.Common.ModelDto;
using SportStore.WebApplication.Handler;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportStore.WebApplication.Controllers
{
    public class GoodsController : Controller
    {
        public IActionResult Index()
        {
            var typeAction = QueryHandler<QueryGoodsType>.QueryTypeSerialize(QueryGoodsType.GetGoods);

            string json = QueryHandler<int>.Serialize(0, QueryType.Goods, typeAction);

            string answer = ConnectionHandler.ConnectionWithServ(json);

            var goods = JsonSerializer.Deserialize<List<ClothesDto>>(answer);

            return View(goods);
        }

        public IActionResult AboutGoods(Nullable<int> id)
        {
            if (!id.HasValue)
                return NotFound();

            var typeAction = QueryHandler<QueryGoodsType>.QueryTypeSerialize(QueryGoodsType.Get);

            string json = QueryHandler<int>.Serialize((int)id, QueryType.Goods, typeAction);

            string answer = ConnectionHandler.ConnectionWithServ(json);

            var detail = JsonSerializer.Deserialize<ClothesDto>(answer);

            if (detail != null)
                return View(detail);

            return NotFound();
        }
    }
}

