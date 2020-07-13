using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Zadatak_1.Commands;
using Zadatak_1.Models;
using Zadatak_1.Views;

namespace Zadatak_1.ViewModels
{
    class WarehouseViewModel : BaseViewModel
    {
        #region Objects

        WarehouseView main;

        #endregion

        #region Constructors

        public WarehouseViewModel(WarehouseView mainOpen)
        {
            main = mainOpen;
            Products = GetAllProducts();
            ProductCounter = GetNumberOfProcuts();
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

        private List<tblProduct> products;

        public List<tblProduct> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged("Products");
            }
        }

        public int ProductCounter { get; set; }


        #endregion

        #region Commands

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

        private ICommand putOnStorage;
        public ICommand PutOnStorage
        {
            get
            {
                if (putOnStorage == null)
                {
                    putOnStorage = new RelayCommand(param => PutOnStorageExecute(), param => CanPutOnStorage());
                }
                return putOnStorage;
            }
        }

        #endregion

        #region Functions

        private List<tblProduct> GetAllProducts()
        {
            try
            {
                using (WarehouseDbEntities db = new WarehouseDbEntities())
                {
                    List<tblProduct> products = new List<tblProduct>();
                    products = db.tblProducts.Where(x => x.Id > 0).ToList();
                    return products;
                }                               
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        private void CloseExecute()
        {
            main.Close();
        }

        private bool CanCloseExecute()
        {
            return true;
        }

        private void PutOnStorageExecute()
        {
            if(Product.Stored == false)
            {
                if(Product.Quantity + ProductCounter <= 100)
                {
                    try
                    {
                        using(WarehouseDbEntities db = new WarehouseDbEntities())
                        {
                            tblProduct product = db.tblProducts.Where(x => x.Id == Product.Id).FirstOrDefault();
                            product.Stored = true;
                            db.SaveChanges();
                        }
                        PutedOnStorage();
                        main.Close();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message.ToString());                       
                    }                    
                }
                else
                {
                    CantPutOnStorage();
                }
            }
            else
            {
                MessageBox.Show("Cant Store Product thats already Stored.");
            }
        }

        private bool CanPutOnStorage()
        {
            return true;
        }


        private int GetNumberOfProcuts()
        {
            try
            {
                int counter = 0;
                using(WarehouseDbEntities db = new WarehouseDbEntities())
                {
                    foreach (tblProduct product in db.tblProducts)
                    {
                        counter += Convert.ToInt32(product.Quantity);
                    }
                }
                return counter;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
                return 0;
            }
        }

        #endregion

        #region Delegates and Events

        public delegate void Notification();

        public event Notification OnNotification;

        public void CantPutOnStorage()
        {
            OnNotification += () =>
            {
                MessageBox.Show("There is no enoguh place for Product Quantity. <Max 100 Products>");
            };
            OnNotification.Invoke();
        }

        public void PutedOnStorage()
        {
            OnNotification += () =>
            {
                MessageBox.Show("Product Stored Successfully!");
            };
            OnNotification.Invoke();
        }


        #endregion
    }
}
