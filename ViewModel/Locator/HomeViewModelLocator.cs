namespace MVVM.ViewModel {
	public class HomeViewModelLocator : ViewModelLocator<IHomeViewModel, HomeViewModel> {
		public HomeViewModelLocator() {
			DesignerViewModel = new DesignerHomeViewModel();
		}
	}
}