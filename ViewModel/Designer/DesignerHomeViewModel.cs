﻿using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MVVM.ViewModel {
	public class DesignerHomeViewModel : ViewModelBase, IHomeViewModel {
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
		private string _ImageSourceString = "../image.jpeg";
		public string ImageSourceString {
			get {
				return _ImageSourceString;
			}
			set {
				_ImageSourceString = value;
				RaisePropertyChanged("ImageSourceString");
			}
		}

		public RelayCommand NavigateMatchInfoCommand { get; private set; }
		public RelayCommand NavigateDataCommand { get; private set; }

		public DesignerHomeViewModel() {
			ImageSource = new BitmapImage(new Uri("pack://application:,,,/MVVM;component/Resources/Images/alex_v2.jpg"));
			Action navigate = delegate { };
			NavigateMatchInfoCommand = new RelayCommand(navigate);
			NavigateDataCommand = new RelayCommand(navigate);
		}
	}
}