using System;
using NUnit.Framework;
using Painter.Controllers;
using System.Drawing;

namespace UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
		XCommand xCommand;

		[SetUp]
		public void SetUp()
		{
			xCommand = new XCommand();
			xCommand.ActivePDraw = new Painter.Views.PDraw(xCommand);
		}

        [Test]
        public void TestSetLineWidth()
        {
			xCommand.SetLineWidth(5);
			Assert.AreEqual(5, xCommand.ActivePDraw._xData.lineWidth);
        }

		[Test]
		public void TestSetColor()
		{
			xCommand.SetColor(Color.Red);
			Assert.AreEqual(Color.Red, xCommand.ActivePDraw._xData.color);
		}

		[Test]
		public void TestSetType()
		{
			xCommand.SetType(Painter.Models.XData.FigureType.Ellipse);
			Assert.AreEqual(Painter.Models.XData.FigureType.Ellipse, xCommand.ActivePDraw._xData.type);
		}
	}
}
