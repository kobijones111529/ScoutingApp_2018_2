namespace MVVM.Message {
	public class SendDataMessage<T> {
		public delegate void SetDataDelegate(T data);
		public SetDataDelegate SetData { get; set; }
	}
}
