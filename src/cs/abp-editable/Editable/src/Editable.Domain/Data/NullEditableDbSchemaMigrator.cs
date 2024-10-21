using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Editable.Data;

/* This is used if database provider does't define
 * IEditableDbSchemaMigrator implementation.
 */
public class NullEditableDbSchemaMigrator : IEditableDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
