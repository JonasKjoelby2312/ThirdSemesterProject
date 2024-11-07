using RestSharp;

namespace ThirdSemesterProject.WinForm
{
    public partial class ProductView : Form
    {
        RestClient _restClient;

        public ProductView(string baseApiUrl, Product product)
        {
            InitializeComponent();
            _restClient = new RestClient(baseApiUrl);
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
            _restClient.SaveProduct();

        }
    }
}
