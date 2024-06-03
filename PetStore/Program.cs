using Microsoft.EntityFrameworkCore;
using PetStore.Interfaces;
using PetStore.Resolver;
using PetStore.Services;
using PetStore.Storage;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<WarehouseIntegrationDataResolver>();
builder.Services.AddScoped<SpecieIntegrationDataResolver>();
builder.Services.AddScoped<AnimalIntegrationDataResolver>();
builder.Services.AddScoped<IWarehouseService,WarehouseService>();
builder.Services.AddScoped<IAnimalsService, AnimalsService>();

builder.Services.AddHttpClient<AnimalsService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5149/species");
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PetStoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "PetStore", Version = "v1" });
});


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Moja aplikacja MVC v1");
    c.RoutePrefix = string.Empty;
});


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
