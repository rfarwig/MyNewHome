using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

namespace MyNewHome
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            SignInCommand = new Command(async () => await SignIn());
            NotNowCommand = new Command(App.GoToMainPage);
        }

        string _message = string.Empty;
        public string Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged(); }
        }

        public ICommand NotNowCommand { get; }
        public ICommand SignInCommand { get; }

        async Task SignIn()
        {
            try
            {
                IsBusy = true;
                Message = "Signing In...";

                // Log the user in
                await TryLoginAsync();
            }
            finally
            {
                Message = string.Empty;
                IsBusy = false;

                if (Settings.IsLoggedIn)
                    App.GoToMainPage();
            }
        }

        public static async Task<bool> TryLoginAsync()
        {
            return true;
        }
    }
}
