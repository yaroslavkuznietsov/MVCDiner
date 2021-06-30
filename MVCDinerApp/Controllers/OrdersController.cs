using DataLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCDinerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDinerApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IFoodData _foodData;
        private readonly IOrderData _orderData;

        public OrdersController(IFoodData foodData, IOrderData orderData)
        {
            _foodData = foodData;
            _orderData = orderData;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var food = await _foodData.GetFood();

            OrderCreateModel model = new OrderCreateModel();

            food.ForEach(x =>
           {
               model.FoodItems.Add(new SelectListItem { Value = x.Id.ToString(), Text = x.Title + " / " + string.Format("{0:C}", x.Price) + " /" });
           });

            return View(model);
        }
    }
}
