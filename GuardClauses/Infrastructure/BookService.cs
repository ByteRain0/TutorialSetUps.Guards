using GuardClauses.Models;
using Microsoft.Extensions.Options;

namespace GuardClauses.BookService;

public class BookService : IBookService
{
    private readonly HttpClient _client;
    
    public BookService(IOptions<BookServiceConfig> configuration, IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient("Example");
        _client.DefaultRequestHeaders.Add("ApiKey",configuration.Value.ApiKey);
    }

    public void Add(Book book)
    {
        // code to execute the operation.
    }
}