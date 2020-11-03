using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace NewsPaper.GatewayClientApi.Configure
{
    public class ConfigureEndpoints
    {
        public static void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger UI GatewayClientApi");
                options.DocumentTitle = "Title";
                options.RoutePrefix = "docs";
                options.DocExpansion(DocExpansion.List);

            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
