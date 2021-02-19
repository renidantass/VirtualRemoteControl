using Rssdp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tv_api.Entities;

namespace tv_api.Services
{
    class Discovery
    {
        public static async Task<DeviceDiscoveredResponse> FindWebOs()
        {
            using (SsdpDeviceLocator deviceLocator = new SsdpDeviceLocator())
            {
                IEnumerable<DiscoveredSsdpDevice> foundDevices = await deviceLocator.SearchAsync();
                foreach (DiscoveredSsdpDevice foundDevice in foundDevices)
                {
                    Uri description = foundDevice.DescriptionLocation;
                    string device = (await foundDevice.GetDeviceInfo()).FriendlyName;
                    if (device.ToLower().Contains("webos"))
                    {
                        return new DeviceDiscoveredResponse(true, description.Host);
                    }

                    return new DeviceDiscoveredResponse();
                }

                return new DeviceDiscoveredResponse();
            }
        }
    }
}
