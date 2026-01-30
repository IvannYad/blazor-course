namespace ServerManagement.StateStore
{
	public class Observer
	{
		protected Action? _listeners;

		public void Subscribe(Action listener)
		{
			if (listener is not null)
				_listeners += listener;
		}

		public void Unsubscibe(Action? listener)
		{
			if (listener is not null)
				_listeners -= listener;
		}

		public void Notify()
		{
			_listeners?.Invoke();
		}
	}
}
