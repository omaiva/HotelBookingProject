using Microsoft.AspNetCore.Identity;
using System.Globalization;
using System.Resources;

namespace HotelBookingProject.WebUI
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        private readonly ResourceManager _resourceManager;

        public CustomIdentityErrorDescriber()
        {
            _resourceManager = new ResourceManager("HotelBookingProject.WebUI.Resources.IdentityMessages",
            typeof(CustomIdentityErrorDescriber).Assembly);
        }

        public override IdentityError DuplicateEmail(string email)
        {
            string message = _resourceManager.GetString("DuplicateEmail", CultureInfo.CurrentCulture) ?? base.DuplicateEmail(email).Description;

            return new IdentityError
            {
                Code = nameof(DuplicateEmail),
                Description = string.Format(message, email)
            };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            string message = _resourceManager.GetString("DuplicateUserName", CultureInfo.CurrentCulture) ?? base.DuplicateUserName(userName).Description;

            return new IdentityError
            {
                Code = nameof(DuplicateUserName),
                Description = string.Format(message, userName)
            };
        }

        public override IdentityError InvalidEmail(string? email)
        {
            string message = _resourceManager.GetString("InvalidEmail", CultureInfo.CurrentCulture) ?? base.InvalidEmail(email).Description;

            return new IdentityError
            {
                Code = nameof(InvalidEmail),
                Description = string.Format(message, email)
            };
        }

        public override IdentityError DuplicateRoleName(string role)
        {
            string message = _resourceManager.GetString("DuplicateRoleName", CultureInfo.CurrentCulture) ?? base.DuplicateRoleName(role).Description;

            return new IdentityError
            {
                Code = nameof(DuplicateRoleName),
                Description = string.Format(message, role)
            };
        }

        public override IdentityError InvalidRoleName(string? role)
        {
            string message = _resourceManager.GetString("InvalidRoleName", CultureInfo.CurrentCulture) ?? base.InvalidRoleName(role).Description;

            return new IdentityError
            {
                Code = nameof(InvalidRoleName),
                Description = string.Format(message, role)
            };
        }

        public override IdentityError InvalidToken()
        {
            string message = _resourceManager.GetString("InvalidToken", CultureInfo.CurrentCulture) ?? base.InvalidToken().Description;

            return new IdentityError
            {
                Code = nameof(InvalidToken),
                Description = message
            };
        }

        public override IdentityError InvalidUserName(string? userName)
        {
            string message = _resourceManager.GetString("InvalidUserName", CultureInfo.CurrentCulture) ?? base.InvalidUserName(userName).Description;

            return new IdentityError
            {
                Code = nameof(InvalidUserName),
                Description = string.Format(message, userName)
            };
        }

        public override IdentityError LoginAlreadyAssociated()
        {
            string message = _resourceManager.GetString("LoginAlreadyAssociated", CultureInfo.CurrentCulture) ?? base.LoginAlreadyAssociated().Description;

            return new IdentityError
            {
                Code = nameof(LoginAlreadyAssociated),
                Description = message
            };
        }

        public override IdentityError PasswordMismatch()
        {
            string message = _resourceManager.GetString("PasswordMismatch", CultureInfo.CurrentCulture) ?? base.PasswordMismatch().Description;

            return new IdentityError
            {
                Code = nameof(PasswordMismatch),
                Description = message
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            string message = _resourceManager.GetString("PasswordRequiresDigit", CultureInfo.CurrentCulture) ?? base.PasswordRequiresDigit().Description;

            return new IdentityError
            {
                Code = nameof(PasswordRequiresDigit),
                Description = message
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            string message = _resourceManager.GetString("PasswordRequiresLower", CultureInfo.CurrentCulture) ?? base.PasswordRequiresLower().Description;

            return new IdentityError
            {
                Code = nameof(PasswordRequiresLower),
                Description = message
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            string message = _resourceManager.GetString("PasswordRequiresNonAlphanumeric", CultureInfo.CurrentCulture) ?? base.PasswordRequiresNonAlphanumeric().Description;

            return new IdentityError
            {
                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = message
            };
        }

        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
        {
            string message = _resourceManager.GetString("PasswordRequiresUniqueChars", CultureInfo.CurrentCulture) ?? base.PasswordRequiresUniqueChars(uniqueChars).Description;

            return new IdentityError
            {
                Code = nameof(PasswordRequiresUniqueChars),
                Description = string.Format(message, uniqueChars)
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            string message = _resourceManager.GetString("PasswordRequiresUpper", CultureInfo.CurrentCulture) ?? base.PasswordRequiresUpper().Description;

            return new IdentityError
            {
                Code = nameof(PasswordRequiresUpper),
                Description = message
            };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            string message = _resourceManager.GetString("PasswordTooShort", CultureInfo.CurrentCulture) ?? base.PasswordTooShort(length).Description;

            return new IdentityError
            {
                Code = nameof(PasswordTooShort),
                Description = string.Format(message, length)
            };
        }

        public override IdentityError UserAlreadyHasPassword()
        {
            string message = _resourceManager.GetString("UserAlreadyHasPassword", CultureInfo.CurrentCulture) ?? base.UserAlreadyHasPassword().Description;

            return new IdentityError
            {
                Code = nameof(UserAlreadyHasPassword),
                Description = message
            };
        }

        public override IdentityError UserAlreadyInRole(string role)
        {
            string message = _resourceManager.GetString("UserAlreadyInRole", CultureInfo.CurrentCulture) ?? base.UserAlreadyInRole(role).Description;

            return new IdentityError
            {
                Code = nameof(UserAlreadyInRole),
                Description = string.Format(message, role)
            };
        }

        public override IdentityError UserNotInRole(string role)
        {
            string message = _resourceManager.GetString("UserNotInRole", CultureInfo.CurrentCulture) ?? base.UserNotInRole(role).Description;

            return new IdentityError
            {
                Code = nameof(UserNotInRole),
                Description = string.Format(message, role)
            };
        }

        public override IdentityError UserLockoutNotEnabled()
        {
            string message = _resourceManager.GetString("UserLockoutNotEnabled", CultureInfo.CurrentCulture) ?? base.UserLockoutNotEnabled().Description;

            return new IdentityError
            {
                Code = nameof(UserLockoutNotEnabled),
                Description = message
            };
        }

        public override IdentityError RecoveryCodeRedemptionFailed()
        {
            string message = _resourceManager.GetString("RecoveryCodeRedemptionFailed", CultureInfo.CurrentCulture) ?? base.RecoveryCodeRedemptionFailed().Description;

            return new IdentityError
            {
                Code = nameof(RecoveryCodeRedemptionFailed),
                Description = message
            };
        }

        public override IdentityError ConcurrencyFailure()
        {
            string message = _resourceManager.GetString("ConcurrencyFailure", CultureInfo.CurrentCulture) ?? base.ConcurrencyFailure().Description;

            return new IdentityError
            {
                Code = nameof(ConcurrencyFailure),
                Description = message
            };
        }

        public override IdentityError DefaultError()
        {
            string message = _resourceManager.GetString("DefaultError", CultureInfo.CurrentCulture) ?? base.DefaultError().Description;

            return new IdentityError
            {
                Code = nameof(DefaultError),
                Description = message
            };
        }
    }
}
