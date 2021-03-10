using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerBillDetails.Models
{
    public class ItemModel
    {
        [Display(Name = "Id")]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Item Rate is required.")]
        public int ItemRate { get; set; }

    }
}