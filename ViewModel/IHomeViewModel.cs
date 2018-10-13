using GalaSoft.MvvmLight.Command;
using System.Windows.Media;

namespace MVVM.ViewModel {
	public interface IHomeViewModel {
		ImageSource ImageSource { get; }

		RelayCommand NavigateMatchInfoCommand { get; }
		RelayCommand NavigateDataCommand { get; }
	}
}