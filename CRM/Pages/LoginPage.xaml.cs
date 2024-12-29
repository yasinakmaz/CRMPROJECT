using Microsoft.Maui.ApplicationModel.Communication;

namespace CRM.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
    }
    private async void Login()
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
        }
        catch (Exception ex)
        {
            await DisplayAlert("Hata", $"Bir hata olu�tu: {ex.Message}", "Tamam");
        }
	}

    private void BtnLogin_Clicked(object sender, EventArgs e)
    {
        Login();
    }
}