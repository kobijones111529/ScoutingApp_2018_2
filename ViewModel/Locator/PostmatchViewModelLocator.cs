namespace MVVM.ViewModel {
	public class PostmatchViewModelLocator : ViewModelLocator<IPostmatchViewModel, PostmatchViewModel> {
		public PostmatchViewModelLocator() {
			DesignerViewModel = new DesignerPostmatchViewModel();
		}
	}
}
