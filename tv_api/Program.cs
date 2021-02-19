using System;
using tv_api.Entities;
using tv_api.Services;

namespace tv_api
{
    class Program
    {
        static void Main(string[] args)
        {
            LG tv = new LG("192.168.1.100", 3000);

            using(RemoteControl<LG> remoteControl = new RemoteControl<LG>(tv))
            {
                Command command = new Command("api/getServiceList");
                dynamic response = remoteControl.SendCommand(command).Result;

                Console.WriteLine(response);
            }
        }
    }
}
