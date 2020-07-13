using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;

namespace Zadatak_1.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        #region Objects

        MainWindow main;

        #endregion

        #region Constructors

        public MainWindowViewModel(MainWindow mainOpen)
        {
            main = mainOpen;
        }

        #endregion

        #region Properties

        private string username;

        public string Username
        {
            get { return username; }
            set 
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set 
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }


        #endregion

        #region Commands

        private ICommand logIn;
        public ICommand LogIn
        {
            get
            {
                if (logIn == null)
                {
                    logIn = new RelayCommand(param => LogInExecute(), param => CanLogInExecute());
                }
                return logIn;
            }
        }

        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }

        #endregion

        #region Functions

        private void LogInExecute()
        {
            if (Username == "Mag2019" && Password == "Mag2019")
            {

            }
            else if(Username == "Man2019" && Password == "Man2019")
            {

            }
            else
            {
                MessageBox.Show("Incorrect Username or Password");
            }
        }

        private bool CanLogInExecute()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) ||
                string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Close the Main window
        /// </summary>
        private void CloseExecute()
        {
            main.Close();
        }

        /// <summary>
        /// Checks if Main window can be closed
        /// </summary>
        /// <returns></returns>
        private bool CanCloseExecute()
        {
            return true;
        }

        #endregion
    }
}
