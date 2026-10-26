using System.ComponentModel.DataAnnotations;

public sealed record RegisterDTOs
{
    [Required]
    public required string DisplayName { get; init; }
    [Required]
    [EmailAddress]
    public required string Email { get; init; }
    [Required]
    public required string password { get; init; }
}

