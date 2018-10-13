namespace MVVM.ViewModel {
	public class MainViewModelLocator : ViewModelLocator<IMainViewModel, MainViewModel> {
		public MainViewModelLocator() {
			DesignerViewModel = new DesignerMainViewModel();
		}
	}
}