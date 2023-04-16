using System.Windows;
using WPFMVVMHalconLearning.ViewModels;

namespace WPFMVVMHalconLearning
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();			
			DataContext = new MainViewModel();
		}
	}
}
