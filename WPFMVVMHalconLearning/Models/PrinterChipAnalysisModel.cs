using CommunityToolkit.Mvvm.ComponentModel;
using HalconDotNet;
using System;
using System.IO;


namespace WPFMVVMHalconLearning.Models
{
	public partial class PrinterChipAnalysisModel : ObservableObject
	{
        public HImage Image { get; set; }

		[ObservableProperty]
		private HRegion _ChipRegion;

		[ObservableProperty]
		private int _MinGrayValue = 255;

        public PrinterChipAnalysisModel(HImage image)
        {
            Image = image;
        }

        public HRegion ChipRegionProcedure()
		{
			string procedurePath = @"..\..\..\HalconProcedures";
			//MinGrayValue = minGrayValue;
			HDevEngine Engine = new HDevEngine();
			Engine.SetProcedurePath(Path.GetFullPath(procedurePath));
			HDevProcedure procedure = new HDevProcedure("get_printer_chip_regions");
			HDevProcedureCall ProcedureCall = new HDevProcedureCall(procedure);
			ProcedureCall.SetInputIconicParamObject("Image", Image);
			ProcedureCall.SetInputCtrlParamTuple("MinGray", (HTuple)MinGrayValue);
			ProcedureCall.Execute();
			HRegion ChipRegion = ProcedureCall.GetOutputIconicParamRegion("ConnectedRegions");
			Engine.Dispose();

			return ChipRegion;
		}
	}
}
