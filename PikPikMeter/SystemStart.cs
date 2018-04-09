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
	class SystemStart
	{
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
