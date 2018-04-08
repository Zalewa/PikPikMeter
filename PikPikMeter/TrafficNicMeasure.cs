using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikPikMeter
{
	public struct TrafficNicMeasure
	{
		public string Nic;
		public float DownloadBytesPerSec;
		public float UploadBytesPerSec;

		public TrafficNicMeasure(string nic, float dl, float ul)
		{
			this.Nic = nic;
			this.DownloadBytesPerSec = dl;
			this.UploadBytesPerSec = ul;
		}
	}
}
