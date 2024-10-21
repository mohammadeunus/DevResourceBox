using System.Threading.Tasks;

namespace Editable.Data;

public interface IEditableDbSchemaMigrator
{
    Task MigrateAsync();
}
