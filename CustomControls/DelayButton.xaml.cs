using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM.CustomControls {
	public partial class DelayButton : Button {
		public SolidColorBrush DelayBackground {
			get {
				return (SolidColorBrush)GetValue(DelayBackgroundProperty);
			}
			set {
				SetValue(DelayBackgroundProperty, value);
			}
		}
		public SolidColorBrush DelayForeground {
			get {
				return (SolidColorBrush)GetValue(DelayForegroundProperty);
			}
			set {
				SetValue(DelayForegroundProperty, value);
			}
		}
		public double DelayBackgroundOpacity {
			get {
				return (double)GetValue(DelayBackgroundOpacityProperty);
			}
			set {
				SetValue(DelayBackgroundOpacityProperty, value);
			}
		}
		public double DelayForegroundOpacity {
			get {
				return (double)GetValue(DelayForegroundOpacityProperty);
			}
			set {
				SetValue(DelayForegroundOpacityProperty, value);
			}
		}
		public double ContentOpacity {
			get {
				return (double)GetValue(ContentOpacityProperty);
			}
			set {
				SetValue(ContentOpacityProperty, value);
			}
		}
		public double Progress {
			get {
				return (double)GetValue(ProgressProperty);
			}
			set {
				SetValue(ProgressProperty, value);
			}
		}

		public static readonly DependencyProperty DelayBackgroundProperty = DependencyProperty.Register("DelayBackground", typeof(SolidColorBrush), typeof(DelayButton), new PropertyMetadata(new SolidColorBrush(Colors.DarkGray)));
		public static readonly DependencyProperty DelayForegroundProperty = DependencyProperty.Register("DelayForeground", typeof(SolidColorBrush), typeof(DelayButton), new PropertyMetadata(new SolidColorBrush(Colors.White)));
		public static readonly DependencyProperty DelayBackgroundOpacityProperty = DependencyProperty.Register("DelayBackgroundOpacity", typeof(double), typeof(DelayButton), new PropertyMetadata((double)0));
		public static readonly DependencyProperty DelayForegroundOpacityProperty = DependencyProperty.Register("DelayForegroundOpacity", typeof(double), typeof(DelayButton), new PropertyMetadata((double)0));
		public static readonly DependencyProperty ContentOpacityProperty = DependencyProperty.Register("ContentOpacity", typeof(double), typeof(DelayButton), new PropertyMetadata((double)1));
		public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register("Progress", typeof(double), typeof(DelayButton), new PropertyMetadata((double)1));

		public DelayButton() {
			InitializeComponent();
		}
	}
}
