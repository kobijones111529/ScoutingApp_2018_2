using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MVVM.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace MVVM.ViewModel {
	public class MatchInfoViewModel : ViewModelBase, IMatchInfoViewModel {
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

		private bool _Navigating = false;

		public RelayCommand NavigateHomeCommand { get; private set; }
		public RelayCommand SubmitCommand { get; private set; }

		public MatchInfoViewModel() {
			NavigateHomeCommand = new RelayCommand(NavigateHome, () => {
				return !_Navigating;
			});
			SubmitCommand = new RelayCommand(Submit, () => {
				if(_Navigating) {
					return false;
				}
				if(!SelectedRecorderID.Any()) {
					return false;
				}
				if(!SelectedAlliance.Any()) {
					return false;
				}
				if(!SelectedEvent.Any()) {
					return false;
				}
				if(!MatchNumber.Any()) {
					return false;
				}
				if(!TeamNumber.Any()) {
					return false;
				}
				return true;
			});
			NavigateHomeCommand.RaiseCanExecuteChanged();
			SubmitCommand.RaiseCanExecuteChanged();

			Messenger.Default.Send(new Message.RetrieveDataMessage<Model.MatchInfoSource>() {
				SetData = (MatchInfoSource matchInfoSource) => {
					RecorderIDSource = matchInfoSource.RecorderIDSource;
					AllianceSource = matchInfoSource.AllianceSource;
					EventSource = matchInfoSource.EventSource;
				}
			});
			Messenger.Default.Send(new Message.RetrieveDataMessage<Model.MatchInfo>() {
				SetData = (MatchInfo matchInfo) => {
					SelectedRecorderID = matchInfo.RecorderID;
					SelectedAlliance = matchInfo.Alliance;
					SelectedEvent = matchInfo.Event;
					MatchNumber = Convert.ToString(matchInfo.MatchNumber);
					TeamNumber = Convert.ToString(matchInfo.TeamNumber);
				}
			});
		}

		private void NavigateHome() {
			_Navigating = true;
			Messenger.Default.Send(new Message.NavigateMessage() {
				Type = new HomeViewModelType()
			});
		}

		private void Submit() {
			_Navigating = true;
			Messenger.Default.Send(new Message.SendDataMessage<Model.MatchInfo>() {
				SetData = (ref MatchInfo matchInfo) => {
					matchInfo.RecorderID = SelectedRecorderID;
					matchInfo.Alliance = SelectedAlliance;
					matchInfo.Event = SelectedEvent;
					matchInfo.MatchNumber = Convert.ToUInt16(MatchNumber);
					matchInfo.TeamNumber = Convert.ToUInt16(TeamNumber);
				}
			});
			Messenger.Default.Send(new Message.NavigateMessage() {
				Type = new PrematchViewModelType()
			});
		}
	}
}
