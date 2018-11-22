using GalaSoft.MvvmLight.Messaging;
using MVVM.Message;
using MVVM.Model;

namespace MVVM.ViewModel {
	public class PostmatchViewModel : ViewModelBase, IPostmatchViewModel {
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

		public PostmatchViewModel() {
			Messenger.Default.Send(new RetrieveDataMessage<MatchInfo>() {
				SetData = SetMatchInfo
			});
		}

		void SetMatchInfo(MatchInfo matchInfo) {
			RecorderIDLabel = matchInfo.RecorderID;
			AllianceLabel = matchInfo.Alliance;
			EventLabel = matchInfo.Event;
			MatchNumberLabel = string.Format("Match {0}", matchInfo.MatchNumber);
			TeamNumberLabel = string.Format("Team {0}", matchInfo.TeamNumber);
		}
	}
}
