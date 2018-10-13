using System;
using System.ComponentModel;

namespace MVVM.Model {
	public abstract class ModelBase : INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;

		protected void RaisePropertyChanged(string property) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
		}
	}
}
