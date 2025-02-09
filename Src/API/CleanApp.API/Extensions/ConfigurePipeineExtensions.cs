namespace CleanApp.API.Extensions;

public static class ConfigurePipeineExtensions
{
    public static IApplicationBuilder UseConfigurePipelineExt(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerExt();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        return app;
    }
}
