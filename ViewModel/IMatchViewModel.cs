using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Media;

namespace MVVM.ViewModel {
	public interface IMatchViewModel {
		string RecorderIDLabel { get; }
		string AllianceLabel { get; }
		string EventLabel { get; }
		string MatchNumberLabel { get; }
		string TeamNumberLabel { get; }
		string Time { get; }
		string LastEvent { get; }
		string LastEventStage { get; }
		string LastEventTime { get; }
		ImageSource TimerImageSource { get; }
		Visibility AbortButtonVisibility { get; }
		Visibility ContinueButtonVisibility { get; }

		RelayCommand AbortCommand { get; }
		RelayCommand ContinueCommand { get; }
		RelayCommand UndoCommand { get; }
		RelayCommand CrossBaselineCommand { get; }
	}
}
