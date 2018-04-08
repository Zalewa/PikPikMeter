using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikPikMeter
{
	public class History<T>
	{
		private List<T> elements = new List<T>();
		private int limit;

		public History(int limit)
		{
			this.limit = limit;
		}

		public int Count { get { return elements.Count; } }

		public ReadOnlyCollection<T> Elements { get { return elements.AsReadOnly(); } }

		public int Limit
		{
			get { return this.limit; }
			set
			{
				this.limit = value;
				this.cull();
			}
		}

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
