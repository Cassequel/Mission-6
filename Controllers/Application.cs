// Models/Application.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Application
{
    [Key]
    [Column("MovieId")]
    public int MovieId { get; set; }

    [Required]
    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    [Range(1888, int.MaxValue, ErrorMessage = "Please enter a year starting from 1888.")]
    public int Year { get; set; }

    public string? Director { get; set; }

    public string? Rating { get; set; }
    public bool Edited { get; set; }

    public string? LentTo { get; set; }

    public bool CopiedToPlex { get; set; }

    [MaxLength(25)]
    public string? Notes { get; set; }
}
