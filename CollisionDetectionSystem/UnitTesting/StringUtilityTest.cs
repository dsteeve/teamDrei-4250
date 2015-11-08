using NUnit.Framework;
using System;
using CollisionDetectionSystem;

namespace UnitTesting
{	
	[TestFixture ()]
	public class StringUtilityTest
	{
		[Test ()]
		public void getArgSetNormal ()
		{
			String thevalue = StringUtility.getArgValue ("foo=bar");
			Assert.IsTrue("bar".Equals(thevalue));
		}
		[Test ()]
		public void getArgWithNoValue ()
		{
			String thevalue = StringUtility.getArgValue ("foo=");
			Assert.IsEmpty (thevalue);
		}
		[Test ()]
		public void getArgWithNoEqualSign ()
		{
			String thevalue = StringUtility.getArgValue ("foo");
			Assert.IsNull (thevalue);
		}
		[Test ()]
		public void getArgWithPlusSign()
		{
			String thevalue = StringUtility.getArgValue ("foo+");
			Assert.IsNull (thevalue);
		}
	}
}

