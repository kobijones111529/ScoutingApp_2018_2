using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace MVVM.ViewModel {
	public class PrematchViewModel : ViewModelBase, IPrematchViewModel {
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
		private string _PrematchNotes;
		public string PrematchNotes {
			get {
				return _PrematchNotes;
			}
			set {
				_PrematchNotes = value;
				RaisePropertyChanged("PrematchNotes");
				PrematchNotesChanges();
			}
		}
		private string _IsThisLoss;
		public string IsThisLoss {
			get {
				return _IsThisLoss;
			}
			set {
				_IsThisLoss = value;
				RaisePropertyChanged("IsThisLoss");
			}
		}
		private double _LossFontSize;
		public double LossFontSize {
			get {
				return _LossFontSize;
			}
			set {
				_LossFontSize = value;
				RaisePropertyChanged("LossFontSize");
			}
		}

		public RelayCommand NavigateHomeCommand { get; private set; }
		public RelayCommand NavigateBackCommand { get; private set; }
		public RelayCommand StartMatchCommand { get; private set; }

		private Message.SendDataMessage<Model.MatchInfo> SendMatchInfoMessage;

		public PrematchViewModel() {
			NavigateHomeCommand = new RelayCommand(NavigateHome, CanNavigateHome);
			NavigateBackCommand = new RelayCommand(NavigateBack, CanNavigateBack);
			StartMatchCommand = new RelayCommand(StartMatch, CanStartMatch);
			NavigateHomeCommand.RaiseCanExecuteChanged();
			NavigateBackCommand.RaiseCanExecuteChanged();
			StartMatchCommand.RaiseCanExecuteChanged();

			SendMatchInfoMessage = new Message.SendDataMessage<Model.MatchInfo>() {
				SetData = (ref Model.MatchInfo matchInfo) => {
					matchInfo.PrematchNotes = PrematchNotes;
				}
			};

			Messenger.Default.Send(new Message.RetrieveDataMessage<Model.MatchInfo>() {
				SetData = (Model.MatchInfo matchInfo) => {
					RecorderIDLabel = matchInfo.RecorderID;
					AllianceLabel = matchInfo.Alliance;
					EventLabel = matchInfo.Event;
					MatchNumberLabel = string.Format("Match {0}", matchInfo.MatchNumber);
					TeamNumberLabel = string.Format("Team {0}", matchInfo.TeamNumber);
					PrematchNotes = matchInfo.PrematchNotes;
				} 
			});
		}

		private void NavigateHome() {
			Messenger.Default.Send(SendMatchInfoMessage);
			Messenger.Default.Send(new Message.NavigateMessage() {
				Type = new HomeViewModelType()
			});
		}
		private bool CanNavigateHome() {
			return true;
		}
		private void NavigateBack() {
			Messenger.Default.Send(SendMatchInfoMessage);
			Messenger.Default.Send(new Message.NavigateMessage() {
				Type = new MatchInfoViewModelType()
			});
		}
		private bool CanNavigateBack() {
			return true;
		}
		private void StartMatch() {
			Messenger.Default.Send(SendMatchInfoMessage);
			Messenger.Default.Send(new Message.NavigateMessage() {
				Type = new MatchViewModelType()
			});
		}
		private bool CanStartMatch() {
			return true;
		}

		private void PrematchNotesChanges() {
			if(PrematchNotes == null) {
				IsThisLoss = string.Empty;
				LossFontSize = 18;
			} else if(PrematchNotes.Contains("| ||" + Environment.NewLine + "|| |_")) {
				IsThisLoss = "iS ThIS LosSs???";
				LossFontSize = 36;
			} else if(PrematchNotes.Contains("| ||")) {
				IsThisLoss = "is this...";
				LossFontSize = 18;
			} else {
				IsThisLoss = string.Empty;
				LossFontSize = 18;
			}
		}
	}
}