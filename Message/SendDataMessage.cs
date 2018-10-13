using System;

namespace MVVM.Message {
	public class SendDataMessage<T> {
		public delegate void SetDataDelegate(ref T data);
		public SetDataDelegate SetData { get; set; }
	}
}
