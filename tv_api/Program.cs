using System;
using tv_api.Entities;
using tv_api.Services;

namespace tv_api
{
    class Program
    {
        static void Main(string[] args)
        {
            Discovery discovery = new Discovery();
            DeviceDiscoveredResponse foundDevice = discovery.FindWebOs();
            LG tv = new LG(foundDevice);

            using (RemoteControl<LG> remoteControl = new RemoteControl<LG>(tv))
            {
                Command command = new Command("api/getServiceList");
                dynamic response = remoteControl.SendCommand(command).Result;

                Console.WriteLine(response);
            }
        }
    }
}
