
using System.Threading.Tasks;
using System.Windows;

namespace BreakingNewsWF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IWebColector _myWebCollector;
        private IWebCalCulator _myWebCalculator;

        public MainWindow()
        {
            InitializeComponent();
            _myWebCalculator = new WebCalCulator();
            _myWebCollector = new WebCollector();
        }

        private string LogicRadioButtonNews()
        {
            if (radioButtonAftonbladet.IsChecked == true)
                return "https://www.aftonbladet.se";

            if (radioButtonExpressen.IsChecked == true)
                return "https://www.expressen.se/";

            return radioButtonDN.IsChecked == true ? "https://www.dn.se/" : string.Empty;
        }

        private string LogicRadioButtonKeyWords()
        {
            if (radioButtonKorea.IsChecked == true)
                return radioButtonKorea.Content.ToString();

            if (radioButtonPolis.IsChecked == true)
                return radioButtonPolis.Content.ToString();

            return RadioButtonEkonomi.IsChecked == true ? RadioButtonEkonomi.Content.ToString() : string.Empty;
        }

        private async void GetStats()
        {
            var LogicRadioButtonKeyWord = LogicRadioButtonKeyWords();
            var LogicRadioButtonnews = LogicRadioButtonNews();
            try
            {
                textBoxCount.Text = "Loading...";
                await Task.Delay(1000);
                await Task.Run(() => _myWebCollector.GetHtmlFromUrl(LogicRadioButtonnews));
            }
            finally
            {
                textBoxCount.Text = _myWebCalculator.CalculateNumberOfHits(_myWebCollector, LogicRadioButtonKeyWord.ToLower()).ToString();
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            GetStats();
        }
    }
}
