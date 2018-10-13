using System;

namespace MVVM.Message {
	public class RetrieveDataMessage<T> {
		public delegate void SetDataDelegate(T data);
		public SetDataDelegate SetData { get; set; }
	}
}
