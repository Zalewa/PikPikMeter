using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PikPikMeter
{
	/// <summary>Controls application start with the Operating System.</summary>
	class SystemStart
	{
		/// <summary>
		/// Toggles application start with the Operating System by adding a necessary
		/// registry entry into "CurrentVersion/Run" registry key. On 'get', tries
		/// to see if this entry exists in the registry and is valid and returns true
		/// if the autostart conditions are met.
		/// </summary>
		public static bool On
		{
			get
			{
				try
				{
					using (RegistryKey registryKey = OpenKey(false))
					{
						return registryKey.GetValue(Name).ToString() == ExePath;
					}
				}
				catch (Exception)
				{
					return false;
				}
			}
			set
			{
				using (RegistryKey registryKey = OpenKey(true))
				{
					if (value)
						registryKey.SetValue(Name, ExePath);
					else
						registryKey.DeleteValue(Name, false);
				}
			}
		}

		private static string Name
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Name;
			}
		}

		private static string ExePath
		{
			get
			{
				return string.Format("\"{0}\"", Application.ExecutablePath);
			}
		}

		private static RegistryKey OpenKey(bool writable)
		{
			return Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", writable);
		}

	}
}
