using Volo.Abp.Modularity;

namespace Editable;

/* Inherit from this class for your domain layer tests. */
public abstract class EditableDomainTestBase<TStartupModule> : EditableTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
