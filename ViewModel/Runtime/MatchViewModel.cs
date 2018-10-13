using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Diagnostics;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace MVVM.ViewModel {
	public class MatchViewModel : ViewModelBase, IMatchViewModel {
		private Stopwatch _Stopwatch;
		private DispatcherTimer _DispatcherTimer;

		private TimeSpan _MatchLength = new TimeSpan(0, 2, 15);
		private TimeSpan _TimeRemaining {
			get {
				return _Stopwatch.Elapsed < _MatchLength ? _MatchLength - _Stopwatch.Elapsed : TimeSpan.Zero;
			}
		}

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

		public MatchViewModel() {
			_Stopwatch = new Stopwatch();
			_DispatcherTimer = new DispatcherTimer();

			TimerImageSource = new BitmapImage(new Uri("pack://application:,,,/MVVM;component/ok-hand.jpg"));

			Messenger.Default.Send(new Message.RetrieveDataMessage<Model.MatchInfo>() {
				SetData = (Model.MatchInfo matchInfo) => {
					RecorderIDLabel = matchInfo.RecorderID;
					AllianceLabel = matchInfo.Alliance;
					EventLabel = matchInfo.Event;
					MatchNumberLabel = string.Format("Match {0}", matchInfo.MatchNumber);
					TeamNumberLabel = string.Format("Team {0}", matchInfo.TeamNumber);
					StartTimers();
				}
			});


		}

		void StartTimers() {
			_Stopwatch = new Stopwatch();
			_DispatcherTimer = new DispatcherTimer() {
				Interval = new TimeSpan(0, 0, 0, 0, 1),
			};
			_DispatcherTimer.Tick += DispatcherTimerTick;
			_Stopwatch.Start();
			_DispatcherTimer.Start();
		}

		void DispatcherTimerTick(object sender, EventArgs e) {
			Time = string.Format("{0:m\\:ss}", _TimeRemaining);
		}
	}
}
