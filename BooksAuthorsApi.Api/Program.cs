using BooksAuthorsApi.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<AuthorModel>();
builder.Services.AddScoped<BookService>();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});

app.Run();