using System.Diagnostics.CodeAnalysis;

namespace MySession.MySession
{
    public class MySession(string id, IMySessionStorageEngine engine) : ISession
    {
        private readonly Dictionary<string, byte[]> _store = new Dictionary<string, byte[]>();
        public bool IsAvailable
        {
            get
            {
                LoadAsync(CancellationToken.None).Wait();
                return true;
            }
        }

        public string Id => id;

        public IEnumerable<string> Keys => _store.Keys;

        public void Clear()
        {
            _store.Clear();
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
           //await engine.CommitAsync(id, _store, cancellationToken);
           await engine.CommitAsync(Id ,_store, cancellationToken);
        }

        public async Task LoadAsync(CancellationToken cancellationToken = default)
        {
            _store.Clear();
            //return engine.LoadAsync(id, _store, cancellationToken);
          var loadedStore = await engine.LoadAsync(Id, cancellationToken);
            foreach (var item in loadedStore)
            {
                _store[item.Key] = item.Value;
            }
        }

        public void Remove(string key)
        {
           _store.Remove(key);
        }

        public void Set(string key, byte[] value)
        {
            _store[key] = value;
        }

        public bool TryGetValue(string key, [NotNullWhen(true)] out byte[]? value)
        {
           return _store.TryGetValue(key, out value);
        }
    }
}
