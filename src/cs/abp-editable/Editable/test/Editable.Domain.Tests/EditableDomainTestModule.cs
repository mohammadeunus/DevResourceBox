using Volo.Abp.Modularity;

namespace Editable;

[DependsOn(
    typeof(EditableDomainModule),
    typeof(EditableTestBaseModule)
)]
public class EditableDomainTestModule : AbpModule
{

}
