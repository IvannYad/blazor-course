using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ServerManagement.StateStore
{
	public class TorontoOnlineServersStore : Observer
	{
		private int _servicesOnlineCount;

        public int OnlineCount
		{
			get { return _servicesOnlineCount; }
			set
			{
				_servicesOnlineCount = value;
				base.Notify();
			}
		}
    }
}
