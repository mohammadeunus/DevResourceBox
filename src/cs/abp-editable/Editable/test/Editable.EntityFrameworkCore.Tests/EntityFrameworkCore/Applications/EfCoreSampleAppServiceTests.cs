using Editable.Samples;
using Xunit;

namespace Editable.EntityFrameworkCore.Applications;

[Collection(EditableTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<EditableEntityFrameworkCoreTestModule>
{

}
