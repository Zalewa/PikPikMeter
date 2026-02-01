using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PikPikMeter
{
    /// <summary>
    /// A limited generic LIFO queue with capability of dynamic limit change.
    /// When new elements are added and the current amount breaches the limit,
    /// the oldest elemements are removed.
    /// </summary>
    public class History<T>
    {
        private List<T> _elements = new List<T>();
        private int _limit;

        public History(int limit)
        {
            this._limit = limit;
        }

        /// <summary>Amount of elements in history.</summary>
        public int Count { get { return _elements.Count; } }

        /// <summary>All elements in history, in LIFO order.</summary>
        public ReadOnlyCollection<T> Elements { get { return _elements.AsReadOnly(); } }

        /// <summary>Total amount of elements that are kept in history.</summary>
        public int Limit
        {
            get { return this._limit; }
            set
            {
                this._limit = value;
                this.Cull();
            }
        }

        /// <summary>
        /// Add element to history, if limit is breached, oldest element is removed.
        /// </summary>
        public void Add(T element)
        {
            _elements.Insert(0, element);
            this.Cull();
        }

        private void Cull()
        {
            if (_elements.Count > _limit)
                _elements.RemoveRange(_limit, _elements.Count - _limit);
        }
    }
}
