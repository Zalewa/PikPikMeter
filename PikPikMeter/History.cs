using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikPikMeter
{
	/// <summary>
	/// A limited generic LIFO queue with capability of dynamic limit change.
	/// When new elements are added and the current amount breaches the limit,
	/// the oldest elemements are removed.
	/// </summary>
	public class History<T>
	{
		private List<T> elements = new List<T>();
		private int limit;

		public History(int limit)
		{
			this.limit = limit;
		}

		/// <summary>Amount of elements in history.</summary>
		public int Count { get { return elements.Count; } }

		/// <summary>All elements in history, in LIFO order.</summary>
		public ReadOnlyCollection<T> Elements { get { return elements.AsReadOnly(); } }

		/// <summary>Total amount of elements that are kept in history.</summary>
		public int Limit
		{
			get { return this.limit; }
			set
			{
				this.limit = value;
				this.cull();
			}
		}

		/// <summary>
		/// Add element to history, if limit is breached, oldest element is removed.
		/// </summary>
		public void Add(T element)
		{
			elements.Insert(0, element);
			this.cull();
		}

		private void cull()
		{
			if (elements.Count > limit)
				elements.RemoveRange(limit, elements.Count - limit);
		}
	}
}
