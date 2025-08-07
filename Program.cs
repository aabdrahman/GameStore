using GameStore.UI.Client;
using GameStore.UI.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); //Allows for interactivity and then added to pipeline in the maprazorcomponent call

builder.Services.AddHttpClient<GamesClient>(opts =>
{
    opts.BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseUri")!);
});

builder.Services.AddHttpClient<GenresClient>(opts =>
{
    opts.BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseUri")!);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(); //Allows for interactivity

app.Run();
