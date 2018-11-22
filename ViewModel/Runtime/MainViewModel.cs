using GalaSoft.MvvmLight.Messaging;
using MVVM.Message;
using MVVM.Model;
using System;
using System.Collections.ObjectModel;

namespace MVVM.ViewModel {
	public class MainViewModel : ViewModelBase, IMainViewModel {
		private MatchInfoSource MatchInfoSource;
		private MatchInfo MatchInfo;

		private IViewModelType _CurrentViewModel;
		public IViewModelType CurrentViewModel {
			get {
				return _CurrentViewModel;
			}
			set {
				_CurrentViewModel = value;
				RaisePropertyChanged("CurrentViewModel");
			}
		}

		public MainViewModel() {
			MatchInfoSource = new MatchInfoSource() {
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
			MatchInfo = new MatchInfo() {
				RecorderID = MatchInfoSource.RecorderIDSource[0],
				Alliance = MatchInfoSource.AllianceSource[0],
				Event = MatchInfoSource.EventSource[0],
				MatchNumber = 1,
				TeamNumber = 2512
			};

			Messenger.Default.Register<NavigateMessage>(this, Navigate);
			Messenger.Default.Register<RetrieveDataMessage<MatchInfoSource>>(this, (msg) => {
				msg.SetData(MatchInfoSource);
			});
			Messenger.Default.Register<RetrieveDataMessage<MatchInfo>>(this, (msg) => {
				msg.SetData(MatchInfo);
			});
			Messenger.Default.Register<SendDataMessage<MatchInfo>>(this, (msg) => {
				msg.SetData(MatchInfo);
			});

			CurrentViewModel = (IViewModelType)Activator.CreateInstance(typeof(HomeViewModelType));
		}

		private void Navigate(Message.NavigateMessage msg) {
			CurrentViewModel = (IViewModelType)Activator.CreateInstance(msg.Type);
		}
	}
}
