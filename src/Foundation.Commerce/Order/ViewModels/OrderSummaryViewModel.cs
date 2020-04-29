using Mediachase.Commerce;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Foundation.Commerce.Order.ViewModels
{
    public class OrderSummaryViewModel
    {
        public Money SubTotal { get; set; }
        public IEnumerable<OrderDiscountViewModel> OrderDiscounts { get; set; }
        public Money OrderDiscountTotal { get; set; }
        public Money ShippingDiscountTotal { get; set; }
        public Money ShippingTotal { get; set; }
        public Money ShippingSubtotal { get; set; }
        public Money TaxTotal { get; set; }
        public Money ShippingTaxTotal { get; set; }
        public Money CartTotal { get; set; }
        public decimal PaymentTotal { get; set; }

        public List<SelectListItem> Rewards { get; set; }
        public string Reward { get; set; }
        public string Points { get; set; }
    }
}