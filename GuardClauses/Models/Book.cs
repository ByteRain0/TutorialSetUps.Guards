using Ardalis.GuardClauses;

namespace GuardClauses.Models;

public class Book
{
    public string Author { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    

    public Book(string author, string name, int price)
    {
        // Refactor this
        if (string.IsNullOrWhiteSpace(author))
        {
            throw new ArgumentException("Author must no be null or whitespace");
        }
        
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name must not be null or whitespace");
        }

        if (price <= 0)
        {
            throw new ArgumentException("Price must not be negative or zero");
        }
        
        // Into this
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
        Author = Guard.Against.NullOrWhiteSpace(author, nameof(author));
        Price = Guard.Against.NegativeOrZero(price, nameof(price));
    }
}