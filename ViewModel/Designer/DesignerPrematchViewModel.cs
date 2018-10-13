using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;

namespace MVVM.ViewModel {
	public class DesignerPrematchViewModel : ViewModelBase, IPrematchViewModel {
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

		public DesignerPrematchViewModel() {
			RecorderIDLabel = "Person 1";
			AllianceLabel = "Blue 1";
			EventLabel = "Practice";
			MatchNumberLabel = string.Format("Match {0}", 1);
			TeamNumberLabel = string.Format("Team {0}", 2512);
			PrematchNotes = "Notes";
			IsThisLoss = string.Empty;

			Action navigate = delegate { };
			Func<bool> canNavigate = delegate {
				return true;
			};
			NavigateHomeCommand = new RelayCommand(navigate, canNavigate);
			NavigateBackCommand = new RelayCommand(navigate, canNavigate);
			StartMatchCommand = new RelayCommand(navigate, canNavigate);
		}
	}
}
