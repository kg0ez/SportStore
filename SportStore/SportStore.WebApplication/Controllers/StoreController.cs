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
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            var typeAction = QueryHandler<QueryStoreType>.QueryTypeSerialize(QueryStoreType.Get);

            string json = QueryHandler<int>.Serialize(0, QueryType.Store, typeAction);

            string answer = ConnectionHandler.ConnectionWithServ(json);

            var store = JsonSerializer.Deserialize<List<ClothesStoreDto>>(answer);

            return View(store);
        }
    }
}

