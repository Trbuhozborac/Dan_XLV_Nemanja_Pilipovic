using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class ManagerViewModel : BaseViewModel
    {
        #region Objects

        ManagerView main;

        #endregion

        #region Constructors

        public ManagerViewModel(ManagerView mainOpen)
        {
            main = mainOpen;
        }

        #endregion

        #region Properties



        #endregion

        #region Commands

        private ICommand add;
        public ICommand Add
        {
            get
            {
                if (add == null)
                {
                    add = new RelayCommand(param => AddProduct(), param => CanAddProduct());
                }
                return add;
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

        private void AddProduct()
        {
            AddProductView view = new AddProductView();
            view.ShowDialog();
        }

        private bool CanAddProduct()
        {
            return true;
        }

        private void CloseExecute()
        {
            main.Close();   
        }

        private bool CanCloseExecute()
        {
            return true;
        }

        #endregion
    }
}
