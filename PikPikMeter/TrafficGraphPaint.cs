using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PikPikMeter
{
	/// <summary>
	/// Draws traffic graph on a PictureBox, a NotifyIcon or just on a plain Bitmap.
	/// <para>
	/// Graph includes:
	/// - 1-pixel width bars for download, upload and common traffic.
	/// - Scale printed as text.
	/// - Background color.
	/// </para>
	/// </summary>
	class TrafficGraphPaint
	{
		/// <summary>Pen with which the download traffic bars are painted.</summary>
		public Pen DownloadPen = new Pen(Brushes.Green);
		/// <summary>Pen with which the upload traffic bars are painted.</summary>
		public Pen UploadPen = new Pen(Brushes.Red);
		/// <summary>Pen with which bars for overlapping traffic are painted.</summary>
		public Pen BothPen = new Pen(Brushes.Yellow);
		/// <summary>Background color, basically.</summary>
		public Color ClearColor = Color.Black;
		/// <summary>Font with which the graph scale text is printed.</summary>
		public Font TextFont = SystemFonts.SmallCaptionFont;
		/// <summary>Color of the graph scale text.</summary>
		public Brush TextBrush = Brushes.White;

		private readonly Size ReasonableScaleTextSize = new Size(64, 32);
		private TrafficUnitValue _Scale = new TrafficUnitValue(1 * 1024.0f * 1024.0f, false);
		private string ScaleText;

		public TrafficGraphPaint()
		{
			// Effectively caches ScaleText.
			Scale = _Scale;
		}

		/// <summary>
		/// Scale as <see cref="TrafficUnitValue"/> for the graph. This honors
		/// the bits/Bytes selection. The value of the scale denotes the highest
		/// traffic value that can be painted on the graph. If actual traffic
		/// exceeds the scale, it's simply painted as a full-height bar.
		/// </summary>
		public TrafficUnitValue Scale
		{
			set
			{
				this._Scale = value;
				ScaleText = TrafficUnit.Humanize(value) + "/s";
			}
			get
			{
				return this._Scale;
			}
		}

		/// <summary>
		/// Paints <see cref="TrafficStat"/> on a PictureBox. The size of the graph
		/// matches the size of the PictureBox.
		/// </summary>
		public void Paint(PictureBox graph, TrafficStat stat)
		{
			if (graph.Width <= 0 || graph.Height <= 0)
				// Always be resilient to strange states.
				// We don't want the repeat of FreeMeter, do we?
				return;
			Bitmap bitmap = new Bitmap(graph.Width, graph.Height);
			Paint(bitmap, stat);
			graph.Image = bitmap;
		}

		[System.Runtime.InteropServices.DllImport("user32.dll", CharSet = CharSet.Auto)]
		extern static bool DestroyIcon(IntPtr handle);

		/// <summary>
		/// Paints <see cref="TrafficStat"/> on a NotifyIcon. It needs native Windows
		/// function to destroy the icon. The size of the graph matches small icon size
		/// as provided by .NET runtime.
		/// </summary>
		public void Paint(NotifyIcon icon, TrafficStat stat)
		{
			var iconSize = SystemInformation.SmallIconSize;
			Bitmap bitmap = new Bitmap(iconSize.Width, iconSize.Height);
			Paint(bitmap, stat);
			var hicon = bitmap.GetHicon();
			icon.Icon = Icon.FromHandle(hicon);
			DestroyIcon(hicon);
		}

		/// <summary>
		/// Paints <see cref="TrafficStat"/> on an arbitrary Bitmap.
		/// </summary>
		public void Paint(Bitmap bitmap, TrafficStat stat)
		{
			Graphics graphics = Graphics.FromImage(bitmap);
			try
			{
				graphics.Clear(ClearColor);

				int amount = bitmap.Width;
				float[] downloadTotals = stat.Total(Stat.Download, amount);
				float[] uploadTotals = stat.Total(Stat.Upload, amount);

				// It's a buggy state if this happens.
				if (downloadTotals.Length != uploadTotals.Length)
					throw new TrafficMeasureException("uneven upload/download totals");

				// However, it's perfectly fine to get lesser amount of totals than requested.
				int realAmount = downloadTotals.Length;
				// Totals length may be shorter than the graph width, but we still want
				// the graph bars to stick to the right edge.
				for (int idx = 0, drawPos = bitmap.Width - realAmount; idx < realAmount; ++idx, ++drawPos)
				{
					float download = downloadTotals[idx];
					float upload = uploadTotals[idx];

					float biggerTotal;
					Pen biggerPen;
					float lowerTotal;

					if (download > upload)
					{
						biggerTotal = download;
						lowerTotal = upload;
						biggerPen = DownloadPen;
					}
					else
					{
						biggerTotal = upload;
						lowerTotal = download;
						biggerPen = UploadPen;
					}

					// We're drawing from bottom up, so from graph.Height to 0.
					graphics.DrawLine(biggerPen,
						drawPos, bitmap.Height,
						drawPos, GetDrawY1(biggerTotal, bitmap.Height));
					// This bar will always be smaller.
					graphics.DrawLine(BothPen,
						drawPos, bitmap.Height,
						drawPos, GetDrawY1(lowerTotal, bitmap.Height));
					// Draw scale text.
				}
				if (CanPaintScale(bitmap))
					graphics.DrawString(ScaleText, TextFont, TextBrush, 1, 1);
			}
			finally
			{
				graphics.Dispose();
			}
		}

		private int GetDrawY1(float total, int height)
		{
			int barHeight = GetBarHeight(total, height);
			return height - barHeight;
		}

		private int GetBarHeight(float total, int height)
		{
			double ratio = (double)(total) / Scale.Bytes;
			if (ratio >= 1.0)
				return height;
			else if (ratio <= 0.0)
				return 0;
			else
				return (int)Math.Ceiling(ratio * height);
		}

		private bool CanPaintScale(Bitmap bitmap)
		{
			return bitmap.Width >= ReasonableScaleTextSize.Width
				&& bitmap.Height >= ReasonableScaleTextSize.Height;
		}
	}
}
