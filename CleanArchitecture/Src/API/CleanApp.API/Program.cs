var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithFiltersExt().AddSwaggerGenExt().AddExceptionHandlerExt().AddCachingExt().AddProblemDetails();

builder.Services.AddRepositories(builder.Configuration).AddServices();

var app = builder.Build();

app.UseConfigurePipelineExt();

app.MapControllers();

app.Run();
