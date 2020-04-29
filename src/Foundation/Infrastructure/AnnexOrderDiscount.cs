using EPiServer.Commerce.Marketing;
using EPiServer.DataAnnotations;

namespace Foundation.Infrastructure
{
    [ContentType(DisplayName = "Annex reward discount",
        Description = "A discount used for Annex loyalty rewards",
        GUID = "79CD9742-C4B0-46FD-9F94-14B3BDDA23E5")]
    public class AnnexOrderDiscount : OrderPromotion
    {
    }
}