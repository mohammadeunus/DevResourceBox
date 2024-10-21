using Microsoft.Extensions.Localization;
using Editable.Localization;
using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Editable.Web;

[Dependency(ReplaceServices = true)]
public class EditableBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<EditableResource> _localizer;

    public EditableBrandingProvider(IStringLocalizer<EditableResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
