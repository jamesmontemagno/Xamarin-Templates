using Xamarin.Forms;

namespace BlankAppTemplateXaml
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        int count = 0;
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            count++;
            ButtonClick.Text = $"You clicked {count} times";

            if (count == 10)
            {
                await Navigation.PushAsync(new DetailsPage());
                count = 0;
                ButtonClick.Text = "Click Me";
            }
        }
    }
}
