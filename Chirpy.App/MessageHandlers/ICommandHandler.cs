namespace Chirpy.App.MessageHandlers
{
    internal interface ICommandHandler
    {
        void Handle(string message);
    }
}