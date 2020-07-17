using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DellyShopApp.Views.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage 
	{
		public RegisterPage ()
		{
		   

            InitializeComponent ();
		  
		}
	    protected override async void OnAppearing()
	    {
	        base.OnAppearing();
	     
        }
        private async void RegisteruButtonClick(object sender, EventArgs e)
	    {
	      await  Navigation.PushAsync(new HomeTabbedPage());
	    }

        private void BackButton(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
    
}
