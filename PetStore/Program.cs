using Microsoft.EntityFrameworkCore;
using PetStore.Interfaces;
using PetStore.Resolver;
using PetStore.Services;
using PetStore.Storage;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<WarehouseIntegrationDataResolver>();
builder.Services.AddScoped<IWarehouseService,WarehouseService>();
builder.Services.AddScoped<IAnimalsService, AnimalsService>();

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
