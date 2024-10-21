using Editable.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Editable.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class EditableController : AbpControllerBase
{
    protected EditableController()
    {
        LocalizationResource = typeof(EditableResource);
    }
}
