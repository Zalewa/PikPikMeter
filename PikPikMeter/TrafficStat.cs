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
		private History<StatMeasure> measures;

		public TrafficStat(int historySize = 10000)
		{
			measures = new History<StatMeasure>(historySize);
		}

		public void Add(List<TrafficNicMeasure> measures)
		{
			var measure = new StatMeasure()
			{
				NicMeasures = measures,
				TotalDownload = measures.Sum(e => e.DownloadBytesPerSec),
				TotalUpload = measures.Sum(e => e.UploadBytesPerSec)
			};
			this.measures.Add(measure);
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
	}

	struct StatMeasure
	{
		public List<TrafficNicMeasure> NicMeasures;
		public float TotalDownload;
		public float TotalUpload;
	}
}
