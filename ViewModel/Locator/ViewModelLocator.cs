using GalaSoft.MvvmLight.Ioc;
using System;
using System.ComponentModel;
using System.Windows;

namespace MVVM.ViewModel {
	/// <summary>
	/// Provides appropriate designer or runtime viewmodel to view
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <typeparam name="S"></typeparam>
	public abstract class ViewModelLocator<T, S> : INotifyPropertyChanged where T : class where S : class {
		private static DependencyObject _DummyObject = new DependencyObject();
		private static bool? _IsInDesignMode;
		private T _DesignerViewModel;
		private T _RuntimeViewModel;

		public static bool IsInDesignMode {
			get {
				if(!_IsInDesignMode.HasValue) {
					_IsInDesignMode = DesignerProperties.GetIsInDesignMode(_DummyObject);
				}
				return _IsInDesignMode.Value;
			}
		}
		public T DesignerViewModel {
			get {
				return _DesignerViewModel;
			}
			set {
				_DesignerViewModel = value;
				RaisePropertyChanged("ViewModel");
			}
		}
		protected T RuntimeViewModel {
			get {
				if(_RuntimeViewModel == null) {
					//_RuntimeViewModel = SimpleIoc.Default.GetInstance<T>();
					_RuntimeViewModel = (T)Activator.CreateInstance(typeof(S));
				}
				return _RuntimeViewModel;
			}
			set {
				_RuntimeViewModel = value;
				RaisePropertyChanged("ViewModel");
			}
		}
		public T ViewModel {
			get {
				return IsInDesignMode ? DesignerViewModel : RuntimeViewModel;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void RaisePropertyChanged(string property) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
		}
	}
}
