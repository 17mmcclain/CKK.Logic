using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CKK.Logic.Interfaces;
using CKK.Logic.Models;

namespace InventoryManagementForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStore _Store;
        Store tp = (Store)Application.Current.FindResource("globStore");
        public ObservableCollection<StoreItem> _Items { get; private set; }
        public MainWindow()
        {
            _Store = new Store();
            InitializeComponent();
            _Items = new ObservableCollection<StoreItem>();
            _1bInventoryList.ItemsSource = _Items;
            RefreshList();
        }

        private void RefreshList()
        {
            _Items.Clear();
            foreach (StoreItem si in new ObservableCollection<StoreItem>(_Store.GetStoreItems()))
                _Items.Add(si);
        }

      
       

        private void AddNewInventoryItem_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.Name = NameDescriptionTextBox.Text;
            product.Price = int.Parse(PriceTextBox.Text);
            product.Id = int.Parse(InventoryIDTextBox.Text);
            int temp = int.Parse(QuantityTextBox.Text);
            _Store.AddStoreItem(product, temp);
            RefreshList();
            NameDescriptionTextBox.Text = null;
            PriceTextBox.Text = null;
            InventoryIDTextBox.Text = null;
            QuantityTextBox.Text = null;
        }

        private void SearchInventoryTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void _1bInventoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RemoveInventoryItemButton_Click(object sender, RoutedEventArgs e)
        {
            StoreItem item = (StoreItem)_1bInventoryList.SelectedItem;
            _Store.DeleteStoreItem(item.Product.Id);

            RefreshList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {

        }


        private void InventoryIDTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            InventoryIDTextBox.Text = "";
        }

        private void NameDescriptionTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            NameDescriptionTextBox.Text = "";
        }

        private void QuantityTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            QuantityTextBox.Text = "";
        }

        private void PriceTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PriceTextBox.Text = "";
        }
    }
}
