using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikPikMeter
{
	public struct TrafficUnitValue
	{
		public float Value;
		public bool InBits;

		public TrafficUnitValue(float value, bool inBits)
		{
			this.Value = value;
			this.InBits = inBits;
		}

		public float Bytes
		{
			get
			{
				return InBits ? Value * 8 : Value;
			}
		}
	}

	class TrafficUnit
	{
		// kibi, mibi, gibi, etc.
		private static readonly float Ki = 1024.0f;
		private static readonly float Mi = 1024.0f * Ki;
		private static readonly float Gi = 1024.0f * Mi;

		/**
		 * <summary>
		 * Parse text such as "20 mb" to TrafficUnitValue struct.
		 * </summary>
		 */
		public static TrafficUnitValue Dehumanize(string text)
		{
			text = text.Trim();
			while (text.Contains("  "))
				text = text.Replace("  ", " ");
			string[] tokens = text.Split(' ');
			if (tokens.Length > 2 || tokens.Length < 0)
				throw new ArgumentException("invalid format");
			float sizeFactor = 1.0f;
			bool bits = false;
			if (tokens.Length == 2 && !String.IsNullOrWhiteSpace(tokens[1]))
			{
				string unitToken = tokens[1];
				if (unitToken.Length > 3)
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
				value = float.Parse(tokens[0]);
			}
			catch (Exception e)
			{
				throw new ArgumentException("bad float value: " + e.Message, e);
			}
			return new TrafficUnitValue(value * sizeFactor, bits);
		}

		/**
		 * <summary>
		 * Convert total amount of bytes to a human-readable string.
		 * The output format is controlled through properties of this class.
		 * </summary>
		 */
		public static string Humanize(TrafficUnitValue trafficValue)
		{
			float total = trafficValue.Value;
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
	}
}
