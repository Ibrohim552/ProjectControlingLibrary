namespace Library;

public class SqlCommands
{
    public const string connectionstring = "Server=localhost;Port=5432;Database=Library_db;User Id=postgres;Password=12345;";

    public const string insertBook = @"insert into book(Id, Title, Description,
                                   ISBN,PublishedDate,AuthorId,CategoryId,CreatedAt) 
                                     values(@Id, @Title, @Description, 
                                    @ISBN, @PublishedDate, @AuthorId, @CategoryId,@CreatedAt)";

    public const string InsertAuthor = "INSERT INTO Authors (Id, FirstName, LastName, DateOfBirth, Biography, CreatedAt) VALUES (@Id, @FirstName, @LastName, @DateOfBirth, @Biography, @CreatedAt)";

    public const string InsertBookRental = "INSERT INTO BookRentals (Id, BookId, UserId, RentalDate, ReturnDate, CreatedAt) VALUES (@Id, @BookId, @UserId, @RentalDate, @ReturnDate, @CreatedAt)";

    public const string InsertCategory = "INSERT INTO Categories (Id, Name, CreatedAt) VALUES (@Id, @Name, @CreatedAt)";

    public const string InsertUser = "INSERT INTO Users (Id, Username, Email, PasswordHash, CreatedAt) VALUES (@Id, @Username, @Email, @PasswordHash, @CreatedAt)";

    public const string GetBookById = "SELECT * FROM Books WHERE Id = @Id";
    public const string GetAuthorById = "SELECT * FROM Authors WHERE Id = @Id";
    public const string GetBookRentalById = "SELECT * FROM BookRentals WHERE Id = @Id";
    public const string GetCategoryById = "SELECT * FROM Categories WHERE Id = @Id";
    public const string GetUserById = "SELECT * FROM Users WHERE Id = @Id";
    
    public const string DeleteBookById = "DELETE FROM Books WHERE Id = @Id";
    public const string DeleteAuthorById = "DELETE FROM Authors WHERE Id = @Id";
    public const string DeleteBookRentalById = "DELETE FROM BookRentals WHERE Id = @Id";
    public const string DeleteCategoryById = "DELETE FROM Categories WHERE Id = @Id";
    public const string DeleteUserById = "DELETE FROM Users WHERE Id = @Id";
    public const string UpdateBook = "UPDATE Books SET Title = @Title, Description = @Description, ISBN = @ISBN, PublishedDate = @PublishedDate, AuthorId = @AuthorId, CategoryId = @CategoryId WHERE Id = @Id";
    public const string UpdateAuthor = "UPDATE Authors SET FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, Biography = @Biography WHERE Id = @Id";
    public const string UpdateBookRental = "UPDATE BookRentals SET BookId = @BookId, UserId = @UserId, RentalDate = @RentalDate, ReturnDate = @ReturnDate WHERE Id = @Id";
    public const string UpdateCategory = "UPDATE Categories SET Name = @Name WHERE Id = @Id";
    public const string UpdateUser = "UPDATE Users SET Username = @Username, Email = @Email, PasswordHash = @PasswordHash WHERE Id = @Id";
    public const string GetAllBooks = "SELECT * FROM Books";
    public const string GetAllAuthors = "SELECT * FROM Authors";
    public const string GetAllBookRentals = "SELECT * FROM BookRentals";
    public const string GetAllCategories = "SELECT * FROM Categories";
    public const string GetAllUsers = "SELECT * FROM Users";



    public const string GetBookByFiltrDate = @"select * from books 
                              where Extract(Year from publisheddate) >= Extract(Year from current_date) - 5;";
    
    public const string GetBookAutohorAndCategory = @"select b.id, b.title, a.firstName || ' ' || a.lastName as authorName,a.dateOfBirth as authorDateOfBirth,a.biography as authorBiography, c.name as authorName from books b 
                                join authors a on a.id = b.authorId
                                join categories c on c.id = b.categoryId
                               ";
    
    public const string GetBookByAuthor = @"select * from books b 
                                join authors a on a.id = b.authorId
                                where a.id = @authorId;";
    
    public const string GetBookRentalsByUserId = @"select br.id as rentalId, b.id as bookId, b.title, br.RentalDate, br.ReturnDate, br.CreatedAt from bookrentals br
                               join books b on b.id = br.bookId
                               where br.userid = @userId";
    

}