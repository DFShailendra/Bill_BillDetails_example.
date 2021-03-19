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

        public ActionResult Dropdown()
        {
            customer_detailsEntities2 myentity = new customer_detailsEntities2();
            var getItemList = myentity.Items.ToList();
            SelectList list = new SelectList(getItemList, "ItemId", "ItemName");
            ViewBag.ItemNameList = list;
            return View();
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
        public ActionResult Create(BillModel objBillModel)
        {
            //, DetailModel objDetailModel
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    //BillRepository billRepository = new BillRepository();

                    //if (billRepository.AddBill(objBillModel))
                    //{
                    //    ViewBag.Message = "Bill details added successfully";
                    //}
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


        public JsonResult AddItemDetails(List<BillModel> persons)
        {
            //to do something
            string data = "";
            foreach (BillModel person in persons)
            {
                data += person.objDetailModel.ItemName; 
            }
            return Json(data);
        }

    }
}
