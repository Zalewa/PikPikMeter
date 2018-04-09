using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikPikMeter
{
	public class TrafficNic
	{
		private string nic;
		private PerformanceCounter dlCounter;
		private PerformanceCounter ulCounter;

		public TrafficNic(string nic)
		{
			this.nic = nic;
			this.dlCounter = CreateCounter("Bytes Received/sec");
			this.ulCounter = CreateCounter("Bytes Sent/sec");
		}

		/// <summary>
		/// All Network Interface Controllers currently available in the system.
		/// </summary>
		public static string[] Nics
		{
			get
			{
				return new PerformanceCounterCategory("Network Interface").GetInstanceNames();
			}
		}

		public string Nic { get { return nic; } }

		public TrafficNicMeasure Measure()
		{
			try
			{
				return new TrafficNicMeasure(this.nic,
					this.dlCounter.NextValue(),
					this.ulCounter.NextValue());
			}
			catch (Exception e)
			{
				throw new TrafficMeasureException("cannot get measure for NIC " + nic, e);
			}
		}

		private PerformanceCounter CreateCounter(string counter)
		{
			return new PerformanceCounter("Network Interface", counter, this.nic);
		}
	}
}
