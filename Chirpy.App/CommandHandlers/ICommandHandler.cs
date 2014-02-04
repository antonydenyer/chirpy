namespace Chirpy.App.CommandHandlers
{
    public interface ICommandHandler
    {
        void Handle(string message);
    }
}