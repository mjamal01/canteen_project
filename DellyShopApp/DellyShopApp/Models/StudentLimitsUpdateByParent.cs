using System;
using System.Collections.Generic;

namespace DellyShopApp.Models
{
    public class StudentLimitsUpdateByParent
    {
        public long CustomerId { get; set; }
        public decimal DailyAllowedMoney { get; set; }
        public List<ProductLimitsByParent> listOfQtyLimits { get; set; }
        public StudentLimitsUpdateByParent()
        {
            listOfQtyLimits = new List<ProductLimitsByParent>();
        }
    }
    public class ProductLimitsByParent
    {
        public long ProductId { get; set; }
        public decimal QtyLimit { get; set; }
        public string DailyQty7Days { get; set; }
    }
}
