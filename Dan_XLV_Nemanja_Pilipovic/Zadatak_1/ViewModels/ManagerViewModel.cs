﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Xaml.Schema;
using Zadatak_1.Commands;
using Zadatak_1.Models;
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
            AllProducts = GetAllProducts();
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

        private List<tblProduct> allProducts;

        public List<tblProduct> AllProducts
        {
            get { return allProducts; }
            set 
            {
                allProducts = value;
                OnPropertyChanged("AllProducts");
            }
        }

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

        private ICommand deleteProduct;
        public ICommand DeleteProduct
        {
            get
            {
                if (deleteProduct == null)
                {
                    deleteProduct = new RelayCommand(param => DeleteProductExecute(), param => CanDeleteProduct());
                }
                return deleteProduct;
            }
        }

        private ICommand updateProduct;
        public ICommand UpdateProduct
        {
            get
            {
                if (updateProduct == null)
                {
                    updateProduct = new RelayCommand(param => UpdateProductExecute(), param => CanUpdateProduct());
                }
                return updateProduct;
            }
        }

        #endregion

        #region Functions

        /// <summary>
        /// Open Window for adding the Product
        /// </summary>
        private void AddProduct()
        {
            AddProductView view = new AddProductView();
            view.ShowDialog();
            AllProducts = GetAllProducts();
            main.Close();
        }

        /// <summary>
        /// Checks if Product can be Added
        /// </summary>
        /// <returns></returns>
        private bool CanAddProduct()
        {
            return true;
        }

        /// <summary>
        /// Close the Current Window
        /// </summary>
        private void CloseExecute()
        {
            main.Close();
        }

        /// <summary>
        /// Checks if Current Window can be closed
        /// </summary>
        /// <returns></returns>
        private bool CanCloseExecute()
        {
            return true;
        }

        /// <summary>
        /// Gets all Products from the Database
        /// </summary>
        /// <returns>All Products from Database</returns>
        private List<tblProduct> GetAllProducts()
        {
            List<tblProduct> products = new List<tblProduct>();
            try
            {
                using(WarehouseDbEntities db = new WarehouseDbEntities())
                {
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

       /// <summary>
       /// Deletes Product that is not stored
       /// </summary>
        private void DeleteProductExecute()
        {
            if (Product.Stored == true)
            {
                MessageBox.Show("Cant Delete Stored Products.");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Are you sure?", "Delete Poduct", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        try
                        {
                            using (WarehouseDbEntities db = new WarehouseDbEntities())
                            {
                                tblProduct product = db.tblProducts.Where(x => x.Id == Product.Id).FirstOrDefault();
                                if (product != null)
                                {
                                    db.tblProducts.Remove(product);
                                    db.SaveChanges();
                                    MessageBox.Show("Product Deleted Successfully!");
                                    Log();
                                    AllProducts = GetAllProducts();
                                }
                                main.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.Message.ToString());

                        }
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }           
        }

        /// <summary>
        /// Checks if Product can be Deleted
        /// </summary>
        /// <returns></returns>
        private bool CanDeleteProduct()
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
                    File.AppendAllText(_location, $"\n[{DateTime.Now.ToLongDateString()}] [{DateTime.Now.ToShortTimeString()}] Product Deleted from the Database.");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Could not find the file...");
                }
            };
            OnNotification.Invoke();
        }

        private void UpdateProductExecute()
        {
            UpdateProductView view = new UpdateProductView(Product);
            view.ShowDialog();
            AllProducts = GetAllProducts();
        }

        private bool CanUpdateProduct()
        {
            return true;
        }

        #endregion
    }
}
