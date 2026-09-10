namespace MAUI_Add_Subtract
{
    public partial class ResultPage : ContentPage
    {
        public ResultPage(double firstValue, double secondValue, string operation)
        {
            InitializeComponent();

            lblNumbers.Text =
                $"The numbers entered are {firstValue} and {secondValue}.";

            if (operation == "Addition")
            {
                double sum = firstValue + secondValue;
                lblResult.Text = $"The sum of the numbers is {sum}";
            }
            else
            {
                double difference = firstValue - secondValue;
                lblResult.Text = $"The difference of the numbers is {difference}";
            }
        }

        private async void OnGoBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}