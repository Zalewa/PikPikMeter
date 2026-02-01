using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikPikMeter
{
    /// <summary>
    /// Conveys a traffic (or size) amount with information if that amount
    /// is provided in bits or Bytes.
    /// </summary>
    public struct TrafficUnitValue
    {
        /// <summary>
        /// Size amount.
        /// </summary>
        public double Value;
        /// <summary>
        /// Bits flag. If true, Value is in bits. If false, Value is in Bytes.
        /// </summary>
        public bool InBits;

        public TrafficUnitValue(double value, bool inBits)
        {
            this.Value = value;
            this.InBits = inBits;
        }

        /// <summary>
        /// Provides the size amount in Bytes, regardless if the raw Value is in bits.
        /// </summary>
        public double Bytes
        {
            get
            {
                return InBits ? Value / 8.0 : Value;
            }
        }

        public override string ToString()
        {
            return String.Format(
                "TrafficUnitValue(Value={0}, InBits={1})",
                Value, InBits);
        }
    }

    /// <summary>
    /// Conversion mechanisms between human-readable traffic/size amounts and
    /// program-convenient  <see cref="TrafficUnitValue"/>.
    /// </summary>
    public class TrafficUnit
    {
        // kibi, mibi, gibi, etc.
        private static readonly float Ki = 1024.0f;
        private static readonly float Mi = 1024.0f * Ki;
        private static readonly float Gi = 1024.0f * Mi;

        private static readonly string[] ValidUnits =
        {
            "gb", "mb", "kb", "b", "gib", "mib", "kib",
        };

        /// <summary>
        /// Parse text such as "20 mb" to TrafficUnitValue struct.
        /// <para>
        /// Parsing is case-insensitive for size scaling (so: g, m, b),
        /// and case-sensitive for size type (so: B, b).
        /// The 'i' suffix to size scale is optional and doesn't change
        /// the output of the function.
        /// Numerical values are parsed as floats using current locale.
        /// </para>
        /// </summary>
        public static TrafficUnitValue Parse(string text)
        {
            string[] tokens = TokenizeText(text);
            if (tokens.Length > 2 || tokens.Length < 0)
                throw new ArgumentException("invalid format");
            if (tokens.Length == 0)
                throw new ArgumentException("no value");
            float sizeFactor = 1.0f;
            bool bits = false;
            if (tokens.Length == 2 && !String.IsNullOrWhiteSpace(tokens[1]))
            {
                string unitToken = tokens[1];

                if (!ValidUnits.Contains(unitToken.ToLower()))
                    throw new ArgumentException("unknown unit, try: GB, Gb, GiB, kiB, etc.");
                // Be lenient with capitalization of size factor.
                string sizeFactorToken = unitToken.ToLower();
                if (sizeFactorToken.StartsWith("g"))
                    sizeFactor = Gi;
                else if (sizeFactorToken.StartsWith("m"))
                    sizeFactor = Mi;
                else if (sizeFactorToken.StartsWith("k"))
                    sizeFactor = Ki;
                else if (sizeFactorToken.StartsWith("b"))
                    sizeFactor = 1.0f; // same as none
                else
                    throw new ArgumentException("unknown unit factor, try: G, M, K, B");
                // For this check, capitalization is important. b != B.
                if (unitToken.EndsWith("b"))
                    bits = true;
            }
            float value;
            try
            {
                value = ParseFloat(tokens[0]);
            }
            catch (Exception e)
            {
                throw new ArgumentException("bad float value: " + e.Message, e);
            }
            return new TrafficUnitValue(value * sizeFactor, bits);
        }

        /// <summary>
        /// Convert total amount of bytes to a human-readable string.
        /// The output format is controlled through properties of the input
        /// <see cref="TrafficUnitValue"/>. Scale is decided basing
        /// on the size amount, however unit type (bits or Bytes) is taken
        /// directly from the input param.
        /// </summary>
        /// <returns>
        /// Human-readable traffic scale in example format "12.34 Mb".
        /// </returns>
        public static string Humanize(TrafficUnitValue trafficValue)
        {
            double total = trafficValue.Value;
            string transferUnit = trafficValue.InBits ? "b" : "B";
            string sizeFactorName = "";
            float sizeFactor = 1.0f;

            if (total >= Gi)
            {
                sizeFactor = Gi;
                sizeFactorName = "G";
            }
            else if (total >= Mi)
            {
                sizeFactor = Mi;
                sizeFactorName = "M";
            }
            else if (total >= Ki)
            {
                sizeFactor = Ki;
                sizeFactorName = "K";
            }

            return String.Format("{0:0.0} {1}{2}", total / sizeFactor,
                sizeFactorName, transferUnit);
        }

        private static string[] TokenizeText(string text)
        {
            text = text.Trim();
            while (text.Contains("  "))
                text = text.Replace("  ", " ");

            int numberIdx;
            for (numberIdx = 0; numberIdx < text.Length; ++numberIdx)
            {
                if (text[numberIdx] == ' ')
                    break;
                if (text[numberIdx] == '-' && numberIdx == 0)
                    continue;
                string numberCandidate = text.Substring(0, numberIdx + 1);
                try
                {
                    ParseFloat(numberCandidate);
                }
                catch (Exception)
                {
                    break;
                }
            }
            --numberIdx;
            if (numberIdx < 0)
                return new string[0];
            string numberToken = text.Substring(0, numberIdx + 1);

            var tokens = new List<string>();
            tokens.Add(numberToken);

            text = text.Substring(numberIdx + 1).Trim();
            if (text.Length > 0)
                tokens.Add(text);

            return tokens.ToArray();
        }

        private static float ParseFloat(string text)
        {
            return float.Parse(text);
        }
    }
}
