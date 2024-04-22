using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SviatoslavSkobalskyi.Meninx.DevTestTask.API.ViewModels;
using SviatoslavSkobalskyi.Meninx.DevTestTask.Application.DTO;
using SviatoslavSkobalskyi.Meninx.DevTestTask.Application.Services;
using SviatoslavSkobalskyi.Meninx.DevTestTask.Core.Repositories;
using SviatoslavSkobalskyi.Meninx.DevTestTask.Persistance;
using SviatoslavSkobalskyi.Meninx.DevTestTask.Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString"),
        b => b.MigrationsAssembly("SviatoslavSkobalskyi.Meninx.DevTestTask.Persistance"));
});

builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IBooksService, BooksService>();
builder.Services.AddAutoMapper(typeof(ApiProfile));
builder.Services.AddAutoMapper(typeof(ApplicationProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/books", async ([FromBody] SearchBooksRequest request, [FromServices] IBooksService booksService, [FromServices] IMapper mapper) =>
{
    return await booksService.GetBooksAsync(request.FreeSearchCriteria, mapper.Map<SortingDTO>(request.Sorting)).ConfigureAwait(false);
})
.WithName("getFiltered")
.WithOpenApi();

app.MapPost("/booksPaged", async ([FromBody] SearchBooksPagedRequest request, [FromServices] IBooksService booksService, [FromServices] IMapper mapper) =>
{
    return await booksService.GetBooksPagedAsync(request.FreeSearchCriteria, mapper.Map<SortingDTO>(request.Sorting), mapper.Map<PaginationDTO>(request.Pagination)).ConfigureAwait(false);
})
.WithName("getPaged")
.WithOpenApi();

app.MapGet("/book/{id}", async (int id, [FromServices] IBooksService booksService, [FromServices] IMapper mapper) =>
{
    return await booksService.GetBookAsync(id).ConfigureAwait(false);
})
.WithName("getById")
.WithOpenApi();

app.MapPost("/book", async ([FromBody] BookViewModel book, [FromServices] IBooksService booksService, [FromServices] IMapper mapper) =>
{
    await booksService.CreateBookAsync(mapper.Map<BookDTO>(book)).ConfigureAwait(false);
})
.WithName("create")
.WithOpenApi();

app.MapPut("/book", async ([FromBody] BookViewModel book, [FromServices] IBooksService booksService, [FromServices] IMapper mapper) =>
{
    await booksService.UpdateBookAsync(mapper.Map<BookDTO>(book)).ConfigureAwait(false);
})
.WithName("update")
.WithOpenApi();

app.MapDelete("/book", async ([FromBody] BookViewModel book, [FromServices] IBooksService booksService) =>
{
    await booksService.DeleteBookAsync(book.Id).ConfigureAwait(false);
})
.WithName("delete")
.WithOpenApi();

app.Run();