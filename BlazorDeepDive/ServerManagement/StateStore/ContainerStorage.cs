using ServerManagement.Models;

namespace ServerManagement.StateStore
{
	public class ContainerStorage
	{
		private Server _server = new Server();

        public Server Server
		{
			get { return _server; }
			set { _server = value; }
		}
    }
}
