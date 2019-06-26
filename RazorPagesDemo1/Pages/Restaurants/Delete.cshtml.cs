using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo1.Core;
using RazorPagesDemo1.Data;

namespace RazorPagesDemo1.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Restaurant Restaurant { get; set; }
        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            var restaurant = restaurantData.Delete(restaurantId);
            restaurantData.Commit();

            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message="] = $"{restaurant.Name} deleted";

            return RedirectToPage("./List");
        }
    }
}