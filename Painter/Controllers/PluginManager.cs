using Painter.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Painter.Controllers
{
	public class PluginManager
	{
		public static List<Type> pluginTypes = null;

		public static List<Type> Load()
		{
			Assembly assembly = Assembly.LoadFrom("../../../FigureWithText/bin/Debug/FigureWithText.dll");

			return assembly.GetTypes()
				.Where(x => x.GetInterface(typeof(IPlugin).Name) != null)
				.ToList();
		}

		public static void ListPlugins()
		{
			pluginTypes = Load();
			List<IPlugin> plugins = new List<IPlugin>();
			foreach (Type pluginType in pluginTypes)
			{
				IPlugin plugin = Activator.CreateInstance(pluginType) as IPlugin;
				plugins.Add(plugin);
			}

			Debug.WriteLine("Available Plugins:");
			plugins.ForEach(t => Debug.WriteLine(t.Name));
		}
	}
}
