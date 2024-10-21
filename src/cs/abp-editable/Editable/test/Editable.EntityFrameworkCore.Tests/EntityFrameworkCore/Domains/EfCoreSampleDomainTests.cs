using Editable.Samples;
using Xunit;

namespace Editable.EntityFrameworkCore.Domains;

[Collection(EditableTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<EditableEntityFrameworkCoreTestModule>
{

}
