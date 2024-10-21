using Volo.Abp.Modularity;

namespace Editable;

[DependsOn(
    typeof(EditableApplicationModule),
    typeof(EditableDomainTestModule)
)]
public class EditableApplicationTestModule : AbpModule
{

}
