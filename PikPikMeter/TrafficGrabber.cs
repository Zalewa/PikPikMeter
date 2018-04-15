using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikPikMeter
{
	/// <summary>
	/// Collection of <see cref="TrafficNic"/> objects, used to grab
	/// measures from them in unison.
	/// </summary>
	public class TrafficGrabber
	{
		private List<TrafficNic> nicsTraffic = new List<TrafficNic>();

		public TrafficGrabber()
		{
			RefreshNics();
		}

		/// <summary>
		/// Get the list of Network Interfaces from the Operating System and memorize
		/// them for future use in <see cref="GrabMeasures"/>. <see cref="GrabMeasures"/>
		/// itself will also refresh the list if error occurs. Objects for already known
		/// NICs are not recreated.
		/// </summary>
		public void RefreshNics()
		{
			// Network Interfaces can come and go during normal OS operation.
			var osNics = TrafficNic.Nics;
			// Add only the new NICs, leaving alone existing ones.
			foreach (string nic in osNics)
			{
				if (!nicsTraffic.Exists(e => e.Nic == nic))
					nicsTraffic.Add(new TrafficNic(nic));
			}
			// Remove from the list NICs that are gone.
			nicsTraffic.RemoveAll(e => !osNics.Contains(e.Nic));
		}

		/// <summary>
		/// Grab traffic measures from the Network Interfaces remembered through
		/// previous call to <see cref="RefreshNics"/>. This is error resilient
		/// and will simply not return a measure for given Interface if error
		/// occurs. In such case, the Network Interfaces list is refreshed again
		/// in hopes that the problematic Interface will be gone from the list.
		/// </summary>
		public List<TrafficNicMeasure> GrabMeasures()
		{
			bool needReset = false;
			RefreshNics();
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
					needReset = true;
				}
			}
			if (needReset)
			{
				ClearNics();
				RefreshNics();
			}
			return measures;
		}

		private void ClearNics()
		{
			nicsTraffic = new List<TrafficNic>();
		}
	}
}
