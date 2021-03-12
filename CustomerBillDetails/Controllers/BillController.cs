using CustomerBillDetails.Models;
using CustomerBillDetails.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerBillDetails.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        public ActionResult Index()
        {
            BillRepository billRepository = new BillRepository();
            ModelState.Clear();
            return View(billRepository.GetBill());
        
        }

        // GET: Bill/Details/5
        public ActionResult Details(int id)
        {
            BillRepository billRepository = new BillRepository();
            return View(billRepository.GetBill().Find(bill => bill.BillId == id));
        }

        // GET: Bill/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bill/Create
        [HttpPost]
        public ActionResult Create(BillModel bill)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    BillRepository billRepository = new BillRepository();

                    if (billRepository.AddBill(bill))
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

        // GET: Bill/Edit/5
        public ActionResult Edit(int id)
        {
            BillRepository billRepository = new BillRepository();
            return View(billRepository.GetBill().Find(bill => bill.BillId == id));
        }

        // POST: Bill/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BillModel obj)
        {
            try
            {
                // TODO: Add update logic here
                BillRepository billRepository = new BillRepository();

                billRepository.UpdateBill(obj);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bill/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bill/Delete/5
        [HttpPost]
        public ActionResult Delete(int Id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                BillRepository billRepository = new BillRepository();
                if (billRepository.DeleteBill(Id))
                {
                    ViewBag.AlertMsg = "Bill details deleted successfully";

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public JsonResult AddItemDetails(List<BillModel> itemDetails)
        {
            //to do something
            string data = "";
            foreach (BillModel itemDetail in itemDetails)
            {
                data += itemDetail.objDetailModel.ItemName + " " + itemDetail.objDetailModel.Quantity + "\n";
            }
            return Json(data);
        }

    }
}
