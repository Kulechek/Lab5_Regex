using System.Text.RegularExpressions;
using ReactiveUI;

namespace Lab5_Regex.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string reg = "";
        string input = "";
        string output = "";
        public string Regex
        {
            get => reg;
            set
            {
                if (value != null)
                {
                    reg = value;
                }
            }
        }

        public string Output
        {
            get => output;
            set
            {
                if (Regex != "")
                {
                    this.RaiseAndSetIfChanged(ref output, value);
                }
                else
                {
                    this.RaiseAndSetIfChanged(ref output, "");
                }
            }
        }

        public string Input
        {
            get => input;
            set
            {
                Output = "";
                if (Regex != "")
                {
                    Regex reg = new Regex(Regex);
                    foreach (Match match in reg.Matches(value))
                    {
                        Output += match.Value + "\n";
                    }
                    if (Output == "")
                    {
                        Output = "";
                    }
                }
                this.RaiseAndSetIfChanged(ref input, value);
            }
        }
    }
}
