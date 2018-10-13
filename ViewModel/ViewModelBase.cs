using System.ComponentModel;

namespace MVVM.ViewModel {
	public class ViewModelBase : INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;

		protected void RaisePropertyChanged(string property) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
		}
	}
}
