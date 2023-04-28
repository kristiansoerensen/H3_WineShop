using BlazorWebassembly;
using BlazorWebassembly.Repository;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7043/api/") });
builder.Services.AddScoped<IProductHttpRepository, ProductHttpRepository>();
builder.Services.AddScoped<ICategoryHttpRepository, CategoryHttpRepository>();
builder.Services.AddScoped<IBasketHttpRepository, BasketHttpRepository>();
builder.Services.AddScoped<IBasketItemHttpRepository, BasketItemHttpRepository>();
builder.Services.AddScoped<IImageHttpRepository, ImageHttpRepository>();
builder.Services.AddBlazoredLocalStorageAsSingleton();

await builder.Build().RunAsync();
