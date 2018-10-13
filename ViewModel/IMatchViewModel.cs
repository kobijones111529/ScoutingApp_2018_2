﻿using System.Windows.Media;

namespace MVVM.ViewModel {
	public interface IMatchViewModel {
		string RecorderIDLabel { get; }
		string AllianceLabel { get; }
		string EventLabel { get; }
		string MatchNumberLabel { get; }
		string TeamNumberLabel { get; }
		string Time { get; }
		ImageSource TimerImageSource { get; }
	}
}
