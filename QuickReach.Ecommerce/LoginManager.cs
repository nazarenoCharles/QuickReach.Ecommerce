using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace QuickReach.Ecommerce

{
    public class LoginManager : ILoginManager
    {
        public bool ValidatePassword(string password)
        {
            var hasUpperChar = password.ToCharArray().Any((c) => char.IsUpper(c));
            var symbolandpunc = password.ToCharArray().Any((c) => char.IsSymbol(c) || char.IsPunctuation(c));
            var hasNumber = password.ToCharArray().Any((c) => char.IsNumber(c));
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }
            if (password.Length < 8)
            {
                return false;
            }
            if (!symbolandpunc)
            {
                return false;
            }
            if (!hasUpperChar)
            {
                return false;
            }
            if (!hasNumber)
            {
                return false;
            }
            return true;
        }
        public bool ValidateUsername(string username)
        {
            var input = username;
            if (string.IsNullOrEmpty(username))
            {
                return false;
            }
            Regex emailvalidation = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!emailvalidation.IsMatch(input))
            {
                return false;
            }

            return true;
        }
        public bool Validate(string username, string password)
        {
            var input = username;
            Regex emailvalidation = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            var hasUpperChar = password.ToCharArray().Any((c) => char.IsUpper(c));
            var symbolandpunc = password.ToCharArray().Any((c) => char.IsSymbol(c) || char.IsPunctuation(c));
            var hasNumber = password.ToCharArray().Any((c) => char.IsNumber(c));
            
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }
            if (password.Length < 8)
            {
                return false;
            }
            if (!symbolandpunc)
            {
                return false;
            }
            if (!hasUpperChar)
            {
                return false;
            }
            if (!hasNumber)
            {
                return false;
            }
            if (string.IsNullOrEmpty(username))
            {
                return false;
            }
            
            if (!emailvalidation.IsMatch(input))
            {
                return false;
            }

            return true;
        }
    }
}
