using WIM14.Commands.Contracts;

namespace WIM14.Core.Contracts
{
    public interface ICommandManager
    {
        ICommand ParseCommand(string commandLine);
    }
}
