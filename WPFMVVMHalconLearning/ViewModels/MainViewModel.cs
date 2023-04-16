using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HalconDotNet;
using WPFMVVMHalconLearning.Models;

namespace WPFMVVMHalconLearning.ViewModels
{
	public partial class MainViewModel : ObservableObject
	{
        public HImage image { get; set; }
		public HRegion region { get; set; }
        public MainViewModel()
        {
			image = new HImage(@"..\..\..\Images\chipTest.tif");
			PrinterChipAnalysis = new PrinterChipAnalysisModel(image);
		}

		[ObservableProperty]
		[NotifyCanExecuteChangedFor(nameof(ShowRegionCommand))]
		private PrinterChipAnalysisModel _PrinterChipAnalysis;

		[ObservableProperty]
		[NotifyCanExecuteChangedFor(nameof(ShowImageCommand))]
		private HImage _DisplayImage;

		[ObservableProperty]
		[NotifyCanExecuteChangedFor(nameof(ShowRegionCommand))]
		private HRegion _DisplayRegion;

		[RelayCommand]
		public void ShowImage()
		{
			DisplayImage = image;
		}

		[RelayCommand]
		public void ShowRegion()
		{			
			DisplayRegion = PrinterChipAnalysis.ChipRegionProcedure();			
		}
	}
}