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
            await DisplayAlert("Sistem", "L�tfen gerekli alanlar� doldurunuz!", "Tamam");
            return;
        }
        try
        {
            FirebaseAuth auth = new FirebaseAuth();
            var response = await auth.PushLogin(TxtEmail.Text, TxtPassword.Text);
            if (!string.IsNullOrWhiteSpace(response) && response.StartsWith("Ba�ar�l�"))
            {
                await Shell.Current.GoToAsync($"{nameof(MenuPage)}");
            }
            else
            {
                await DisplayAlert("Sistem", response ?? "Bilinmeyen bir hata olu�tu.", "Tamam");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Hata", $"Bir hata olu�tu: {ex.Message}", "Tamam");
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
            await DisplayAlert("Sistem", "L�tfen gerekli alanlar� doldurunuz!", "Tamam");
            return;
        }
        try
        {
            FirebaseAuth auth = new FirebaseAuth();
            var response = await auth.CreateRegister(TxtDisplayName.Text, TxtRegEmail.Text, TxtRegPassword.Text);
            if (!string.IsNullOrWhiteSpace(response) && response.StartsWith("Ba�ar�l�"))
            {
               
            }
            else
            {
                await DisplayAlert("Sistem", response ?? "Bilinmeyen bir hata olu�tu.", "Tamam");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Hata", $"Bir hata olu�tu: {ex.Message}", "Tamam");
        }
    }

    private void BtnRegister_Clicked(object sender, EventArgs e)
    {
        RegisterCommand();
    }
}