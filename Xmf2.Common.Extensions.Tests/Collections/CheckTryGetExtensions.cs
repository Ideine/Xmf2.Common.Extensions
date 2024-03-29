﻿using System;
using Xmf2.Common.Collections;
using Xunit;

namespace Xmf2.Common.Tests.Collections
{
	public class CheckTryGetExtensions
	{
		[Fact]
		public static void TryGetMinWorks()
		{
			int[] sourceA = { 1, 2, 3, 4 };
			int[] sourceEmpty = Array.Empty<int>();
			int[] sourceB = { 4, 3, 2, 1 };
			int[] sourceC = { 2, 2, 5, 5 };
			int[] sourceD = { 6 };
			bool found;

			found = sourceA.TryGetMin(selector: x => x, out int value);
			Assert.Equal((true, 1), (found, value));

			found = sourceEmpty.TryGetMin(selector: x => x, out value);
			Assert.Equal((false, default(int)), (found, value));

			found = sourceB.TryGetMin(selector: x => x, out value);
			Assert.Equal((true, 1), (found, value));

			found = sourceC.TryGetMin(selector: x => x, out value);
			Assert.Equal((true, 2), (found, value));

			found = sourceD.TryGetMin(selector: x => x, out value);
			Assert.Equal((true, 6), (found, value));
		}

		[Fact]
		public static void TryGetMaxWorks()
		{
			int[] sourceA = { 1, 2, 3, 4 };
			int[] sourceEmpty = Array.Empty<int>();
			int[] sourceB = { 4, 3, 2, 1 };
			int[] sourceC = { 2, 2, 5, 5 };
			int[] sourceD = { 6 };
			bool found;

			found = sourceA.TryGetMax(selector: x => x, out int value);
			Assert.Equal((true, 4), (found, value));

			found = sourceEmpty.TryGetMax(selector: x => x, out value);
			Assert.Equal((false, default(int)), (found, value));

			found = sourceB.TryGetMax(selector: x => x, out value);
			Assert.Equal((true, 4), (found, value));

			found = sourceC.TryGetMax(selector: x => x, out value);
			Assert.Equal((true, 5), (found, value));

			found = sourceD.TryGetMax(selector: x => x, out value);
			Assert.Equal((true, 6), (found, value));
		}
	}
}
