using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter
{
	public class Utilities
	{
		public static Color GetColor()
		{
			ColorDialog dlgColor = new ColorDialog();
			if (dlgColor.ShowDialog() == DialogResult.OK)
			{
				return dlgColor.Color;
			}
			return Color.Black;
		}

		public static void SaveFile(string str)
		{
			StreamWriter fileStream = null;
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				using (fileStream = new StreamWriter(saveFileDialog.FileName))
				{
					fileStream.Write(str);
				}
			}
		}

		public static string LoadFile()
		{
			string res = "";
			StreamReader fileStream = null;
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				{
					using (fileStream = new StreamReader(openFileDialog.FileName))
					{
						res = fileStream.ReadToEnd();
					}
				}
			}
			return res;
		}
	}
}
