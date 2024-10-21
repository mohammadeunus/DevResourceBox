using Editable.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Editable.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(EditableEntityFrameworkCoreModule),
    typeof(EditableApplicationContractsModule)
    )]
public class EditableDbMigratorModule : AbpModule
{
}
