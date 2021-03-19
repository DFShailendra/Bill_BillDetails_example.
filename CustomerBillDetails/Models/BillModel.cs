using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerBillDetails.Models
{
    public class BillModel
    {
        [Display(Name = "Id")]
        public int BillId { get; set; }

        [Required(ErrorMessage = "Bill Number is required.")]
        public int BillNumber { get; set; }

        [Display(Name = "Bill Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BillDate { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Contact_Number is required.")]
        public int ContactNumber { get; set; }

        public int Total { get; set; }

        public DetailModel objDetailModel = new DetailModel();
        //public List<DetailModel> objDetailModelList = new List<DetailModel>();
    }

}