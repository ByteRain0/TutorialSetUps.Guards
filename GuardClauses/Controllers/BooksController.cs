using Ardalis.GuardClauses;
using GuardClauses.Infrastructure;
using GuardClauses.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GuardClauses.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IOptions<LibraryInformation> _options;

    private readonly string _libraryAddress;
    
    public BooksController(IOptions<LibraryInformation> options)
    {
        // TODO: Refactor this to be more concise
        if (options is null)
        {
            throw new ArgumentNullException(nameof(options));
        }
        _options = options;
        
        #region Initial refactor
        
        // or the shortened version which is a bit hard for the junior developers to read when they first encounter it.
        _options = _options ?? throw new ArgumentNullException(nameof(_options));
        
        #endregion
        
        if (string.IsNullOrWhiteSpace(_options.Value.LibraryAddress))
        {
            throw new ArgumentException("Library address should not be whitespace");
        }
        _libraryAddress = _options.Value.LibraryAddress;
        
        #region Guards

        // Example if you are injecting something like a service.
        _options = Guard.Against.Null(options, nameof(options));
        
        // Example of guarding against specific string being null or whitespace.
        _libraryAddress = Guard.Against.NullOrWhiteSpace(options.Value.LibraryAddress, 
            nameof(options.Value.LibraryAddress));
        
        #endregion
        
    }

    [HttpPost("/")]
    public IActionResult AddBook(string author, string name, int price)
    {
        // This is not really an exceptional situation.
        if (price < 0)
        {
            throw new ArgumentException("Price is less that 0");
        }
        
        var book = new Book(author, name, price);
        
        return Ok();
    }

}