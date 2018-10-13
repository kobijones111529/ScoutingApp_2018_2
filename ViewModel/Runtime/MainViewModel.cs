using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;

namespace MVVM.ViewModel {
	public class MainViewModel : ViewModelBase, IMainViewModel {
		private Model.MatchInfoSource MatchInfoSource;
		private Model.MatchInfo MatchInfo;

		private IViewModelType _CurrentViewModelType;
		public IViewModelType CurrentViewModelType {
			get {
				return _CurrentViewModelType;
			}
			set {
				_CurrentViewModelType = value;
				RaisePropertyChanged("CurrentViewModelType");
			}
		}

		public MainViewModel() {
			MatchInfoSource = new Model.MatchInfoSource() {
				RecorderIDSource = new ObservableCollection<string>() {
					"Person 1",
					"Person 2"
				},
				AllianceSource = new ObservableCollection<string>() {
					"Blue 1",
					"Blue 2",
					"Blue 3",
					"Red 1",
					"Red 2",
					"Red 3",
				},
				EventSource = new ObservableCollection<string>() {
					"Practice"
				}
			};
			MatchInfo = new Model.MatchInfo() {
				RecorderID = MatchInfoSource.RecorderIDSource[0],
				Alliance = MatchInfoSource.AllianceSource[0],
				Event = MatchInfoSource.EventSource[0],
				MatchNumber = 1,
				TeamNumber = 2512
			};

			Messenger.Default.Register<Message.NavigateMessage>(this, Navigate);
			Messenger.Default.Register<Message.RetrieveDataMessage<Model.MatchInfoSource>>(this, (msg) => {
				msg.SetData(MatchInfoSource);
			});
			Messenger.Default.Register<Message.RetrieveDataMessage<Model.MatchInfo>>(this, (msg) => {
				msg.SetData(MatchInfo);
			});
			Messenger.Default.Register<Message.SendDataMessage<Model.MatchInfo>>(this, (msg) => {
				msg.SetData(ref MatchInfo);
			});

			CurrentViewModelType = new HomeViewModelType();
		}

		private void Navigate(Message.NavigateMessage msg) {
			CurrentViewModelType = msg.Type;
		}
	}
}
