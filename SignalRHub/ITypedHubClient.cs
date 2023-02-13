namespace SignalRHub
{

    public interface ITypedHubClient
    {
        Task BroadcastMessage(string type, string payload);
    }
}
