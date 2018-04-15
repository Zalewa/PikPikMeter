using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikPikMeter
{
	/// <summary>Error denotes any problem with traffic measure grab.</summary>
	class TrafficMeasureException : Exception
	{
		public TrafficMeasureException()
		{
		}

		public TrafficMeasureException(string message)
			: base(message)
		{
		}

		public TrafficMeasureException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
