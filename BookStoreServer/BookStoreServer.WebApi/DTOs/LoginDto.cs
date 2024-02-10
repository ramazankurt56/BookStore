public sealed record LoginDto(
    string Email,
    string Password,
    bool RememberMe = false);