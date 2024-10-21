using Volo.Abp.Modularity;

namespace Editable;

public abstract class EditableApplicationTestBase<TStartupModule> : EditableTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
