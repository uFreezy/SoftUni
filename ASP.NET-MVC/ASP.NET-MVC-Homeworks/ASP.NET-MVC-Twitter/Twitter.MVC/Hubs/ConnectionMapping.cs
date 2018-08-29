using System.Collections.Generic;
using System.Linq;

namespace Twitter.MVC.Hubs
{
    public class ConnectionMapping<T>
    {
        private readonly Dictionary<T, HashSet<string>> _connections =
            new Dictionary<T, HashSet<string>>();

        public int Count
        {
            get { return this._connections.Count; }
        }

        public void Add(T key, string connectionId)
        {
            lock (this._connections)
            {
                HashSet<string> connections;
                if (!this._connections.TryGetValue(key, out connections))
                {
                    connections = new HashSet<string>();
                    this._connections.Add(key, connections);
                }

                lock (connections)
                {
                    connections.Add(connectionId);
                }
            }
        }

        public IEnumerable<string> GetConnections(T key)
        {
            HashSet<string> connections;
            if (this._connections.TryGetValue(key, out connections))
            {
                return connections;
            }

            return Enumerable.Empty<string>();
        }

        public void Remove(T key, string connectionId)
        {
            lock (this._connections)
            {
                HashSet<string> connections;
                if (!this._connections.TryGetValue(key, out connections))
                {
                    return;
                }

                lock (connections)
                {
                    connections.Remove(connectionId);

                    if (connections.Count == 0)
                    {
                        this._connections.Remove(key);
                    }
                }
            }
        }
    }
}