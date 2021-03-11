using CustomerBillDetails.Models;
using CustomerBillDetails.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerBillDetails.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            ItemRepository itemRepository = new ItemRepository();
            ModelState.Clear();
            return View(itemRepository.GetItem());
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        public ActionResult Create(ItemModel obj,FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    ItemRepository itemRepository = new ItemRepository();

                    if (itemRepository.AddItem(obj))
                    {
                        ViewBag.Message = "Item added successfully";
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {
            ItemRepository itemRepository = new ItemRepository();



            return View(itemRepository.GetItem().Find(obj => obj.ItemId == id));
        }

        // POST: Item/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ItemModel obj, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                ItemRepository itemRepository = new ItemRepository();

                itemRepository.UpdateItem(obj);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Item/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ItemRepository itemRepository = new ItemRepository();
                if (itemRepository.DeleteItem(id))
                {
                    ViewBag.AlertMsg = "Item deleted successfully";

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
