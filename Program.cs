using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Romain;
using Romain.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IRomainConverterService, RomainConverterService>();

await builder.Build().RunAsync();
