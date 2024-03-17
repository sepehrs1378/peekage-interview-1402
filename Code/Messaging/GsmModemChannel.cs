public class GsmModemChannel: IMessenger
{
    public void sendMessage(string str)
    {
        Console.WriteLine("GsmModem: " + str);
    }
}