using Volo.Abp.Settings;

namespace Editable.Settings;

public class EditableSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(EditableSettings.MySetting1));
    }
}
