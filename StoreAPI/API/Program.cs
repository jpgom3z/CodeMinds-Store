using API.Data;
using API.Services;
using API.Services.OrderService;
using API.Validators;
using API.Validators.OrderValidator;
using API.Validators.ProductValidator;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<StoreDB>();

//SERVICES
builder.Services.AddScoped<ICategoryStateService, CategoryStateService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductStateService, ProductStateService>();
builder.Services.AddScoped<IOrderService, OrderService>();

//VALIDATORS
builder.Services.AddScoped<IProductValidator, ProductValidator>();
builder.Services.AddScoped<ICategoryValidator, CategoryValidator>();
builder.Services.AddScoped<IOrderValidator, OrderValidator>();

var app = builder.Build();

app.UseCors(options => 
{
    options.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.MapControllers();
app.UseExceptionHandler("/errors/500");
app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.Run();
