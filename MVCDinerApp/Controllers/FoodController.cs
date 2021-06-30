﻿using DataLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDinerApp.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFoodData _foodData;

        public FoodController(IFoodData foodData)
        {
            _foodData = foodData;
        }
        public async Task<IActionResult> Index()
        {
            var food = await _foodData.GetFood();

            return View(food);
        }
    }
}
