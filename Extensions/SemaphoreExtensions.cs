using System;
using System.Threading;
using System.Threading.Tasks;

namespace Xmf2.Common.Extensions
{
	public static class SemaphoreExtensions
	{
		public static async Task<IDisposable> LockAsync(this SemaphoreSlim semaphore)
		{
			await semaphore.WaitAsync();
			return new LockDisposable(semaphore);
		}

		private class LockDisposable : IDisposable
		{
			private SemaphoreSlim _semaphore;

			public LockDisposable(SemaphoreSlim semaphore)
			{
				_semaphore = semaphore;
			}

			public void Dispose()
			{
				_semaphore?.Release();
				_semaphore = null;
			}
		}
	}
}