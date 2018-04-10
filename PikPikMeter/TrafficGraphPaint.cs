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
	class TrafficGraphPaint
	{
		public Pen DownloadPen = new Pen(Brushes.Green);
		public Pen UploadPen = new Pen(Brushes.Red);
		public Pen BothPen = new Pen(Brushes.Yellow);
		public Color ClearColor = Color.Black;
		public Font TextFont = SystemFonts.SmallCaptionFont;
		public Brush TextBrush = Brushes.White;

		private readonly Size ReasonableScaleTextSize = new Size(64, 32);
		private TrafficUnitValue _Scale = new TrafficUnitValue(1 * 1024.0f * 1024.0f, false);
		private string ScaleText;

		public TrafficGraphPaint()
		{
			// Effectively caches ScaleText.
			Scale = _Scale;
		}

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

		public void Paint(NotifyIcon icon, TrafficStat stat)
		{
			var iconSize = SystemInformation.SmallIconSize;
			Bitmap bitmap = new Bitmap(iconSize.Width, iconSize.Height);
			Paint(bitmap, stat);
			var hicon = bitmap.GetHicon();
			icon.Icon = Icon.FromHandle(hicon);
			DestroyIcon(hicon);
		}

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
				/// Totals are LIFO so the most recent measure will be first in the array.
				/// We want to draw it on the right side of the graph.
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
