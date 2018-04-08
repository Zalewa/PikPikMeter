using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PikPikMeter
{
	public struct TrafficMasterMonitorDisplay
	{
		public Label LabelDownload;
		public Label LabelUpload;
		public PictureBox Graph;
	}

	/**
	 * <summary>
	 * Border class between GUI and Traffic monitoring.
	 * </summary>
	 */
	class TrafficMasterMonitor
	{
		public TrafficMasterMonitorDisplay Display;

		private TrafficGrabber TrafficGrabber = new TrafficGrabber();
		private TrafficStat TrafficStat = new TrafficStat();
		private TrafficGraphPaint _GraphPaint = new TrafficGraphPaint();

		public TrafficGraphPaint GraphPaint
		{
			get { return _GraphPaint; }
		}

		public void Start()
		{
			TrafficGrabber.RefreshNics();
			TrafficStat = new TrafficStat();
		}

		public void Tick()
		{
			List<TrafficNicMeasure> measures = TrafficGrabber.GrabMeasures();
			TrafficStat.Add(measures);
			if (Display.Graph != null)
			{
				GraphPaint.Paint(Display.Graph, TrafficStat);
			}
			if (Display.LabelDownload != null)
			{
				ApplyTotalTextToLabel(TrafficStat.Total(Stat.Download, 5), Display.LabelDownload);
			}
			if (Display.LabelUpload != null)
			{
				ApplyTotalTextToLabel(TrafficStat.Total(Stat.Upload, 5), Display.LabelUpload);
			}
		}

		private void ApplyTotalTextToLabel(float[] totals, Label label)
		{
			bool bits = GraphPaint.Scale.InBits; // TODO bad programming practice, code smell.
			float average = totals.Average();
			if (bits)
				average *= 8.0f;
			var trafficValue = new TrafficUnitValue(average, bits);
			label.Text = (totals.Length > 0) ?
				TrafficUnit.Humanize(trafficValue) + "/s" :
				"N/A";
		}
	}
}
