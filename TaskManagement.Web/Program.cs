using MudBlazor;
using MudBlazor.Services;
using TaskManagement.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddMudServices(options =>
{
    options.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
    options.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;
    options.SnackbarConfiguration.VisibleStateDuration = 10;
});
builder.Services.AddScoped<TaskService>();

builder.Services.AddHttpClient("api", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiUrl"]);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();