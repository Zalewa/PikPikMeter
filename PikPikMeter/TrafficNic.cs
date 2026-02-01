using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikPikMeter
{
    /// <summary>
    /// Traffic measure grabber for a specific, singular Network Interface.
    /// It doesn't grab anything by itself, but rather keeps the references that
    /// can be indirectly used by external caller to grab measure at its whim.
    /// </summary>
    public class TrafficNic
    {
        private string _nic;
        private PerformanceCounter _dlCounter;
        private PerformanceCounter _ulCounter;

        public TrafficNic(string nic)
        {
            this._nic = nic;
            this._dlCounter = CreateCounter("Bytes Received/sec");
            this._ulCounter = CreateCounter("Bytes Sent/sec");
        }

        /// <summary>
        /// All Network Interface Controllers currently available in the system.
        /// </summary>
        public static string[] Nics
        {
            get
            {
                return new PerformanceCounterCategory("Network Interface").GetInstanceNames();
            }
        }

        /// <summary>
        /// Network Interface name exactly as returned by <see cref="TrafficGrabber.RefreshNics()"/>.
        /// </summary>
        public string Nic { get { return _nic; } }

        /// <summary>
        /// Grabs a single traffic measure at this instant from the Network Interface.
        /// </summary>
        public TrafficNicMeasure Measure()
        {
            try
            {
                return new TrafficNicMeasure(this._nic,
                    this._dlCounter.NextValue(),
                    this._ulCounter.NextValue());
            }
            catch (Exception e)
            {
                throw new TrafficMeasureException("cannot get measure for NIC " + _nic, e);
            }
        }

        private PerformanceCounter CreateCounter(string counter)
        {
            return new PerformanceCounter("Network Interface", counter, this._nic);
        }
    }
}
