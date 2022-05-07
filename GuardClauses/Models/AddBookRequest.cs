using System.ComponentModel.DataAnnotations;

namespace GuardClauses.Models;

public class AddBookRequest
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Author { get; set; }
    
    [Range(0,int.MaxValue)]
    public int Price { get; set; }
}