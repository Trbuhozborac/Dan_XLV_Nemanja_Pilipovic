using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class UpdateProductViewModel : BaseViewModel
    {
        #region Objects

        UpdateProductView main;

        #endregion

        #region Constructors

        public UpdateProductViewModel(UpdateProductView mainOpen)
        {
            main = mainOpen;
        }

        public UpdateProductViewModel(UpdateProductView mainOpen, tblProduct product)
        {
            main = mainOpen;
            Product = product;
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

        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveProductExecute(), param => CanSaveProduct());
                }
                return save;
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
        /// Save Updated Info about Product to the Database
        /// </summary>
        private void SaveProductExecute()
        {
            try
            {
                using(WarehouseDbEntities db = new WarehouseDbEntities())
                {
                    tblProduct updatedProcut = db.tblProducts.Where(x => x.Id == Product.Id).FirstOrDefault();
                    updatedProcut.Name = Product.Name;
                    updatedProcut.Code = Product.Code;
                    updatedProcut.Quantity = Product.Quantity;
                    updatedProcut.Price = Product.Price;
                    updatedProcut.Stored = Product.Stored;
                    db.SaveChanges();
                }
                MessageBox.Show("Product Updated Successfully!");
                Log();
                main.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());                
            }
        }

        /// <summary>
        /// Checks if all fields are populated so Product can be Saved
        /// </summary>
        /// <returns></returns>
        private bool CanSaveProduct()
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
        /// Check if Current Window can be Closed
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
                    File.AppendAllText(_location, $"\n[{DateTime.Now.ToLongDateString()}] [{DateTime.Now.ToShortTimeString()}] Product Updated.");
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
