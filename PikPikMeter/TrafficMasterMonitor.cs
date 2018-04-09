using PikPikMeter.Properties;
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
		public NotifyIcon Icon;
	}

	/**
	 * <summary>
	 * Border class between GUI and Traffic monitoring.
	 * </summary>
	 */
	class TrafficMasterMonitor
	{
		public TrafficMasterMonitorDisplay Display;

		private readonly int TotalsAverageCount = 5;
		private TrafficGrabber TrafficGrabber = new TrafficGrabber();
		private TrafficStat TrafficStat = new TrafficStat();
		private TrafficGraphPaint _GraphPaint = new TrafficGraphPaint();
		private bool _PaintOnIcon = false;

		public TrafficGraphPaint GraphPaint
		{
			get { return _GraphPaint; }
		}

		public bool GraphOnIcon
		{
			get { return _PaintOnIcon; }
			set
			{
				_PaintOnIcon = value;
				if (!_PaintOnIcon)
					Display.Icon.Icon = Resources.tray;
			}
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
			Repaint();
		}

		public void Repaint()
		{
			if (Display.Graph != null)
			{
				GraphPaint.Paint(Display.Graph, TrafficStat);
			}
			if (Display.Icon != null)
			{
				Display.Icon.Text = String.Format("DL {0}\nUL {1}",
					TotalText(Stat.Download),
					TotalText(Stat.Upload));
				// Paint must happen after we set the Text, otherwise the icon will be blank.
				if (GraphOnIcon)
					GraphPaint.Paint(Display.Icon, TrafficStat);
			}
			if (Display.LabelDownload != null)
			{
				Display.LabelDownload.Text = TotalText(Stat.Download);
			}
			if (Display.LabelUpload != null)
			{
				Display.LabelUpload.Text = TotalText(Stat.Upload);
			}
		}

		public void SetNicEnabled(string nic, bool enabled)
		{
			TrafficStat.SetNicEnabled(nic, enabled);
		}

		private string TotalText(Stat stat)
		{
			float[] totals = TrafficStat.Total(stat, TotalsAverageCount);
			bool bits = GraphPaint.Scale.InBits; // TODO bad programming practice, code smell.
			float average = totals.Average();
			if (bits)
				average *= 8.0f;
			var trafficValue = new TrafficUnitValue(average, bits);
			return (totals.Length > 0) ?
				TrafficUnit.Humanize(trafficValue) + "/s" :
				"N/A";
		}
	}
}
