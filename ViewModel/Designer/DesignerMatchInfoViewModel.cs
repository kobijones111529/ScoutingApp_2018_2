using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;

namespace MVVM.ViewModel {
	public class DesignerMatchInfoViewModel : ViewModelBase, IMatchInfoViewModel {
		private ObservableCollection<string> _RecorderIDSource;
		public ObservableCollection<string> RecorderIDSource {
			get {
				return _RecorderIDSource;
			}
			set {
				_RecorderIDSource = value;
				RaisePropertyChanged("RecorderIDSource");
			}
		}

		private ObservableCollection<string> _AllianceSource;
		public ObservableCollection<string> AllianceSource {
			get {
				return _AllianceSource;
			}
			set {
				_AllianceSource = value;
				RaisePropertyChanged("AllianceSource");
			}
		}

		private ObservableCollection<string> _EventSource;
		public ObservableCollection<string> EventSource {
			get {
				return _EventSource;
			}
			set {
				_EventSource = value;
				RaisePropertyChanged("EventSource");
			}
		}

		private string _SelectedRecorderID;
		public string SelectedRecorderID {
			get {
				return _SelectedRecorderID;
			}
			set {
				_SelectedRecorderID = value;
				RaisePropertyChanged("SelectedRecorderID");
			}
		}

		private string _SelectedAlliance;
		public string SelectedAlliance {
			get {
				return _SelectedAlliance;
			}
			set {
				_SelectedAlliance = value;
				RaisePropertyChanged("SelectedAlliance");
			}
		}

		private string _SelectedEvent;
		public string SelectedEvent {
			get {
				return _SelectedEvent;
			}
			set {
				_SelectedEvent = value;
				RaisePropertyChanged("SelectedEvent");
			}
		}

		private string _MatchNumber;
		public string MatchNumber {
			get {
				return _MatchNumber;
			}
			set {
				_MatchNumber = value;
				RaisePropertyChanged("MatchNumber");
			}
		}

		private string _TeamNumber;
		public string TeamNumber {
			get {
				return _TeamNumber;
			}
			set {
				_TeamNumber = value;
				RaisePropertyChanged("TeamNumber");
			}
		}

		public RelayCommand NavigateHomeCommand { get; private set; }
		public RelayCommand SubmitCommand { get; private set; }

		public DesignerMatchInfoViewModel() {
			RecorderIDSource = new ObservableCollection<string>() {
				"Person 1"
			};
			AllianceSource = new ObservableCollection<string>() {
				"Blue 1"
			};
			EventSource = new ObservableCollection<string>() {
				"Practice"
			};

			SelectedRecorderID = RecorderIDSource[0];
			SelectedAlliance = AllianceSource[0];
			SelectedEvent = EventSource[0];
			MatchNumber = Convert.ToString(1);
			TeamNumber = Convert.ToString(2512);

			NavigateHomeCommand = new RelayCommand(() => { }, () => {
				return false;
			});
			SubmitCommand = new RelayCommand(() => { }, () => {
				return false;
			});
		}
	}
}