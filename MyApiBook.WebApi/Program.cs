using MyApiBook.BusinessLayer.Abstract;
using MyApiBook.BusinessLayer.Concrete;
using MyApiBook.DataAccessLayer.Abstract;
using MyApiBook.DataAccessLayer.Context;
using MyApiBook.DataAccessLayer.EntityFramework;
using MyApiBook.EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();

builder.Services.AddScoped<IBookService, BookManager>();
builder.Services.AddScoped<IBookDal, EfBookDal>();

builder.Services.AddScoped<ISocialMediaService,SocialMediaManager>();
builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();

builder.Services.AddScoped<IQuotationService, QuotationManager>();
builder.Services.AddScoped<IQuotationDal, EfQuotationDal>();

builder.Services.AddScoped<IArticleService, ArticleManager>();
builder.Services.AddScoped<IArticleDal, EfArticleDal>();

builder.Services.AddScoped<IAuthorService, AuthorManager>();
builder.Services.AddScoped<IAuthorDal, EfAuthorDal>();

builder.Services.AddDbContext<ApiContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
