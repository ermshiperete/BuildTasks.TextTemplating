using Microsoft.VisualStudio.TextTemplating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BuildTasks.TextTemplating
{
    internal class TemplateGeneratorSession : ITextTemplatingSession
    {
        private readonly Dictionary<string, object> _values = new Dictionary<string, object>();

        public Guid Id { get; private set; }

        public ICollection<string> Keys { get { return _values.Keys; } }

        public ICollection<object> Values { get { return _values.Values; } }

        public object this[string key]
        {
            get { return _values[key];  }
            set { _values[key] = value; }
        }

        public int Count { get { return _values.Count; } }

        public bool IsReadOnly { get { return false; } }

        public TemplateGeneratorSession()
        {
            Id = Guid.NewGuid();
        }

        public bool Equals(ITextTemplatingSession other)
        {
            return other == this;
        }

        public bool Equals(Guid other)
        {
            return Id.Equals(other);
        }

        public void Add(string key, object value)
        {
            _values.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return _values.ContainsKey(key);
        }

        public bool Remove(string key)
        {
            return _values.Remove(key);
        }

        public bool TryGetValue(string key, out object value)
        {
            return _values.TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<string, object> item)
        {
            _values.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            _values.Clear();
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            object value;
            return _values.TryGetValue(item.Key, out value) &&
                (object.ReferenceEquals(value, item) || (value != null && value.Equals(item.Value)));
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            Array.Copy(_values.ToArray(), 0, array, arrayIndex, array.Length - arrayIndex);
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            object value;
            if (_values.TryGetValue(item.Key, out value) &&
                (object.ReferenceEquals(value, item) || (value != null && value.Equals(item.Value))))
            {
                return _values.Remove(item.Key);
            }
            return false;
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
