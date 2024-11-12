using RestSharp;
using ThirdSemesterProject.APIClient;
using ThirdSemesterProject.APIClient.DTOs;

namespace ThirdSemesterProject.WinForm
{
    public partial class ProductView : Form
    {
        IAPIClient _apiClient;
        ProductDTO CurrProduct;

        public ProductView(string baseApiUrl, ProductDTO product)
        {
            InitializeComponent();
            _apiClient = new APIClient.APIClient(baseApiUrl);
            CurrProduct = product;
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
                ConfirmClicked();
            }

            private void ConfirmClicked()
            {
                if (CurrProduct != null)
                {
                    EditProduct();
                }
                else
                {
                    NewProduct();
                }
                _apiClient.CreateProductAsync(CurrProduct);
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
