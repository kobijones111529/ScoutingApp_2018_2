using System;
using System.Windows.Input;

namespace MVVM.Command {
	public class CommandBase : ICommand {
		public event EventHandler CanExecuteChanged = delegate { };

		private Action _Command;
		private Func<bool> _CanExecute;

		public CommandBase(Action command) {
			_Command = command;
		}

		public CommandBase(Action command, Func<bool> canExecute) {
			_Command = command;
			_CanExecute = canExecute;
		}

		public void RaiseCanExecuteChanged() {
			CanExecuteChanged(this, EventArgs.Empty);
		}

		bool ICommand.CanExecute(object parameter) {
			if(_CanExecute != null) {
				return _CanExecute();
			}

			if(_Command != null) {
				return true;
			}

			return false;
		}

		void ICommand.Execute(object parameter) {
			_Command?.Invoke();
		}
	}
}
