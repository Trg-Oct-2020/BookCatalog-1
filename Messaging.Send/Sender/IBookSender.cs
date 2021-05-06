namespace BookCatalog.MicroService.Messaging.Send.Sender
{
    public interface IBookSender
    {
        void SendMessagetoQueue(string message);
    }
}
