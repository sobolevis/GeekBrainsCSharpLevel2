using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;

namespace TestWebAPIClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static HttpClient client = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://localhost:50920/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async void allproductButton_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<Product> products = await GetProductsAsync(client.BaseAddress + "api/Products");
            productDataGrid.ItemsSource = products;
        }

        private async void idproductButton_Click(object sender, RoutedEventArgs e)
        {
            List<Product> products = new List<Product>();
            if (idproductTextBox.Text != string.Empty)
            {
                Product product = await GetProductAsync(client.BaseAddress + "api/Products/" + idproductTextBox.Text);
                if (product != null)
                    products.Add(product);
            }
            else
            {
                products = (List<Product>)await GetProductsAsync(client.BaseAddress + "api/Products");
            }
            productDataGrid.ItemsSource = products;
        }

        static async Task<IEnumerable<Product>> GetProductsAsync(string path)
        {
            IEnumerable<Product> products = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    products = await response.Content.ReadAsAsync<IEnumerable<Product>>();
                }
            }
            catch (Exception)
            {
            }
            return products;
        }

        static async Task<Product> GetProductAsync(string path)
        {
            Product product = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    product = await response.Content.ReadAsAsync<Product>();
                }
            }
            catch (Exception)
            {
            }
            return product;
        }
    }
}
