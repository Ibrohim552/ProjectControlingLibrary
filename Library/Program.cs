
using Library;
using Library.Interface;
using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUsers, UserService>();
builder.Services.AddTransient<IAuthor, AuthorServices>();
builder.Services.AddTransient<IBooks, BookServices>();
builder.Services.AddTransient<ICategory, CategoryServices>();
builder.Services.AddTransient<IBookRentals, BookRentalsServices>();


var app = builder.Build();
// app.UseMiddleware<MiddleWares>();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
#region Users

app.MapPost("api/users", async (Users user, IUsers userService, HttpContext context) =>
{
    Console.WriteLine(Results.Ok());
    return await userService.CreateUser(user);
    
});

app.MapGet("api/users", async (IUsers userService) =>
{
    return await userService.GetUsers();
});

app.MapGet("api/users/{id}", async (Guid id, IUsers userService) =>
{
    return await userService.GetUserById(id);
});

app.MapPut("api/users/{id}", async (Guid id, Users user, IUsers userService) =>
{
    return await userService.UpdateUser(user);
});

app.MapDelete("api/users/{id}", async (Guid id, IUsers userService) =>
{
    return await userService.DeleteUser(id);
});
#endregion

#region Authors

app.MapPost("api/authors", async (Authors author, IAuthor authorService) =>
{
    return await authorService.CreateAuthor(author);
});

app.MapDelete("api/authors/{id}", async (Guid id, IAuthor authorService) =>
{
    return await authorService.DeleteAuthor(id);
});

app.MapGet("api/authors", async (IAuthor authorService) =>
{
    return await authorService.GetAuthors();
});

app.MapGet("api/authors/{id}", async (Guid id, IAuthor authorService) =>
{
    return await authorService.GetAuthorById(id);
});

app.MapPut("api/authors/{id}", async (Guid id, Authors author, IAuthor authorService) =>
{
    return await authorService.UpdateAuthor(author);
});
#endregion

#region Books

app.MapPost("api/books", async (Books book, IBooks bookService) =>
{
    return await bookService.CreateBook(book);
});

app.MapDelete("api/books/{id}", async (Guid id, IBooks bookService) =>
{
    return await bookService.DeleteBook(id);
});

app.MapGet("api/books", async (IBooks bookService) =>
{
    return await bookService.GetBooks();
});

app.MapGet("api/books/{id}", async (Guid id, IBooks bookService) =>
{
    return await bookService.GetBookById(id);
});

app.MapPut("api/books/{id}", async (Guid id, Books book, IBooks bookService) =>
{
    return await bookService.UpdateBook(book);
});
#endregion

#region Category

app.MapPost("api/categories", async (ICategory categoryService) =>
{
    return await categoryService.CreateCategory(new Categories());
});

app.MapDelete("api/categories/{id}", async (Guid id, ICategory categoryService) =>
{
    return await categoryService.DeleteCategory(id);
});

app.MapGet("api/categories", async (ICategory categoryService) =>
{
    return await categoryService.GetAllCategories();
});

app.MapGet("api/categories/{id}", async (Guid id, ICategory categoryService) =>
{
    return await categoryService.GetCategoryById(id);
});

app.MapPut("api/categories/{id}", async (Guid id, Categories category, ICategory categoryService) =>
{
    return await categoryService.UpdateCategory(category);
});
#endregion

#region Bookrentals

app.MapPost("api/bookrentals", async (BookRentals bookRental, IBookRentals bookRentalService) =>
{
    return await bookRentalService.CreateBookRentals(bookRental);
});

app.MapDelete("api/bookrentals/{id}", async (Guid id, IBookRentals bookRentalService) =>
{
    return await bookRentalService.DeleteBookRentals(id);
});

app.MapGet("api/bookrentals", async (IBookRentals bookRentalService) =>
{
    return await bookRentalService.GetBookRentals();
});

app.MapGet("api/bookrentals/{id}", async (Guid id, IBookRentals bookRentalService) =>
{
    return await bookRentalService.GetBookRentalsById(id);
});

app.MapPut("api/bookrentals/{id}", async (Guid id, BookRentals bookRental, IBookRentals bookRentalService) =>
{
    return await bookRentalService.UpdateBookRentals(bookRental);
    
});
#endregion

app.Run();
