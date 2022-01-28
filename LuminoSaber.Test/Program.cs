using System;
using LuminoSaber.Hue;

namespace LuminoSaber.Test
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string BridgeIP = LocateBridge.LocateBridgeIP();
            Console.WriteLine($"Hue Bridge IP: {BridgeIP}");

            Console.WriteLine("Enter your username: ");
            string username = Console.ReadLine();
            CreateUser.ConnectBridge(username, BridgeIP);
            string usercode = CreateUser.Usercode;
            Console.WriteLine($"Usercode: {usercode}");
        }
    }
}
