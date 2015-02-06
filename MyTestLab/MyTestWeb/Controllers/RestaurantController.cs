using System.Collections.Generic;
using System.Web.Mvc;
using MyTestWeb.Models;

namespace MyTestWeb.Controllers
{
    public class RestaurantController : Controller
    {
        public ActionResult Index()
        {
            var menu = MenuItems();
            
            return View(menu);
        }
      
        public ActionResult Detail(string id)
        {
            var itemDetail = new ItemDetail
            {
                Ingredients = id.Equals("ST001") ? "Veg Samosa Filling" : "Chilli Mogo Filling"
            };

            return View(itemDetail);
        }

        private List<Item> MenuItems()
        {
            var menuItems = new List<Item>()
            {
                new Item()
                {
                    ItemCode = "ST001",
                    ItemName = "Veg Samosa",
                    Price = "2.99",
                },
                new Item()
                {
                    ItemCode = "ST002",
                    ItemName = "Chilli Mogo",
                    Price = "4.99",
                },
            };
            return menuItems;
        }
        
        [HttpGet]
        public ActionResult Add()
        {
            var item = new Item();
            return View(item);
        }


        [HttpPost]
        public ActionResult Update(Item formCollection)
        {
            return View("Add", formCollection);
        }
    }
}
