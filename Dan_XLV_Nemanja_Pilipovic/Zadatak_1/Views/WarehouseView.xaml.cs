using System.Windows;
using Zadatak_1.ViewModels;

namespace Zadatak_1.Views
{
    /// <summary>
    /// Interaction logic for WarehouseView.xaml
    /// </summary>
    public partial class WarehouseView : Window
    {
        public WarehouseView()
        {
            InitializeComponent();
            this.DataContext = new WarehouseViewModel(this);
        }
    }
}
