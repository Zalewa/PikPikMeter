using PikPikMeter.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PikPikMeter
{
	/// <summary>
	/// Reference listing for all UI elements that <see cref="TrafficMasterMonitor"/>
	/// uses to display the traffic statistics. The UI element that serves as the display
	/// needs to prepare this structure and send it to the monitor.
	/// </summary>
	public struct TrafficMasterMonitorDisplay
	{
		public Label LabelDownload;
		public Label LabelUpload;
		public PictureBox Graph;
		public NotifyIcon Icon;
	}

	/// <summary>
	/// Border class between GUI and Traffic monitoring. It starts and handles all
	/// the traffic monitoring systems and keeps and uses references to UI elements
	/// that serve as display of the traffic statistics.
	/// </summary>
	class TrafficMasterMonitor
	{
		/// <summary>Handle to the UI widgets for traffic display.</summary>
		public TrafficMasterMonitorDisplay Display;

		private readonly int TotalsAverageCount = 5;
		private TrafficGrabber TrafficGrabber = new TrafficGrabber();
		private TrafficStat TrafficStat = new TrafficStat();
		private TrafficGraphPaint _GraphPaint = new TrafficGraphPaint();
		private bool _PaintOnIcon = false;

		/// <summary>Object used to paint the graph, allows to alter colors and style.</summary>
		public TrafficGraphPaint GraphPaint
		{
			get { return _GraphPaint; }
		}

		/// <summary>All Network Interfaces that were measured at least once.</summary>
		public string[] KnownMeasuredNics
		{ get { return TrafficStat.KnownNics; } }

		/// <summary>Controls if graph is also painted on the tray icon.</summary>
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

		/// <summary>
		/// Initiates the monitoring system. Can be called again to reset the monitoring history.
		/// </summary>
		public void Start()
		{
			TrafficGrabber.RefreshNics();
			TrafficStat = new TrafficStat();
		}

		/// <summary>
		/// Grabs measures and updates the displays. Call this in a regular intervals preferably.
		/// </summary>
		public void Tick()
		{
			List<TrafficNicMeasure> measures = TrafficGrabber.GrabMeasures();
			TrafficStat.Add(measures);
			Repaint();
		}

		/// <summary>
		/// Updates the display without getting any new data. Call this when view needs
		/// to be redrawn.
		/// </summary>
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

		/// <summary>
		/// Toggle statistics display from a specific Network Interface. Network Interface
		/// name must be exact as returned by <see cref="TrafficGrabber.RefreshNics()"/>.
		/// Note that the monitoring itself is not disabled, just the display.
		/// </summary>
		public void SetNicEnabled(string nic, bool enabled)
		{
			TrafficStat.SetNicEnabled(nic, enabled);
		}

		/// <summary>
		/// Gets the "total amount" text for a given statistic type.
		/// The unit type of the text depends on the unit type used for graph painting.
		/// </summary>
		private string TotalText(Stat stat)
		{
			float[] totals = TrafficStat.Total(stat, TotalsAverageCount);
			if (totals.Length > 0)
			{
				bool bits = GraphPaint.Scale.InBits; // TODO bad programming practice, code smell.
				float average = totals.Average();
				if (bits)
					average *= 8.0f;
				var trafficValue = new TrafficUnitValue(average, bits);
				return TrafficUnit.Humanize(trafficValue) + "/s";
			}
			return "N/A";
		}
	}
}
