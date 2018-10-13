using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MVVM.ViewModel {
	public class HomeViewModel : ViewModelBase, IHomeViewModel {
		private ImageSource _ImageSource;
		public ImageSource ImageSource {
			get {
				return _ImageSource;
			}
			set {
				_ImageSource = value;
				RaisePropertyChanged("ImageSource");
			}
		}

		public RelayCommand NavigateMatchInfoCommand { get; private set; }
		public RelayCommand NavigateDataCommand { get; private set; }

		private bool _CanNavigateMatchInfo = true;
		private bool _CanNavigateData = false;

		public HomeViewModel() {
			ImageSource = new BitmapImage(new Uri("pack://application:,,,/MVVM;component/deepfried.png"));
			NavigateMatchInfoCommand = new RelayCommand(NavigateMatchInfo, CanNavigateMatchInfo);
			NavigateDataCommand = new RelayCommand(NavigateData, CanNavigateData);
			NavigateMatchInfoCommand.RaiseCanExecuteChanged();
			NavigateDataCommand.RaiseCanExecuteChanged();
		}

		private void NavigateMatchInfo() {
			ImageSource = new BitmapImage(new Uri("C:\\Projects\\MVVM\\MVVM\\image.jpeg"));
			_CanNavigateMatchInfo = false;
			Messenger.Default.Send(new Message.NavigateMessage() { Type = new ViewModel.MatchInfoViewModelType() });
		}
		private bool CanNavigateMatchInfo() {
			return _CanNavigateMatchInfo;
		}
		private void NavigateData() {
			_CanNavigateData = false;
		}
		private bool CanNavigateData() {
			return _CanNavigateData;
		}
	}
}
