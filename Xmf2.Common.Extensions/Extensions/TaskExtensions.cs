using System.Threading.Tasks;

namespace Xmf2.Common.Extensions
{
	public static class TaskExtensions
	{
		public static Task<T> AsTask<T>(this T result)
		{
			return Task.FromResult<T>(result);
		}
	}
}