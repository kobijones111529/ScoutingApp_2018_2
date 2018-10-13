namespace MVVM.ViewModel {
	public class PrematchViewModelLocator : ViewModelLocator<IPrematchViewModel, PrematchViewModel> {
		public PrematchViewModelLocator() {
			DesignerViewModel = new DesignerPrematchViewModel();
		}
	}
}
