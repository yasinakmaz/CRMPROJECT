using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Helper
{
    public static class FirebaseExceptionHelper
    {
        public static string GetStatusMessage(this AuthErrorReason reason)
        {
            return reason switch
            {
                AuthErrorReason.EmailExists => "Bu Mail Adresi Zaten Kayıtlı",
                AuthErrorReason.InvalidEmailAddress => "'@' İçeren Geçerli Bir Mail Adresi Girin",
                AuthErrorReason.WeakPassword => "Şifre Uzunluğu 6 Haneden Uzun Olmalıdır",
                AuthErrorReason.WrongPassword => "Hatalı Şifre",
                AuthErrorReason.UserNotFound => "Kullanıcı Bulunamadı Lütfen Kayıt Olunuz",
                AuthErrorReason.AccountExistsWithDifferentCredential => "Kullanıcı Adı Veya Şifre Hatalı",
                AuthErrorReason.Undefined => "Kullanıcı Bulunamadı",
                AuthErrorReason.Unknown => "Kullanıcı Adı Veya Şifre Hatalı",
                AuthErrorReason.UnknownEmailAddress => "Email Adresi Bulunamadı",
                AuthErrorReason.MissingEmail => "",
                AuthErrorReason.AlreadyLinked => "",
                AuthErrorReason.MissingRequestURI => "",
                AuthErrorReason.MissingRequestType => "",
                AuthErrorReason.InvalidAccessToken => "a",
                AuthErrorReason.InvalidApiKey => "",
                AuthErrorReason.InvalidIdentifier => "",
                AuthErrorReason.InvalidIDToken => "",
                AuthErrorReason.InvalidProviderID => "",
                AuthErrorReason.LoginCredentialsTooOld => "",
                AuthErrorReason.MissingIdentifier => "",
                AuthErrorReason.MissingPassword => "",
                AuthErrorReason.OperationNotAllowed => "",
                AuthErrorReason.ResetPasswordExceedLimit => "",
                AuthErrorReason.SystemError => "",
                AuthErrorReason.TooManyAttemptsTryLater => "",
                AuthErrorReason.UserDisabled => "",

            };
        }
    }
}
