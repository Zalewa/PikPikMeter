using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikPikMeter
{
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
