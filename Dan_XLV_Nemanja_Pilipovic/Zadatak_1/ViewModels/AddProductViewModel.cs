using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class AddProductViewModel : BaseViewModel
    {
        #region Objects

        AddProductView main;

        #endregion

        #region Constructors

        public AddProductViewModel(AddProductView mainOpen)
        {
            main = mainOpen;
            Product = new tblProduct();
        }

        #endregion

        #region Properties

        private tblProduct product;

        public tblProduct Product
        {
            get { return product; }
            set
            {
                product = value;
                OnPropertyChanged("Product");
            }
        }


        #endregion

        #region Commands

        private ICommand addP;
        public ICommand AddP
        {
            get
            {
                if (addP == null)
                {
                    addP = new RelayCommand(param => AddProduct(), param => CanAddProduct());
                }
                return addP;
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

        /// <summary>
        /// Adds Products to the Database
        /// </summary>
        private void AddProduct()
        {
            Product.Stored = false;
            try
            {
                using (WarehouseDbEntities db = new WarehouseDbEntities())
                {
                    db.tblProducts.Add(Product);
                    db.SaveChanges();
                }
                MessageBox.Show("Product Added Successfully!");
                Log();
                main.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Checks if all fields are populate so User can exucute Saving the Product
        /// </summary>
        /// <returns></returns>
        private bool CanAddProduct()
        {
            if (string.IsNullOrEmpty(Product.Name) || string.IsNullOrEmpty(Product.Code.ToString()) ||
                string.IsNullOrEmpty(Product.Quantity.ToString()) || string.IsNullOrEmpty(Product.Price.ToString())
                ||
                string.IsNullOrWhiteSpace(Product.Name) || string.IsNullOrWhiteSpace(Product.Code.ToString()) ||
                string.IsNullOrWhiteSpace(Product.Quantity.ToString()) || string.IsNullOrWhiteSpace(Product.Price.ToString()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Close the Current Window
        /// </summary>
        private void CloseExecute()
        {
            main.Close();
        }

        /// <summary>
        /// Checks if Main Window can be closed
        /// </summary>
        /// <returns></returns>
        private bool CanCloseExecute()
        {
            return true;
        }

        #endregion

        #region Locations

        private readonly string _location = @"~\..\..\..\Logs.txt";

        #endregion

        #region Delegates and Events

        public delegate void Notification();

        public event Notification OnNotification;

        public void Log()
        {
            OnNotification += () =>
            {
                if (File.Exists(_location))
                {
                    File.AppendAllText(_location, $"\n[{DateTime.Now.ToLongDateString()}] [{DateTime.Now.ToShortTimeString()}] Product Added to the Database.");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Could not find the file...");
                }
            };
            OnNotification.Invoke();

        }
        
        #endregion
    }
}
