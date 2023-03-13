using Microsoft.AspNetCore.Identity;

namespace TraversalCoreProject.Models
{
    public class CustomIdentityValidator : IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Parola minimum {length} karakter olmalıdır."
            };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = $"Parola en az bir büyük harf (A-Z) içermelidir."
            };
        }
        public override IdentityError PasswordRequiresLower() 
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = $"Parola en az bir küçük harf (a-z) içermelidir."
            };
        }
        public override IdentityError PasswordRequiresDigit()      
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresDigit",
                Description = $"Parola en az bir sayı (0-9) içermelidir."
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = $"Parola en az bir alfanümerik olmayan karakter içermelidir."
            };
        }
    }
}
