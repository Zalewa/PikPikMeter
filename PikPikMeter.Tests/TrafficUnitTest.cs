using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikPikMeter.Tests
{
    [TestClass]
    public sealed class TrafficUnitTest
    {
        [TestMethod]
        public void Humanize_Bytes()
        {
            Assert.AreEqual("1B", TrafficUnit.Humanize(new TrafficUnitValue(1, false)));
        }
    }
}
