using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikPikMeter
{
	/// <summary>
	/// Singular traffic measure for a specific Network Interface as reported by
	/// the Operating System and returned from <see cref="TrafficNic"/>.
	/// </summary>
	public struct TrafficNicMeasure
	{
		/// <summary>Name of the Network Interface.</summary>
		public string Nic;
		/// <summary>Download traffic.</summary>
		public float DownloadBytesPerSec;
		/// <summary>Upload traffic.</summary>
		public float UploadBytesPerSec;

		public TrafficNicMeasure(string nic, float dl, float ul)
		{
			this.Nic = nic;
			this.DownloadBytesPerSec = dl;
			this.UploadBytesPerSec = ul;
		}
	}
}
