using Painter.Views;

namespace Painter.Controllers
{
	public class XCommand
	{
		private PDraw _activePDraw = null;
		public PDraw ActivePDraw { set => _activePDraw = value; }

		int dCalls = 0;
		public void Debug()
		{
			System.Diagnostics.Debug.WriteLine("debug" + dCalls++);
			if (dCalls % 2 == 1)
				Localization.Locale = "ru";
			else
				Localization.Locale = "en";
		}
	}
}
