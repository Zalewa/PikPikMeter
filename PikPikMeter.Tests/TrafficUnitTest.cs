namespace PikPikMeter.Tests
{
    [TestClass]
    public sealed class TrafficUnitTest
    {
        [TestMethod]
        public void Humanize_Bytes()
        {
            const bool bytes = false;
            Assert.AreEqual(FormatTU(1, "B"), TrafficUnit.Humanize(new TrafficUnitValue(1, bytes)));
            Assert.AreEqual(FormatTU(512, "B"), TrafficUnit.Humanize(new TrafficUnitValue(512, bytes)));
            Assert.AreEqual(FormatTU(1, "KB"), TrafficUnit.Humanize(new TrafficUnitValue(1024, bytes)));
            Assert.AreEqual(FormatTU(1.5f, "KB"), TrafficUnit.Humanize(new TrafficUnitValue(1024 + 512, bytes)));
            Assert.AreEqual(FormatTU(1, "MB"), TrafficUnit.Humanize(new TrafficUnitValue(1024 * 1024, bytes)));
            Assert.AreEqual(FormatTU(999, "MB"), TrafficUnit.Humanize(new TrafficUnitValue(999 * 1024 * 1024, bytes)));
            Assert.AreEqual(FormatTU(1, "GB"), TrafficUnit.Humanize(new TrafficUnitValue(1024 * 1024 * 1024, bytes)));
            // Humanization goes up to GB tops.
            Assert.AreEqual(FormatTU(1024, "GB"), TrafficUnit.Humanize(new TrafficUnitValue(1024 * 1024 * 1024 * 1024L, bytes)));
        }

        [TestMethod]
        public void Humanize_Bits()
        {
            const bool bits = true;
            Assert.AreEqual(FormatTU(1, "b"), TrafficUnit.Humanize(new TrafficUnitValue(1, bits)));
            Assert.AreEqual(FormatTU(512, "b"), TrafficUnit.Humanize(new TrafficUnitValue(512, bits)));
            Assert.AreEqual(FormatTU(1, "Kb"), TrafficUnit.Humanize(new TrafficUnitValue(1024, bits)));
            Assert.AreEqual(FormatTU(1.5f, "Kb"), TrafficUnit.Humanize(new TrafficUnitValue(1024 + 512, bits)));
            Assert.AreEqual(FormatTU(1, "Mb"), TrafficUnit.Humanize(new TrafficUnitValue(1024 * 1024, bits)));
            Assert.AreEqual(FormatTU(999, "Mb"), TrafficUnit.Humanize(new TrafficUnitValue(999 * 1024 * 1024, bits)));
            Assert.AreEqual(FormatTU(1, "Gb"), TrafficUnit.Humanize(new TrafficUnitValue(1024 * 1024 * 1024, bits)));
            // Humanization goes up to Gb tops.
            Assert.AreEqual(FormatTU(1024, "Gb"), TrafficUnit.Humanize(new TrafficUnitValue(1024 * 1024 * 1024 * 1024L, bits)));
        }

        [TestMethod]
        public void Parse_Bytes()
        {
            const bool bytes = false;
            Assert.AreEqual(new TrafficUnitValue(1, bytes), TrafficUnit.Parse("1B"));
            Assert.AreEqual(new TrafficUnitValue(1024, bytes), TrafficUnit.Parse("1024B"));
            Assert.AreEqual(new TrafficUnitValue(1024, bytes), TrafficUnit.Parse("1KB"));
            Assert.AreEqual(new TrafficUnitValue(1024, bytes), TrafficUnit.Parse("1kB"));
            Assert.AreEqual(new TrafficUnitValue(1024, bytes), TrafficUnit.Parse("1KiB"));
            Assert.AreEqual(new TrafficUnitValue(1024, bytes), TrafficUnit.Parse("1kiB"));
            Assert.AreEqual(new TrafficUnitValue(1024 * 1024, bytes), TrafficUnit.Parse("1MB"));
            Assert.AreEqual(new TrafficUnitValue(1024 * 1024, bytes), TrafficUnit.Parse("1mB"));
            Assert.AreEqual(new TrafficUnitValue(1024 * 1024, bytes), TrafficUnit.Parse("1MiB"));
            Assert.AreEqual(new TrafficUnitValue(1024 * 1024, bytes), TrafficUnit.Parse("1miB"));
            Assert.AreEqual(new TrafficUnitValue(1024 * 1024 * 1024, bytes), TrafficUnit.Parse("1GB"));
            Assert.AreEqual(new TrafficUnitValue(1024 * 1024 * 1024, bytes), TrafficUnit.Parse("1gB"));
            Assert.AreEqual(new TrafficUnitValue(1024 * 1024 * 1024, bytes), TrafficUnit.Parse("1GiB"));
            Assert.AreEqual(new TrafficUnitValue(1024 * 1024 * 1024, bytes), TrafficUnit.Parse("1giB"));
            // Higher units not supported.
        }

        [TestMethod]
        public void Parse_Bits()
        {
            const bool bits = true;
            Assert.AreEqual(new TrafficUnitValue(1, bits), TrafficUnit.Parse("1b"));
            Assert.AreEqual(new TrafficUnitValue(1024, bits), TrafficUnit.Parse("1024b"));
            Assert.AreEqual(new TrafficUnitValue(1024, bits), TrafficUnit.Parse("1Kb"));
            Assert.AreEqual(new TrafficUnitValue(1024, bits), TrafficUnit.Parse("1kb"));
            Assert.AreEqual(new TrafficUnitValue(1024, bits), TrafficUnit.Parse("1Kib"));
            Assert.AreEqual(new TrafficUnitValue(1024, bits), TrafficUnit.Parse("1kib"));
            Assert.AreEqual(new TrafficUnitValue(1024 * 1024, bits), TrafficUnit.Parse("1Mb"));
            Assert.AreEqual(new TrafficUnitValue(1024 * 1024, bits), TrafficUnit.Parse("1mb"));
            Assert.AreEqual(new TrafficUnitValue(1024 * 1024, bits), TrafficUnit.Parse("1Mib"));
            Assert.AreEqual(new TrafficUnitValue(1024 * 1024, bits), TrafficUnit.Parse("1mib"));
            Assert.AreEqual(new TrafficUnitValue(1024 * 1024 * 1024, bits), TrafficUnit.Parse("1Gb"));
            Assert.AreEqual(new TrafficUnitValue(1024 * 1024 * 1024, bits), TrafficUnit.Parse("1gb"));
            Assert.AreEqual(new TrafficUnitValue(1024 * 1024 * 1024, bits), TrafficUnit.Parse("1Gib"));
            Assert.AreEqual(new TrafficUnitValue(1024 * 1024 * 1024, bits), TrafficUnit.Parse("1gib"));
            // Higher units not supported.
        }

        /// <summary>
        /// Test parsing tricky values.
        /// </summary>
        [TestMethod]
        public void Parse_Tricky()
        {
            const bool bytes = false;
            // No unit should parse as bytes.
            Assert.AreEqual(new TrafficUnitValue(0, bytes), TrafficUnit.Parse("0"));
            Assert.AreEqual(new TrafficUnitValue(1, bytes), TrafficUnit.Parse("1"));
            Assert.AreEqual(new TrafficUnitValue(1048576, bytes), TrafficUnit.Parse("1048576"));
            // Value other than 1.
            Assert.AreEqual(new TrafficUnitValue(500 * 1024 * 1024, bytes), TrafficUnit.Parse("500 MB"));
            // Float delimiter must come from the current culture (locale).
            Assert.AreEqual(new TrafficUnitValue(512 * 1024, bytes), TrafficUnit.Parse(FormatFloat(0.5f) + " MB"));
            // Fractional part after a non-zero, non-one integer.
            Assert.AreEqual(
                new TrafficUnitValue(500 * 1024 * 1024 + 1024 * 1024 / 2, bytes),
                TrafficUnit.Parse(FormatFloat(500.5f) + " MB"));
            // Whitespace padding
            Assert.AreEqual(new TrafficUnitValue(511 * 1024, bytes), TrafficUnit.Parse("  511  kB  "));
            // Odd whitespace padding.
            Assert.AreEqual(new TrafficUnitValue(511 * 1024, bytes), TrafficUnit.Parse("   511   kB   "));
        }

        /// <summary>
        /// Format TrafficUnit in accordance to the current locale.
        /// </summary>
        private static string FormatTU(float value, string unit)
        {
            return FormatFloat(value) + " " + unit;
        }

        /// <summary>
        /// Format float in accordance to the current locale.
        /// </summary>
        private static string FormatFloat(float f)
        {
            return String.Format("{0:0.0}", f);
        }
    }
}
