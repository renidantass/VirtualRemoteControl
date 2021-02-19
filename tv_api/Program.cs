using System;
using System.Threading.Tasks;
using tv_api.Entities;
using tv_api.Services;

namespace tv_api
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DeviceDiscoveredResponse foundDevice = await Discovery.FindWebOs();
            LG tv = new LG(foundDevice);

            using (RemoteControl<LG> remoteControl = new RemoteControl<LG>(tv))
            {
                /*
                    ENDPOINTS IN
                        https://pastebin.com/raw/J5XMfbDq
                 */
                //Command command = new Command("system.notifications/createToast", "request", new { message = "Funcionou!" });
                Command command = new Command("request:audio/getStatus");

                dynamic response = remoteControl.SendCommand(command).Result;

                Console.WriteLine(response);
            }
        }
    }
}