namespace Domain.Models.Account
{
    public class AccountModel
    {

        public Guid Id { get; set; }

        public required string Username { get; set; }

        public required string Password { get; set; }

        public required bool Authorized { get; set; }

        public string? token { get; set; }

        public string? Role { get; set; }
    }
}
