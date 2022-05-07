using GuardClauses.BookService;
using GuardClauses.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuardClauses.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpPost("")]
    public IActionResult AddBook(string author, string name, int price)
    {
        var book = new Book(author, name, price);
        _bookService.Add(book);
        return Ok();
    }
}