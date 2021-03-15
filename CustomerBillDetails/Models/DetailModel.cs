using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerBillDetails.Models
{
    public class DetailModel
    {
        [Display(Name = "Id")]
        public int BillDetailsId { get; set; }

        public string ItemName { get; set; }

        public IEnumerable<SelectListItem> ItemNameList { get; set; }

        public SelectList SelecttheItem { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Rate is required.")]
        public int ItemRate { get; set; }

        public int Total { get; set; }

        public int BillId { get; set; }
    }
}