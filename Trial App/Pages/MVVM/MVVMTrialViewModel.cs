using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Trial_App.Pages.MVVM
{
    class MVVMTrialViewModel : INotifyPropertyChanged
    {
        private string username, password;
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand login { get; set; }

        //All commands must be initialized beforehand
        public MVVMTrialViewModel()
        {
            login = new Command(LoginSuccessful);
            username = "Sample";
        }

        private void LoginSuccessful(object obj)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                App.Current.MainPage.DisplayAlert("", "Please enter values", "Ok");
            }
            else
            {
                App.Current.MainPage.DisplayAlert("", "Login Succssful", "Ok");
            }
        }


        //Editable properties can be called in runtime
        public string UserName
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                //if anything changes in property UserName this will trigger
                //PropertyChanged(this, new PropertyChangedEventArgs("UserName"));
                OnPropertyChange("UserName");
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                //if anything changes in property Password this will trigger
                //PropertyChanged(this, new PropertyChangedEventArgs("Password"));
                OnPropertyChange("Password");
            }
        }

        //if anything changes in the property this event is fired
        protected void OnPropertyChange(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
