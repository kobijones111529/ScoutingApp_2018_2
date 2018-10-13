using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace MVVM.ViewModel {
	public interface IMatchInfoViewModel {
		ObservableCollection<string> RecorderIDSource { get; }
		ObservableCollection<string> AllianceSource { get; }
		ObservableCollection<string> EventSource { get; }

		string SelectedRecorderID { get; }
		string SelectedAlliance { get; }
		string SelectedEvent { get; }
		string MatchNumber { get; }
		string TeamNumber { get; }

		RelayCommand NavigateHomeCommand { get; }
		RelayCommand SubmitCommand { get; }
	}
}