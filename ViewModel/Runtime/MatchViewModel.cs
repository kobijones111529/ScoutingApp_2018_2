using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MVVM.Message;
using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace MVVM.ViewModel {
	public class MatchViewModel : ViewModelBase, IMatchViewModel {
		private Stopwatch _Stopwatch;
		private DispatcherTimer _DispatcherTimer;
		private List<MatchEvent> _Events = new List<Model.MatchEvent>();

		private TimeSpan _MatchLength = new TimeSpan(0, 0, 5);
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

		public MatchViewModel() {
			LastEvent = "No Events";
			LastEventStage = null;
			LastEventTime = null;
			TimerImageSource = new BitmapImage(new Uri("pack://application:,,,/MVVM;component/Resources/Images/ok-hand-deepfried.png"));
			AbortButtonVisibility = Visibility.Visible;
			ContinueButtonVisibility = Visibility.Collapsed;

			AbortCommand = new RelayCommand(Abort);
			AbortCommand.RaiseCanExecuteChanged();
			ContinueCommand = new RelayCommand(Continue);
			ContinueCommand.RaiseCanExecuteChanged();
			UndoCommand = new RelayCommand(Undo, CanUndo);
			UndoCommand.RaiseCanExecuteChanged();
			CrossBaselineCommand = new RelayCommand(CrossBaseline);
			CrossBaselineCommand.RaiseCanExecuteChanged();

			Messenger.Default.Send(new RetrieveDataMessage<MatchInfo>() {
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

		private void SetMatchData(MatchData matchData) {
			matchData.Events = _Events;
		}

		private void Abort() {
			Messenger.Default.Send(new NavigateMessage() {
				Type = typeof(PrematchViewModelType)
			});
		}
		private void Continue() {
			Messenger.Default.Send(new SendDataMessage<MatchData>() {
				SetData = SetMatchData
			});
			Messenger.Default.Send(new NavigateMessage() {
				Type = typeof(PostmatchViewModelType)
			});
		}
		private void Undo() {
			UndoEvent();
		}
		private bool CanUndo() {
			return _Events.Any();
		}
		private void CrossBaseline() {
			AddEvent(new MatchEvent() {
				Type = MatchEvent.EventType.CrossBaseline,
				Stage = MatchEvent.EventStage.Autonomous,
				Time = _TimeRemaining
			});
		}

		private void StartTimers() {
			_Stopwatch = new Stopwatch();
			_DispatcherTimer = new DispatcherTimer() {
				Interval = TimeSpan.FromMilliseconds(1)
			};
			_DispatcherTimer.Tick += DispatcherTimer_Tick;
			_Stopwatch.Start();
			_DispatcherTimer.Start();
		}
		private void DispatcherTimer_Tick(object sender, EventArgs e) {
			Time = string.Format("{0:m\\:ss}", FormattedTimeSpan(_TimeRemaining));
			if(_Stopwatch.Elapsed > _MatchLength) {
				AbortButtonVisibility = Visibility.Collapsed;
				ContinueButtonVisibility = Visibility.Visible;
			}
		}

		private void AddEvent(MatchEvent matchEvent) {
			_Events.Insert(0, matchEvent);
			UpdateLastEvent();
			UndoCommand.RaiseCanExecuteChanged();
		}
		private void UndoEvent() {
			_Events.RemoveAt(0);
			UpdateLastEvent();
			UndoCommand.RaiseCanExecuteChanged();
		}
		private void UpdateLastEvent() {
			if(_Events.Any()) {
				LastEvent = Enum.GetDescription(_Events[0].Type);
				if(DuplicateEventCount > 1) {
					LastEvent += " x";
					LastEvent += DuplicateEventCount;
				}
				LastEventStage = _Events[0].Stage.ToString();
				LastEventTime = string.Format("{0:m\\:ss}", FormattedTimeSpan(_Events[0].Time));
			} else {
				LastEvent = "No Events";
				LastEventStage = null;
				LastEventTime = null;
			}
		}

		private TimeSpan FormattedTimeSpan(TimeSpan time) {
			return TimeSpan.FromSeconds(Math.Ceiling(time.TotalSeconds));
		}

		private int DuplicateEventCount {
			get {
				int count = 0;
				for(int i = 0; i < _Events.Count; i++, count++) {
					if(_Events[i].Type != _Events[0].Type)
						break;
					else if(_Events[i].Stage != _Events[0].Stage)
						break;
				}
				return count;
			}
		}
	}
}
