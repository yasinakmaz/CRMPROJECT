namespace CRM.Data.Auth
{
    public class FirebaseAuth
    {
        private static FirebaseAuthConfig _config = new FirebaseAuthConfig()
        {
            ApiKey = "AIzaSyBdYlnCJVLf1XQdOigsruJAL9wJC6j2kgg",
            AuthDomain = "crmproject-76239.firebaseapp.com",
            Providers = new FirebaseAuthProvider[]
            {
            new EmailProvider()
            }
        };

        FirebaseAuthClient client = new FirebaseAuthClient(_config);

        public async Task<string?>? CreateRegister(string tag, string email, string password)
        {
            var response = await client.CreateUserWithEmailAndPasswordAsync(email, password, tag);
            try
            {
                if (response == null)
                {
                    return $"Başarılı : {response?.User?.Uid?.ToString()}";
                }

                return "Kayıt Başarısız.";
            }
            catch (FirebaseAuthException ex)
            {
                return ex.Reason.GetStatusMessage();
            }
        }
        public async Task<string?> PushLogin(string email, string password)
        {
            try
            {
                var response = await client.SignInWithEmailAndPasswordAsync(email, password);

                if (response?.User != null)
                {
                    var userInfo = response.User.Info;
                    return $"Başarılı: {userInfo?.Uid} - {userInfo?.DisplayName} - {userInfo?.Email}";
                }

                return "Giriş Başarısız. Kullanıcı Bilgileri Alınamadı.";
            }
            catch (FirebaseAuthException authEx)
            {
                return authEx.Reason.GetStatusMessage();
            }
        }

        public async Task<string?>? ChangePassword(string email, string password, string newpassword)
        {
            try
            {
                var response = await client.SignInWithEmailAndPasswordAsync(email, password);
                response?.User?.ChangePasswordAsync(newpassword);

                return "Başarılı";
            }
            catch (FirebaseAuthException ex)
            {
                return ex.Reason.GetStatusMessage();
            }
        }

        public async Task<string?>? ChangeDisplayName(string email, string password, string newDisplayName)
        {
            try
            {
                var response = await client.SignInWithEmailAndPasswordAsync(email, password);
                response?.User?.ChangeDisplayNameAsync(newDisplayName);

                return "Başarılı";
            }
            catch (FirebaseAuthException ex)
            {
                return ex.Reason.GetStatusMessage();
            }
        }
    }
}
