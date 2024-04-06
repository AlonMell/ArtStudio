using ArtStudio.Core.Extensions;

WebApplication
    .CreateBuilder(args)
    .UseBuilderConfiguration()
    .Build()
    .UseAppConfiguration()
    .Run();