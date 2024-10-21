using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Editable.Pages;

public class Index_Tests : EditableWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
