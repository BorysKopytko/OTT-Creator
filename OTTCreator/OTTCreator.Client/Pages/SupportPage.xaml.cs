using OTTCreator.Client.Services;

namespace OTTCreator.Client.Pages;

public partial class SupportPage : ContentPage
{
    ContentService contentService;
	public SupportPage()
	{
		InitializeComponent(); 
        contentService = new ContentService();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        CodeLabel.Text = await SecureStorage.Default.GetAsync("Code");
    }

    private async void DeactivateButton_Clicked(object sender, EventArgs e)
    {
        var apikey = await SecureStorage.Default.GetAsync("APIKey");
        var result = await contentService.ActivateAsync(false, apikey, CodeLabel.Text);
        if (result)
        {
            SecureStorage.Default.Remove("Code");

            Application.Current.Quit();
        }
    }
}
