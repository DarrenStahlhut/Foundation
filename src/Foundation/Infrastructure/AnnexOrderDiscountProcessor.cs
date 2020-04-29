using EPiServer.Commerce.Marketing;
using EPiServer.Commerce.Order;
using System.Linq;

namespace Foundation.Infrastructure
{
    public class AnnexOrderDiscountProcessor : OrderPromotionProcessorBase<AnnexOrderDiscount>
    {
        protected override RewardDescription Evaluate(AnnexOrderDiscount promotionData,
            PromotionProcessorContext context)
        {
            var orderForm = context.OrderForm;
            var cart = context.OrderGroup as ICart;
            if (cart == null)
            {
                return NoReward(promotionData);
            }

            var value = cart.GetManualDiscount();
            if (value == 0)
            {
                return NoReward(promotionData);
            }


            return RewardDescription.CreateMoneyReward(
                FulfillmentStatus.Fulfilled,
                new[] { CreateRedemptionDescription(orderForm) },
                promotionData,
                value,
                description: $"{value} amount discount applied to order");
        }

        protected override bool CanBeFulfilled(
            AnnexOrderDiscount promotionData,
            PromotionProcessorContext context)
        {
            var cart = context.OrderGroup as ICart;
            if (cart == null)
            {
                return false;
            }

            return cart.GetManualDiscount() > 0;
        }

        private RewardDescription NoReward(PromotionData promotionData)
        {
            return new RewardDescription(
                    FulfillmentStatus.NotFulfilled,
                    Enumerable.Empty<RedemptionDescription>(),
                    promotionData,
                    unitDiscount: 0,
                    unitPercentage: 0,
                    rewardType: RewardType.None,
                    description: "No discount applied");
        }

        protected override PromotionItems GetPromotionItems(AnnexOrderDiscount promotionData)
        {
            return new PromotionItems(
                promotionData,
                new CatalogItemSelection(null, CatalogItemSelectionType.All, true),
                new CatalogItemSelection(null, CatalogItemSelectionType.All, true));
        }
    }
}