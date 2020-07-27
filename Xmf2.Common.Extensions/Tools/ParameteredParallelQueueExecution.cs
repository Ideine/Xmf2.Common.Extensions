using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Xmf2.Common.Tools
{
	public class ParameteredParallelQueueExecution<TParameter, TResult>
	{
		private readonly ConcurrentDictionary<TParameter, BackgroundQueueWorker<WorkerItem>> _handlers = new ConcurrentDictionary<TParameter, BackgroundQueueWorker<WorkerItem>>();

		public Task<TResult> Execute(TParameter parameter, Func<TResult> executor) => Execute(parameter, () => Task.Run(executor));

		public Task<TResult> Execute(TParameter parameter, Func<Task<TResult>> executor)
		{
			BackgroundQueueWorker<WorkerItem> queue = _handlers.GetOrAdd(parameter, _ => new BackgroundQueueWorker<WorkerItem>(ProcessItem));

			var item = new WorkerItem(executor);
			queue.Queue(item);
			return item.CompletionSource.Task;
		}

		private static async Task ProcessItem(WorkerItem item)
		{
			try
			{
				TResult result = await item.Executor();
				item.CompletionSource.TrySetResult(result);
			}
			catch (TaskCanceledException ex)
			{
				item.CompletionSource.TrySetCanceled(ex.CancellationToken);
			}
			catch (Exception ex)
			{
				item.CompletionSource.TrySetException(ex);
			}
		}

		#region Nested class

		private class WorkerItem
		{
			public WorkerItem(Func<Task<TResult>> executor)
			{
				Executor = executor;
				CompletionSource = new TaskCompletionSource<TResult>();
			}

			public Func<Task<TResult>> Executor { get; }
			public TaskCompletionSource<TResult> CompletionSource { get; }
		}

		#endregion
	}
}