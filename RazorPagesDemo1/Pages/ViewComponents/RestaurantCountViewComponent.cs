using Microsoft.AspNetCore.Mvc;
using RazorPagesDemo1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesDemo1.Pages.ViewComponents
{
    public class RestaurantCountViewComponent
        : ViewComponent
    {
        private readonly IRestaurantData restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IViewComponentResult Invoke()
        {
            var count = restaurantData.GetCountOfRestaurants();
            return View(count);
        }
    }
}
