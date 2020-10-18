using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using RatScanner.ViewModel;

namespace RatScanner.View
{
	/// <summary>
	/// Interaction logic for MainMenuControl.xaml
	/// </summary>
	internal partial class MainMenu : UserControl, ISwitchable
	{
		internal MainMenu()
		{
			InitializeComponent();
			DataContext = new MainWindowVM(RatScannerMain.Instance);
		}

		private void HyperlinkRequestNavigate(object sender, RequestNavigateEventArgs e)
		{
			Process.Start("explorer.exe", e.Uri.ToString());
			e.Handled = true;
		}

		private void OpenSettingsWindow(object sender, RoutedEventArgs e)
		{
			PageSwitcher.Instance.Navigate(new Settings());
		}

		private void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			PageSwitcher.Instance.CollapseTitleBar();
			PageSwitcher.Instance.SizeToContent = SizeToContent.WidthAndHeight;
			PageSwitcher.Instance.SetBackgroundOpacity(RatConfig.MinimalUi.Opacity / 100f);
			PageSwitcher.Instance.Navigate(new MinimalMenu());
		}

		public void UtilizeState(object state)
		{
			throw new System.NotImplementedException();
		}

		public void OnClose() { }
	}
}
