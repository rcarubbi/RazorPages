using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo1.Core;
using RazorPagesDemo1.Data;

namespace RazorPagesDemo1.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public Restaurant Restaurant { get; set; }

        [TempData]
        public string Message { get; set; }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}