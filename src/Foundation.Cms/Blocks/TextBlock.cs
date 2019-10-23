using EPiServer.Core;
using EPiServer.DataAnnotations;

namespace Foundation.Cms.Blocks
{
    [ContentType(DisplayName = "Text Block",
        GUID = "32782B29-278B-410A-A402-9FF46FAF32B9",
        Description = "Simple Rich Text Block",
        GroupName = CmsGroupNames.Content)]
    [ImageUrl("~/assets/icons/cms/blocks/CMS-icon-block-03.png")]
    public class TextBlock : FoundationBlockData
    {
        [CultureSpecific]
        public virtual XhtmlString Text { get; set; }
    }
}