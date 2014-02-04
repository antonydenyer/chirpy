namespace Chirpy.App.CommandHandlers
{
    internal interface ICommandHandler
    {
        void Handle(string message);
    }
}