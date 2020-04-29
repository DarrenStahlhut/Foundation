using EPiServer.Commerce.Storage;
using Foundation.Commerce.Extensions;

namespace Foundation.Infrastructure
{
    public static class ExtendedPropertiesExtensions
    {
        public static decimal GetManualDiscount(this IExtendedProperties container)
        {
            return container.GetDecimal("ManualDiscountValue");
        }

        public static void SetManualDiscount(this IExtendedProperties container, decimal value)
        {
            container.Properties["ManualDiscountValue"] = value;
        }

        public static string GetManualDiscountCode(this IExtendedProperties container)
        {
            return container.Properties["ManualDiscountCode"]?.ToString();
        }

        public static void SetManualDiscountCode(this IExtendedProperties container, string value)
        {
            container.Properties["ManualDiscountCode"] = value;
        }
    }
}