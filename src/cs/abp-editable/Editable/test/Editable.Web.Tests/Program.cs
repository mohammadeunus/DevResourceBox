using Microsoft.AspNetCore.Builder;
using Editable;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<EditableWebTestModule>();

public partial class Program
{
}
