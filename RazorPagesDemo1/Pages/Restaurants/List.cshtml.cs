using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using RazorPagesDemo1.Core;
using RazorPagesDemo1.Data;
using System.Collections.Generic;

namespace RazorPagesDemo1.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IRestaurantData _restaurantData;

        public ListModel(IConfiguration configuration, IRestaurantData restaurantData)
        {
            _configuration = configuration;
            _restaurantData = restaurantData;
        }
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public void OnGet()
        {
            Message = _configuration["Message"];
            Restaurants = _restaurantData.GetRestaurantsByName(SearchTerm); 
        }
    }
}