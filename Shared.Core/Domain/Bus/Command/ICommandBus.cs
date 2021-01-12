namespace SPAR.Shared.Domain.Bus.Command
{
    public interface ICommandBus
    {
        public void Dispatch(ICommand oCommand);
    }
}