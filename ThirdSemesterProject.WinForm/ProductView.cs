using RestSharp;
using ThirdSemesterProject.APIClient;
using ThirdSemesterProject.APIClient.DTOs;

namespace ThirdSemesterProject.WinForm
{
    public partial class ProductView : Form
    {
        IAPIClient _apiClient;
        Product CurrProduct;

        public ProductView(string baseApiUrl, Product product)
        {
            InitializeComponent();
            _apiClient = new APIClient.APIClient(baseApiUrl);
            CurrProduct = product;
            Init();
        }

        private void Init()
        {
            if (CurrProduct != null)
            {
                txtName.Text = CurrProduct.Name;
                txtDescription.Text = CurrProduct.Description;
                txtSize.Text = CurrProduct.Size;
                txtPrice.Text = CurrProduct.SalesPrice.ToString();
                txtWeight.Text = CurrProduct.Weight.ToString();
                txtProductType.Text = CurrProduct.ProductType;
                txtCurrStock.Text = CurrProduct.CurrentStock.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelClicked();
        }

        private void CancelClicked()
        {
            Dispose();
            Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ConfirmClickedAsync();
        }

        private async void ConfirmClickedAsync()
        {
            if (CurrProduct != null)
            {
                EditProduct();
            }
            else
            {
                NewProduct();
            }
            int givenId = await _apiClient.CreateProductAsync(CurrProduct);
            CurrProduct.ProductId = givenId;
            CancelClicked();
        }

        private void NewProduct()
        {
            Product res = new Product()
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                Size = txtSize.Text,
                Weight = Convert.ToDouble(txtWeight.Text),
                SalesPrice = Convert.ToDecimal(txtPrice.Text),
                ProductType = txtProductType.Text,
                CurrentStock = Convert.ToInt32(txtCurrStock.Text)
            };
            CurrProduct = res;
        }

        private void EditProduct()
        {
            CurrProduct.Name = txtName.Text;
            CurrProduct.Description = txtDescription.Text;
            CurrProduct.Size = txtSize.Text;
            CurrProduct.Weight = Convert.ToDouble(txtWeight.Text);
            CurrProduct.SalesPrice = Convert.ToDecimal(txtPrice.Text);
            CurrProduct.ProductType = txtProductType.Text;
            CurrProduct.CurrentStock = Convert.ToInt32(txtCurrStock.Text);
        }
    }
}
