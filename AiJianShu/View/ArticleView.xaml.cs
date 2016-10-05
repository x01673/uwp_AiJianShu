using AiJianShu.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AiJianShu.View
{
    public sealed partial class ArticleView : UserControl
    {
        public ArticleView()
        {
            this.InitializeComponent();
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                this.Unloaded += ArticleViewUnloaded;
                Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtonsBackPressed;
                /*
                 WindowsRuntimeMarshal.AddEventHandler<RoutedEventHandler>(new Func<RoutedEventHandler, EventRegistrationToken>(this.add_Unloaded), new Action<EventRegistrationToken>(this.remove_Unloaded), new RoutedEventHandler(this.ArticleViewUnloaded));
                WindowsRuntimeMarshal.AddEventHandler<EventHandler<BackPressedEventArgs>>(new Func<EventHandler<BackPressedEventArgs>, EventRegistrationToken>(HardwareButtons.add_BackPressed), new Action<EventRegistrationToken>(HardwareButtons.remove_BackPressed), new EventHandler<BackPressedEventArgs>(this.HardwareButtonsBackPressed));
    
                */
            }
        }

        private void ArticleViewUnloaded(object sender, RoutedEventArgs e)
        {
            Windows.Phone.UI.Input.HardwareButtons.BackPressed -= HardwareButtonsBackPressed;
        }

        private void HardwareButtonsBackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            MainViewModel.articleViewModel.BackPreView();
            e.Handled = true;
        }

        private void ArticleViewBackClick(object sender, RoutedEventArgs e)
        {
            MainViewModel.articleViewModel.BackPreView();
        }
    }
}
