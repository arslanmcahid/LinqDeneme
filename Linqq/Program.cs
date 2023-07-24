using Core.Models;
using Core.Repositories;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository;
using Service.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<BookReaderService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<IRepository<Book>, EfRepository<Book>>();
builder.Services.AddScoped<IRepository<BookReader>, EfRepository<BookReader>>();
builder.Services.AddScoped<IRepository<Category>, EfRepository<Category>>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
//builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<IProductService, ProductService>();                Bu sildiklerimizi RepoServiceModule ile olustrduk
//                                                                              kod karmasasindan kurtulduk
//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//builder.Services.AddScoped<ICategoryService, CategoryService>();