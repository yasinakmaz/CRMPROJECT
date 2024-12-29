using Microsoft.Maui.ApplicationModel.Communication;

namespace CRM.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        GrdRegister.IsEnabled = false;
        GrdRegister.IsVisible = false;
    }
    private async void LoginCommand()
	{
        if (string.IsNullOrWhiteSpace(TxtEmail.Text) || string.IsNullOrWhiteSpace(TxtPassword.Text))
        {
            await DisplayAlert("Sistem", "Lütfen gerekli alanlarý doldurunuz!", "Tamam");
            return;
        }
        try
        {
            FirebaseAuth auth = new FirebaseAuth();
            var response = await auth.PushLogin(TxtEmail.Text, TxtPassword.Text);
            if (!string.IsNullOrWhiteSpace(response) && response.StartsWith("Baþarýlý"))
            {
                await Shell.Current.GoToAsync($"{nameof(MenuPage)}");
            }
            else
            {
                await DisplayAlert("Sistem", response ?? "Bilinmeyen bir hata oluþtu.", "Tamam");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Hata", $"Bir hata oluþtu: {ex.Message}", "Tamam");
        }
	}

    private void BtnLogin_Clicked(object sender, EventArgs e)
    {
        LoginCommand();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (GrdRegister.IsVisible == false)
        {
            GrdGirisYap.IsEnabled = false;
            GrdGirisYap.IsVisible = false;
            GrdRegister.IsVisible = true;
            GrdRegister.IsEnabled = true;
        }
        else 
        {
            GrdGirisYap.IsEnabled = true;
            GrdGirisYap.IsVisible = true;
            GrdRegister.IsVisible = false;
            GrdRegister.IsEnabled = false;
        }
    }

    private async void RegisterCommand()
    {
        if (string.IsNullOrWhiteSpace(TxtDisplayName.Text) || string.IsNullOrWhiteSpace(TxtRegEmail.Text) || string.IsNullOrWhiteSpace(TxtRegPassword.Text))
        {
            await DisplayAlert("Sistem", "Lütfen gerekli alanlarý doldurunuz!", "Tamam");
            return;
        }
        try
        {
            FirebaseAuth auth = new FirebaseAuth();
            var response = await auth.CreateRegister(TxtDisplayName.Text, TxtRegEmail.Text, TxtRegPassword.Text);
            if (!string.IsNullOrWhiteSpace(response) && response.StartsWith("Baþarýlý"))
            {
               
            }
            else
            {
                await DisplayAlert("Sistem", response ?? "Bilinmeyen bir hata oluþtu.", "Tamam");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Hata", $"Bir hata oluþtu: {ex.Message}", "Tamam");
        }
    }

    private void BtnRegister_Clicked(object sender, EventArgs e)
    {
        RegisterCommand();
    }
}