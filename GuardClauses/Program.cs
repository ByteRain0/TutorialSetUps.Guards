using GuardClauses.BookService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IBookService, BookService>();
builder.Services.Configure<BookServiceConfig>(builder.Configuration.GetSection(nameof(BookServiceConfig)));

builder.Services.AddHttpClient("Example", client =>
{
    client.BaseAddress = new Uri("www.example.com");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
