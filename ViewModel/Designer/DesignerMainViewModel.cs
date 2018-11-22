using System;

namespace MVVM.ViewModel {
	public class DesignerMainViewModel : ViewModelBase, IMainViewModel {
		private IViewModelType _CurrentViewModel;
		public IViewModelType CurrentViewModel {
			get {
				return _CurrentViewModel;
			}
			set {
				_CurrentViewModel = value;
				RaisePropertyChanged("CurrentViewModel");
			}
		}

		public DesignerMainViewModel() {
			CurrentViewModel = (IViewModelType)Activator.CreateInstance(typeof(HomeViewModelType));
		}
	}
}