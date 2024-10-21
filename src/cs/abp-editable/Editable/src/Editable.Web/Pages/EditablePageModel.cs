using Editable.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Editable.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class EditablePageModel : AbpPageModel
{
    protected EditablePageModel()
    {
        LocalizationResourceType = typeof(EditableResource);
    }
}
