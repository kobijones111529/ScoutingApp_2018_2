namespace MVVM.ViewModel {
	public class DesignerMainViewModel : ViewModelBase, IMainViewModel {
		private IViewModelType _CurrentViewModelType;
		public IViewModelType CurrentViewModelType {
			get {
				return _CurrentViewModelType;
			}
			set {
				_CurrentViewModelType = value;
				RaisePropertyChanged("CurrentViewModelType");
			}
		}
	}
}