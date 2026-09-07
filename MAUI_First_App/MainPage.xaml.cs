namespace MAUI_First_App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnDisplayClicked(object sender, EventArgs e)
        {
            lblOutput.Text = txtInput.Text;
        }

        private void OnResetClicked(object sender, EventArgs e)
        {
            txtInput.Text = string.Empty;
            lblOutput.Text = string.Empty;
        }
    }
}