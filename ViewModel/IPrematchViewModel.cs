using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace MVVM.ViewModel {
	public interface IPrematchViewModel {
		string RecorderIDLabel { get; }
		string AllianceLabel { get; }
		string EventLabel { get; }
		string MatchNumberLabel { get; }
		string TeamNumberLabel { get; }
		string PrematchNotes { get; }
		string IsThisLoss { get; }
		double LossFontSize { get; }

		RelayCommand NavigateHomeCommand { get; }
		RelayCommand NavigateBackCommand { get; }
		RelayCommand StartMatchCommand { get; }
	}
}
