using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MVVM.ViewModel {
	public class DesignerMatchViewModel : ViewModelBase, IMatchViewModel {
		private string _RecorderIDLabel;
		public string RecorderIDLabel {
			get {
				return _RecorderIDLabel;
			}
			set {
				_RecorderIDLabel = value;
				RaisePropertyChanged("RecorderIDLabel");
			}
		}
		private string _AllianceLabel;
		public string AllianceLabel {
			get {
				return _AllianceLabel;
			}
			set {
				_AllianceLabel = value;
				RaisePropertyChanged("AllianceLabel");
			}
		}
		private string _EventLabel;
		public string EventLabel {
			get {
				return _EventLabel;
			}
			set {
				_EventLabel = value;
				RaisePropertyChanged("EventLabel");
			}
		}
		private string _MatchNumberLabel;
		public string MatchNumberLabel {
			get {
				return _MatchNumberLabel;
			}
			set {
				_MatchNumberLabel = value;
				RaisePropertyChanged("MatchNumberLabel");
			}
		}
		private string _TeamNumberLabel;
		public string TeamNumberLabel {
			get {
				return _TeamNumberLabel;
			}
			set {
				_TeamNumberLabel = value;
				RaisePropertyChanged("TeamNumberLabel");
			}
		}
		private string _Time;
		public string Time {
			get {
				return _Time;
			}
			set {
				_Time = value;
				RaisePropertyChanged("Time");
			}
		}
		private string _LastEvent;
		public string LastEvent {
			get {
				return _LastEvent;
			}
			set {
				_LastEvent = value;
				RaisePropertyChanged("LastEvent");
			}
		}
		private string _LastEventStage;
		public string LastEventStage {
			get {
				return _LastEventStage;
			}
			set {
				_LastEventStage = value;
				RaisePropertyChanged("LastEventStage");
			}
		}
		private string _LastEventTime;
		public string LastEventTime {
			get {
				return _LastEventTime;
			}
			set {
				_LastEventTime = value;
				RaisePropertyChanged("LastEventTime");
			}
		}
		private ImageSource _TimerImageSource;
		public ImageSource TimerImageSource {
			get {
				return _TimerImageSource;
			}
			set {
				_TimerImageSource = value;
				RaisePropertyChanged("TimerImageSource");
			}
		}
		private Visibility _AbortButtonVisibility;
		public Visibility AbortButtonVisibility {
			get {
				return _AbortButtonVisibility;
			}
			set {
				_AbortButtonVisibility = value;
				RaisePropertyChanged("AbortButtonVisibility");
			}
		}
		private Visibility _ContinueButtonVisibility;
		public Visibility ContinueButtonVisibility {
			get {
				return _ContinueButtonVisibility;
			}
			set {
				_ContinueButtonVisibility = value;
				RaisePropertyChanged("ContinueButtonVisibility");
			}
		}

		public RelayCommand AbortCommand { get; private set; }
		public RelayCommand ContinueCommand { get; private set; }
		public RelayCommand UndoCommand { get; private set; }
		public RelayCommand CrossBaselineCommand { get; private set; }

		public DesignerMatchViewModel() {
			RecorderIDLabel = "Person 1";
			AllianceLabel = "Blue 1";
			EventLabel = "Practice";
			MatchNumberLabel = string.Format("Match {0}", 1);
			TeamNumberLabel = string.Format("Team {0}", 2512);
			Time = "1:23";
			LastEvent = "Cube in Scale";
			LastEventStage = "Teleop";
			LastEventTime = "1:23";
			TimerImageSource = new BitmapImage(new Uri("pack://application:,,,/MVVM;component/Resources/Images/ok-hand-deepfried.png"));
			AbortButtonVisibility = Visibility.Visible;
			ContinueButtonVisibility = Visibility.Collapsed;
			
			AbortCommand = new RelayCommand(delegate { });
			ContinueCommand = new RelayCommand(delegate { });
			UndoCommand = new RelayCommand(delegate { });
			CrossBaselineCommand = new RelayCommand(delegate { });
		}
	}
}
