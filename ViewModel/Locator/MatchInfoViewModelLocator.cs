namespace MVVM.ViewModel {
	public class MatchInfoViewModelLocator : ViewModelLocator<IMatchInfoViewModel, MatchInfoViewModel> {
		public MatchInfoViewModelLocator() {
			DesignerViewModel = new DesignerMatchInfoViewModel();
		}
	}
}