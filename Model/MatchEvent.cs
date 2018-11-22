using System;
using System.ComponentModel;

namespace MVVM.Model {
	public class MatchEvent {
		public enum EventType {
			[Description("Cross Baseline")]
			CrossBaseline,
			[Description("Cube in Switch")]
			CubeInSwitch,
			[Description("Cube in Scale")]
			CubeInScale,
			[Description("Cube in Opponent Switch")]
			CubeInOpponentSwitch
		}
		public enum EventStage {
			Autonomous,
			Teleop,
			Endgame
		}
		public EventType Type { get; set; }
		public EventStage Stage { get; set; }
		public TimeSpan Time { get; set; }
	}
}
