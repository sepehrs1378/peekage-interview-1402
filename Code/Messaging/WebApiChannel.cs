public class WebApiChannel: IMessenger
{
    public void sendMessage(string str)
    {
        Console.WriteLine("WebApi: " + str);
    }
}