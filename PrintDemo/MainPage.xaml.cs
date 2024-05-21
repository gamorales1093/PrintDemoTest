
namespace PrintDemo;
using PrintDemo.Helpers;
public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{

        (sender as Button).IsEnabled = false;

        var fileName = "sample.pdf";
        var stream = await FileSystem.OpenAppPackageFileAsync(fileName);
        var helper = new PrintHelper();

#if WINDOWS
        helper.Print(stream, fileName, this.Window.Handler.PlatformView as Microsoft.UI.Xaml.Window);

#elif ANDROID
        await helper.PrintAsync(stream, fileName);

#elif __IOS__ || MACCATALYST
		helper.Print(stream, fileName);

#endif

        (sender as Button).IsEnabled = true;
    }


}


