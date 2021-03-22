using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using tv_api.Entities;
using tv_api.Services;

namespace tv_api
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IPHostEntry iPHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ip = iPHostEntry.AddressList.FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
            DeviceDiscoveredResponse foundDevice = await Discovery.FindWebOs();
            LG tv = new LG(foundDevice);

            using (RemoteControl<LG> remoteControl = new RemoteControl<LG>(tv))
            {
                /*
                    ENDPOINTS IN
                        https://pastebin.com/raw/J5XMfbDq
                 */
                CommandLG command = new CommandLG("system.notifications/createToast", "request", new { message = $"{ip} conectado a essa tela!" });
                //CommandLG command = new CommandLG("audio/getStatus");

                dynamic response = await remoteControl.SendCommand(command);

                Console.WriteLine(response);
            }
        }
    }
}