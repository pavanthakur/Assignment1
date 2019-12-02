using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class Order : BaseEntity
    {
        public string CustomerID { get; set; }

        [DisplayName("Date/Time Order")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm:ss}")]
        public DateTime OrderDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        [DisplayName("Total Amount")]
        public decimal Total { get; set; }
    }
}
