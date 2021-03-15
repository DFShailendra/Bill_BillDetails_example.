using CustomerBillDetails.Models;
using CustomerBillDetails.Repository;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerBillDetails.Controllers
{
    public class DetailController : Controller
    {
        // GET: Detail
        public ActionResult Index()
        {
            DetailRepository detailRepository = new DetailRepository();
            ModelState.Clear();
            return View(detailRepository.GetAll());
        }

        // GET: Detail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Detail/Create
        public ActionResult Create()
        {
            DetailRepository detailRepository = new DetailRepository();
            dynamic mymodel = new ExpandoObject();

            return View();
        }

        // POST: Detail/Create
        [HttpPost]
        public ActionResult Create(DetailModel obj,FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    DetailRepository detailRepository = new DetailRepository();

                    if (detailRepository.AddDetail(obj))
                    {
                        ViewBag.Message = "Bill details added successfully";
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Detail/Edit/5
        public ActionResult Edit(int id)
        {
            DetailRepository detailRepository = new DetailRepository();
            return View(detailRepository.GetAll().Find(obj => obj.BillDetailsId == id));
        }

        // POST: Detail/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DetailModel obj, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                DetailRepository detailRepository = new DetailRepository();

                detailRepository.Update(obj);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Detail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Detail/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                DetailRepository detailRepository = new DetailRepository();
                if (detailRepository.Delete(id))
                {
                    ViewBag.AlertMsg = "Details deleted successfully";

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public JsonResult AddItemDetails(List<DetailModel> persons)
        {
            //to do something
            string data = "";
            foreach (DetailModel person in persons)
            {
                data += person.ItemName;
            }
            return Json(data);
        }

    }
}
