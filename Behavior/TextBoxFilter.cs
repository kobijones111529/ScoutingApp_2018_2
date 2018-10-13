using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MVVM.Behavior {
	public static class TextBoxFilter {
		public static readonly DependencyProperty IsNumericProperty = DependencyProperty.RegisterAttached("IsNumeric", typeof(bool), typeof(TextBoxFilter), new PropertyMetadata(false, IsNumericChanged));
		public static bool GetIsNumeric(TextBox textBox) {
			return (bool)textBox.GetValue(IsNumericProperty);
		}
		public static void SetIsNumeric(TextBox textBox, bool value) {
			textBox.SetValue(IsNumericProperty, value);
		}

		public static void IsNumericChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e) {
			TextBox textBox = dependencyObject as TextBox;
			if(textBox == null) {
				return;
			}
			if(e.NewValue is bool && (bool)e.NewValue) {
				textBox.PreviewTextInput += NumericOnTextInput;
				textBox.PreviewKeyDown += NumericOnKeyDown;
				DataObject.AddPastingHandler(textBox, NumericOnPaste);
			} else {
				textBox.PreviewTextInput -= NumericOnTextInput;
				textBox.PreviewKeyDown -= NumericOnKeyDown;
				DataObject.RemovePastingHandler(textBox, NumericOnPaste);
			}
		}

		private static void NumericOnTextInput(object sender, TextCompositionEventArgs e) {
			TextBox textBox = sender as TextBox;
			if(e.Text.Any(c => !char.IsDigit(c))) {
				e.Handled = true;
				return;
			}
			string beforeSelection = textBox.Text.Substring(0, textBox.SelectionStart);
			string afterSelection = textBox.Text.Substring(textBox.SelectionStart + textBox.SelectionLength, textBox.Text.Length - (textBox.SelectionStart + textBox.SelectionLength));
			if(!ushort.TryParse(beforeSelection + e.Text + afterSelection, out ushort result)) {
				e.Handled = true;
				return;
			}
		}
		private static void NumericOnKeyDown(object sender, KeyEventArgs e) {
			if(e.Key == Key.Space) {
				e.Handled = true;
			}
		}
		private static void NumericOnPaste(object sender, DataObjectPastingEventArgs e) {
			TextBox textBox = sender as TextBox;
			if(e.DataObject.GetDataPresent(DataFormats.Text)) {
				string text = Convert.ToString(e.DataObject.GetData(DataFormats.Text));
				if(text.Any(c => !char.IsDigit(c))) {
					e.CancelCommand();
					return;
				}
				string beforeSelection = textBox.Text.Substring(0, textBox.SelectionStart);
				string afterSelection = textBox.Text.Substring(textBox.SelectionStart + textBox.SelectionLength, textBox.Text.Length - (textBox.SelectionStart + textBox.SelectionLength));
				if(!ushort.TryParse(beforeSelection + text + afterSelection, out ushort result)) {
					e.CancelCommand();
					return;
				}
			} else {
				e.CancelCommand();
				return;
			}
		}
	}
}
