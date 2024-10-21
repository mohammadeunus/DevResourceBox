using System;
using System.Collections.Generic;
using System.Text;
using Editable.Localization;
using Volo.Abp.Application.Services;

namespace Editable;

/* Inherit your application services from this class.
 */
public abstract class EditableAppService : ApplicationService
{
    protected EditableAppService()
    {
        LocalizationResource = typeof(EditableResource);
    }
}
