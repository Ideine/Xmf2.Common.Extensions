namespace Xmf2.Common.Extensions
{
	public static class NumberExtensions
	{
		/// <summary>
		/// Method return the value if it is between min & max, otherwise it return min or max
		/// </summary>
		public static float Clamp(this float value, float min, float max)
		{
			return value < min ? min : value > max ? max : value;
		}

		/// <summary>
		/// Method return the value if it is between min & max, otherwise it return min or max
		/// </summary>
		public static double Clamp(this double value, double min, double max)
		{
			return value < min ? min : value > max ? max : value;
		}

		/// <summary>
		/// Method return the value if it is between min & max, otherwise it return min or max
		/// </summary>
		public static int Clamp(this int value, int min, int max)
		{
			return value < min ? min : value > max ? max : value;
		}

		/// <summary>
		/// Method return the value if it is between min & max, otherwise it return min or max
		/// </summary>
		public static decimal Clamp(this decimal value, decimal min, decimal max)
		{
			return value < min ? min : value > max ? max : value;
		}
	}
}