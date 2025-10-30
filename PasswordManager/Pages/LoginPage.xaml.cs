using PasswordManager.Pages.AuthMethods;

namespace PasswordManager.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        LoginForm.Content = new LoginByMasterPassword();
    }

    private void PinCodeMethodClicked(object sender, EventArgs e)
    {
        LoginForm.Content = new LoginByPinCode();
    }

    private void MasterPasswordMethodClicked(object sender, EventArgs e)
    {
        LoginForm.Content = new LoginByMasterPassword();
    }

    private void BiometricMethodClicked(object sender, EventArgs e)
    {
        LoginForm.Content = new LoginByBiometric();
    }
}