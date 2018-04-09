using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikPikMeter
{
	public class TrafficGrabber
	{
		private List<TrafficNic> nicsTraffic = new List<TrafficNic>();

		public TrafficGrabber()
		{
			RefreshNics();
		}

		public void RefreshNics()
		{
			// Network Interfaces can come and go during normal OS operation.
			var nics = new List<TrafficNic>();
			foreach (string nic in TrafficNic.Nics)
			{
				nics.Add(new TrafficNic(nic));
			}
			this.nicsTraffic = nics;
		}

		public List<TrafficNicMeasure> GrabMeasures()
		{
			bool needRefresh = false;
			var measures = new List<TrafficNicMeasure>();
			foreach (TrafficNic nicTraffic in this.nicsTraffic)
			{
				try
				{
					measures.Add(nicTraffic.Measure());
				}
				catch (TrafficMeasureException ex)
				{
					// TODO log me
					needRefresh = true;
				}
			}
			if (needRefresh)
				RefreshNics();
			return measures;
		}
	}
}
