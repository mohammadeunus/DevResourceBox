using Xunit;

namespace Editable.EntityFrameworkCore;

[CollectionDefinition(EditableTestConsts.CollectionDefinitionName)]
public class EditableEntityFrameworkCoreCollection : ICollectionFixture<EditableEntityFrameworkCoreFixture>
{

}
