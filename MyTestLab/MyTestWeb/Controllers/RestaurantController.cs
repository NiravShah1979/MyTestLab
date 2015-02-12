using System.Collections.Generic;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MyTestWeb.Models;

namespace MyTestWeb.Controllers
{
    public class RestaurantController : Controller
    {
        public ActionResult Index()
        {
            var baseItem = new List<BaseItem>()
            {
                new BaseItem() { ItemType = ItemType.Starter }, 
                new BaseItem() { ItemType = ItemType.Main }
            };
            baseItem[0].Item = StarterMenuItems();
            baseItem[1].Item = MainsMenuItems();
            return View(baseItem);
        }

        public ActionResult Detail(string id)
        {
            var itemDetail = new ItemDetail
            {
                Ingredients = id.Equals("ST001") ? "Veg Samosa Filling" : "Chilli Mogo Filling"
            };

            return View(itemDetail);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var item = new Item
            {
                ItemTypes = BuildDropdown()
            };
            return View(item);
        }

        public ActionResult StartersGrid([DataSourceRequest]DataSourceRequest request)
        {
            return Json(StarterMenuItems().ToDataSourceResult(request));
        }

        public ActionResult MainsGrid([DataSourceRequest]DataSourceRequest request)
        {
            return Json(MainsMenuItems().ToDataSourceResult(request));
        }

        [ValidateInput(true)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(Item item)
        {
            item.ItemTypes = BuildDropdown();
            return View("Add", item);
        }

        public ActionResult Mains(string id)
        {
            var mains = MainsMenuItems();
            return PartialView("_Mains", mains);
        }

        public PartialViewResult Starters(string id)
        {
            var starters = StarterMenuItems();
            return PartialView("_Starters", starters);
        }

        private List<Item> StarterMenuItems()
        {
            var menuItems = new List<Item>()
            {
                new Item()
                {
                    ItemCode = "ST001",
                    ItemName = "Veg Samosa",
                    ItemTypes = new List<SelectListItem> { new SelectListItem() { Text = ItemType.Starter.ToString(), Value = ItemType.Starter.ToString() } },
                    Price = "2.99",
                },
                new Item()
                {
                    ItemCode = "ST002",
                    ItemName = "Chilli Mogo",
                    ItemTypes = new List<SelectListItem> { new SelectListItem() { Text = ItemType.Starter.ToString(), Value = ItemType.Starter.ToString() } },
                    Price = "4.99",
                },
            };
            return menuItems;
        }

        private List<Item> MainsMenuItems()
        {
            var menuItems = new List<Item>()
            {
                new Item()
                {
                    ItemCode = "MI001",
                    ItemName = "Veg Kofta",
                    ItemTypes = new List<SelectListItem> { new SelectListItem() { Text = ItemType.Main.ToString(), Value = ItemType.Main.ToString() } },
                    Price = "5.99",
                },
                new Item()
                {
                    ItemCode = "MI002",
                    ItemName = "Paneer Butter Masala",
                    ItemTypes = new List<SelectListItem> { new SelectListItem() { Text = ItemType.Main.ToString(), Value = ItemType.Main.ToString() } },
                    Price = "6.99",
                },
            };
            return menuItems;
        }

        private List<SelectListItem> BuildDropdown()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Selected = false,
                    Text = ItemType.Starter.ToString(),
                    Value = ItemType.Starter.ToString()
                },
                new SelectListItem()
                {
                    Selected = false,
                    Text = ItemType.Main.ToString(),
                    Value = ItemType.Main.ToString()
                },
                new SelectListItem()
                {
                    Selected = false,
                    Text = ItemType.Desserts.ToString(),
                    Value = ItemType.Desserts.ToString()
                }
            };
        }
    }
}
