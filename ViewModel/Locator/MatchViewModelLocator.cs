namespace MVVM.ViewModel {
	public class MatchViewModelLocator : ViewModelLocator<IMatchViewModel, MatchViewModel> {
		public MatchViewModelLocator() {
			DesignerViewModel = new DesignerMatchViewModel();
		}
	}
}
