using BetterAIS.Business.Interfaces;

namespace BetterAIS.Business.Services;

public class TokenBlacklistService : ITokenBlacklistService
{
    private readonly List<BlacklistedToken> _blacklist = new();

    public async Task BlacklistTokenAsync(string jti, DateTime expiration)
    {
        // Add the token to the blacklist
        _blacklist.Add(new BlacklistedToken { Jti = jti, ExpiresAt = expiration });
        await Task.CompletedTask;
    }

    public async Task<bool> IsTokenBlacklistedAsync(string jti)
    {
        // Check if the token is in the blacklist
        var blacklisted = _blacklist.Any(token => token.Jti == jti);
        return await Task.FromResult(blacklisted);
    }

    public async Task CleanupExpiredTokensAsync()
    {
        // Remove expired tokens from the blacklist
        _blacklist.RemoveAll(token => token.ExpiresAt <= DateTime.UtcNow);
        await Task.CompletedTask;
    }
}

public class BlacklistedToken
{
    public string Jti { get; set; }
    public DateTime ExpiresAt { get; set; }
}
