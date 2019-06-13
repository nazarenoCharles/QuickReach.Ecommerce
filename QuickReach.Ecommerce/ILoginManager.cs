namespace QuickReach.Ecommerce
{
    public interface ILoginManager
    {
        bool Validate(string username, string password);
        bool ValidatePassword(string password);
        bool ValidateUsername(string username);
    }
}