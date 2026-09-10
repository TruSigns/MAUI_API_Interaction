namespace MauiPageNavigation
{
    public partial class MessagePage : ContentPage
    {
        public MessagePage(string message)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(message))
            {
                lblMessage.Text = message;
            }
            else
            {
                lblMessage.Text = "No message received.";
            }
        }

        private void OnGoBackClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}