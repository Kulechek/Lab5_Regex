using Avalonia.Controls;
using Lab5_Regex.ViewModels;
using System.IO;

namespace Lab5_Regex.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.FindControl<Button>("openFileButton").Click += async delegate
            {
                    var taskPath = new OpenFileDialog()
                    {
                        Title = "Open File",
                        Filters = null
                    }.ShowAsync((Window)this.VisualRoot);

                    string[]? path = await taskPath;

                    if (path != null)
                    {
                        var context = this.DataContext as MainWindowViewModel;
                        var pathStr = string.Join(@"\", path);
                        context.Input = "";

                        using (StreamReader sr = File.OpenText(pathStr))
                        {
                            string s;
                            while ((s = sr.ReadLine()) != null)
                            {
                                context.Input += s;
                            }
                        }
                    }
            };

            this.FindControl<Button>("saveFileButton").Click += async delegate
            {
                var taskPath = new SaveFileDialog()
                {
                    Title = "Save File",
                    Filters = null
                }.ShowAsync((Window)this.VisualRoot);

                string? path = await taskPath;

                if (path != null)
                {
                    var context = this.DataContext as MainWindowViewModel;

                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(context.Output);
                    }
                }
            };

            this.FindControl<Button>("openRegexButton").Click += async delegate
            {
                var context = this.DataContext as MainWindowViewModel;
                string? regex = await new RegularSubWindow(context.Regex).ShowDialog<string>((Window)this.VisualRoot);
                context.Regex = regex;
                context.Input = context.Input;
            };
        }
    }
}
