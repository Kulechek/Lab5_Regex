using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Lab5_Regex.Views
{
    public partial class RegularSubWindow : Window
    {
        public RegularSubWindow(string regStr) : this()
        {
            this.FindControl<TextBox>("regTextBox").Text = regStr;
        }

        public RegularSubWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            this.FindControl<Button>("okButton").Click += delegate
            {
                var regStr = this.FindControl<TextBox>("regTextBox").Text;
                if (regStr != null)
                {
                    Close(regStr);
                }
                else
                {
                    Close("");
                }
            };

            this.FindControl<Button>("cancelButton").Click += delegate
            {
                Close();
            };


        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

    }
}
