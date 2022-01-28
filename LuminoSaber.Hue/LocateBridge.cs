using Rssdp;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Net.Http;

namespace LuminoSaber.Hue
{
    public class LocateBridge
    {
        public static string BridgeIP;

        public static string LocateBridgeIP()
        {
            SsdpDeviceLocator deviceLocator = new SsdpDeviceLocator(GetLocalIPAddress().ToString());
            var foundDevices = deviceLocator.SearchAsync().Result.ToList();

            foreach (var device in foundDevices)
            {
                if (device.ResponseHeaders.ToString().Contains("IpBridge"))
                {
                    return device.DescriptionLocation.Host;
                }
            }

            return null;
        }

        private static IPAddress GetLocalIPAddress()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                return null;

            return Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
        }
    }
}