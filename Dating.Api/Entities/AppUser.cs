namespace Dating.Api.Entities
{
    public sealed class AppUser
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();
        public required string DisplayName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
    }
}