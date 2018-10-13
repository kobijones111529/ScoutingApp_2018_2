using GalaSoft.MvvmLight.Ioc;

namespace MVVM {
	public class Bootstrapper {
		public static void InitializeIoc() {
			SimpleIoc.Default.Register<ViewModel.IMainViewModel, ViewModel.MainViewModel>();
			SimpleIoc.Default.Register<ViewModel.IHomeViewModel, ViewModel.HomeViewModel>();
		}
	}
}
