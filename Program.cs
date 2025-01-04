using FrontEleccM.FrontServices;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace FrontEleccM
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

			builder.Services.AddScoped<MunicipiService>();
			builder.Services.AddScoped<PartitService>();
			builder.Services.AddScoped<TaulaService>();
			builder.Services.AddScoped<CandidatService>();
			builder.Services.AddScoped<StateService>();
            builder.Services.AddSingleton<AuthStateService>();


            builder.Services.AddScoped<AuthMessageHandler>();

            builder.Services.AddHttpClient("ApiClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7014/");
            }).AddHttpMessageHandler<AuthMessageHandler>();

            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddScoped<RoleService>();




            // Cargar configuración del appsettings.json en wwwroot
            var apiBaseUrl = builder.Configuration.GetValue<string>("ApiBaseUrl");
            // Configurar HttpClient para la URL base de la API
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });
            builder.Services.AddSingleton<SignalRService>();
            await builder.Build().RunAsync();
        }
    }
}
