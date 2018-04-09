using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikPikMeter
{
	public enum Stat
	{
		Download,
		Upload
	}

	public class TrafficStat
	{
		private HashSet<string> DisabledNics = new HashSet<string>();
		private History<StatMeasure> measures;

		public TrafficStat(int historySize = 10000)
		{
			measures = new History<StatMeasure>(historySize);
		}

		public void Add(List<TrafficNicMeasure> measures)
		{
			this.measures.Add(CalculateStatMeasure(measures));
		}

		public void SetNicEnabled(string nic, bool enabled)
		{
			if (enabled)
				DisabledNics.Remove(nic);
			else
				DisabledNics.Add(nic);
			RecalculateAllStatMeasures();
		}

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
