using Inventory.Data.InventoryContext;
using Inventory.Web;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
//CROS
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy",
        builder =>
        {
            // Not a permanent solution, but just trying to isolate the problem
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});
builder.Services.Resolve();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddDbContext<BRSDbContext>(options =>
options.UseLazyLoadingProxies().UseSqlite(builder.Configuration.GetConnectionString("DefaultDatabase")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Migrate latest database changes during startup
var db = builder.Services.BuildServiceProvider().GetRequiredService<BRSDbContext>();
db.Database.Migrate();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.DefaultModelsExpandDepth(-1);
});

//app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseCors("MyCorsPolicy");

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("/", context => Task.Run((() =>
        context.Response.Redirect("/swagger/index.html"))));
});

app.Run();
