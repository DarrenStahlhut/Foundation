﻿using AnnexCloud;
using EPiServer.Commerce.Order;
using EPiServer.Core;
using EPiServer.Editor;
using EPiServer.Web.Mvc.Html;
using EPiServer.Web.Routing;
using Foundation.Commerce.Customer.Services;
using Foundation.Commerce.Models.Pages;
using Foundation.Commerce.Order.Services;
using Foundation.Infrastructure.Services;
using System.Linq;
using System.Web.Mvc;

namespace Foundation.Features.MyAccount.OrderConfirmation
{
    public class OrderConfirmationController : OrderConfirmationControllerBase<OrderConfirmationPage>
    {
        private readonly ICampaignService _campaignService;
        public OrderConfirmationController(
            ICampaignService campaignService,
            ConfirmationService confirmationService,
            IAddressBookService addressBookService,
            IOrderGroupCalculator orderGroupCalculator,
            UrlResolver urlResolver, ICustomerService customerService) :
            base(confirmationService, addressBookService, orderGroupCalculator, urlResolver, customerService)
        {
            _campaignService = campaignService;
        }
        public ActionResult Index(OrderConfirmationPage currentPage, string notificationMessage, int? orderNumber)
        {
            IPurchaseOrder order = null;
            if (PageEditing.PageIsInEditMode)
            {
                order = _confirmationService.CreateFakePurchaseOrder();
            }
            else if (orderNumber.HasValue)
            {
                order = _confirmationService.GetOrder(orderNumber.Value);
            }

            if (order != null && order.CustomerId == _customerService.CurrentContactId)
            {
                var viewModel = CreateViewModel(currentPage, order);
                viewModel.NotificationMessage = notificationMessage;

                var service = new SaletrackApiService(order.GetTotal(), order.Forms.First().CouponCodes, order);
                _campaignService.UpdateLastOrderDate();
                _campaignService.UpdatePoint(decimal.ToInt16(viewModel.SubTotal.Amount));

                return View(viewModel);
            }

            return Redirect(Url.ContentUrl(ContentReference.StartPage));
        }
    }
}