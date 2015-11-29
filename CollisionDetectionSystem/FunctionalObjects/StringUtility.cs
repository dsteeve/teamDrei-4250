using System;

namespace CollisionDetectionSystem
{
	public static class StringUtility
	{
		
		/**
		 * split out the name=value
		 * return the value
		 */

		public static String getArgValue(String namevaluepair) {
			String[] values = namevaluepair.Split ('=');
			if (values.Length == 2) {
				return values [1];
			} else {
				return null;
			}
		}
	}
}

