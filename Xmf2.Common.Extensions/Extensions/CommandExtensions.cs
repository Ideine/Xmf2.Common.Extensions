using System.Windows.Input;

namespace Xmf2.Common.Extensions
{
	public static class CommandExtensions
	{
		public static void TryExecute(this ICommand command, object parameter = null)
		{
			if (command != null && command.CanExecute(parameter))
			{
				command.Execute(parameter);
			}
		}
	}
}