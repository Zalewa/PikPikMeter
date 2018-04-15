using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikPikMeter
{
	/// <summary>
	/// Traffic statistic types that are of interest to the program.
	/// </summary>
	public enum Stat
	{
		Download,
		Upload
	}

	/// <summary>
	/// Traffic history holder. It accepts the raw measures data from external caller
	/// and transforms them into format more pallatable for program's purposes. It keeps
	/// the history for Network Interfaces that go down. It keeps the history by time
	/// units, with all Network Interfaces available for given measure kept as a single
	/// element in the history queue. This means that history deteriorates the same for
	/// all known Network Interfaces, regardless of whether they are up or down at any
	/// given moment.
	/// </summary>
	public class TrafficStat
	{
		private HashSet<string> DisabledNics = new HashSet<string>();
		private History<StatMeasure> measures;

		public TrafficStat(int historySize = 10000)
		{
			measures = new History<StatMeasure>(historySize);
		}

		/// <summary>
		/// Add a singular measurement for multiple Network Interfaces.
		/// It's normally expected that in a singular measure instance,
		/// all Network Interfaces available in the Operating System are
		/// measured at once and added here in one call.
		/// </summary>
		public void Add(List<TrafficNicMeasure> measures)
		{
			this.measures.Add(CalculateStatMeasure(measures));
		}

		/// <summary>
		/// Allows to disable or re-enable specific Network Interface
		/// from totals recalculations and data formatting. This affects
		/// data display, but not data collection.
		/// </summary>
		public void SetNicEnabled(string nic, bool enabled)
		{
			if (enabled)
				DisabledNics.Remove(nic);
			else
				DisabledNics.Add(nic);
			RecalculateAllStatMeasures();
		}

		/// <summary>
		/// Totals of given per-Interface amounts per history.
		/// Totals are calculated for a specific <see cref="Stat"/> only. To get a different
		/// stat, method must be called again.
		/// The length of history that is looked back can be limited with amount argument.
		/// This is useful when history is long but you only need the `amount` of last elements.
		/// </summary>
		public float[] Total(Stat stat, int amount)
		{
			int actualAmount = amount < this.measures.Count ? amount : this.measures.Count;
			if (actualAmount <= 0)
				return new float[] { };
			float[] totals = new float[actualAmount];
			// History is reversed - the freshest element is first,
			// but we want the oldest here first.
			int idx = actualAmount - 1;
			foreach (StatMeasure measure in this.measures.Elements)
			{
				switch (stat)
				{
				case Stat.Download:
					totals[idx] = measure.TotalDownload;
					break;
				case Stat.Upload:
					totals[idx] = measure.TotalUpload;
					break;
				default:
					break;
				}
				--idx;
				if (idx < 0)
					break;
			}
			return totals;
		}

		private void RecalculateAllStatMeasures()
		{
			var newMeasures = new History<StatMeasure>(this.measures.Limit);
			foreach (var measure in measures.Elements.Reverse())
				newMeasures.Add(CalculateStatMeasure(measure.NicMeasures));
			this.measures = newMeasures;
		}

		private StatMeasure CalculateStatMeasure(List<TrafficNicMeasure> trafficMeasures)
		{
			var enabledMeasures = trafficMeasures.FindAll(m => !DisabledNics.Contains(m.Nic));
			return new StatMeasure()
			{
				NicMeasures = trafficMeasures,
				TotalDownload = enabledMeasures.Sum(e => e.DownloadBytesPerSec),
				TotalUpload = enabledMeasures.Sum(e => e.UploadBytesPerSec)
			};
		}
	}

	struct StatMeasure
	{
		public List<TrafficNicMeasure> NicMeasures;
		public float TotalDownload;
		public float TotalUpload;
	}
}
