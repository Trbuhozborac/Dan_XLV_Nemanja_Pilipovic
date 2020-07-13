﻿using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Models;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for UpdateProductView.xaml
    /// </summary>
    public partial class UpdateProductView : Window
    {
        public UpdateProductView()
        {
            InitializeComponent();
            this.DataContext = new UpdateProductViewModel(this);
        }

        public UpdateProductView(tblProduct product)
        {
            InitializeComponent();
            this.DataContext = new UpdateProductViewModel(this, product);
        }

        private void LetterValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z ]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
