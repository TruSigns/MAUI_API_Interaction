namespace MAUI_Add_Subtract
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnAdditionClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstValue.Text) ||
                string.IsNullOrWhiteSpace(txtSecondValue.Text))
            {
                lblMessage.Text = "Please enter values for both fields to get the sum";
                return;
            }

            if (double.TryParse(txtFirstValue.Text, out double firstValue) &&
                double.TryParse(txtSecondValue.Text, out double secondValue))
            {
                lblMessage.Text = string.Empty;

                await Navigation.PushAsync(
                    new ResultPage(firstValue, secondValue, "Addition"));
            }
            else
            {
                lblMessage.Text = "Please enter valid numbers";
            }
        }

        private async void OnSubtractionClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstValue.Text) ||
                string.IsNullOrWhiteSpace(txtSecondValue.Text))
            {
                lblMessage.Text = "Please enter values for both fields to get the difference";
                return;
            }

            if (double.TryParse(txtFirstValue.Text, out double firstValue) &&
                double.TryParse(txtSecondValue.Text, out double secondValue))
            {
                lblMessage.Text = string.Empty;

                await Navigation.PushAsync(
                    new ResultPage(firstValue, secondValue, "Subtraction"));
            }
            else
            {
                lblMessage.Text = "Please enter valid numbers";
            }
        }
    }
}