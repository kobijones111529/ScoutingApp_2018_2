using System;
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

		public DesignerMatchViewModel() {
			RecorderIDLabel = "Person 1";
			AllianceLabel = "Blue 1";
			EventLabel = "Practice";
			MatchNumberLabel = string.Format("Match {0}", 1);
			TeamNumberLabel = string.Format("Team {0}", 2512);
			TimerImageSource = new BitmapImage(new Uri("pack://application:,,,/MVVM;component/ok-hand.jpg"));
		}
	}
}
