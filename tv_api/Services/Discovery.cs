using Rssdp;
using System;
using System.Collections.Generic;
using tv_api.Entities;

namespace tv_api.Services
{
    class Discovery
    {
        public DeviceDiscoveredResponse FindWebOs()
        {
            using (SsdpDeviceLocator deviceLocator = new SsdpDeviceLocator())
            {
                IEnumerable<DiscoveredSsdpDevice> foundDevices = deviceLocator.SearchAsync().Result;
                foreach (DiscoveredSsdpDevice foundDevice in foundDevices)
                {
                    Uri description = foundDevice.DescriptionLocation;
                    string deviceName = (foundDevice.GetDeviceInfo().Result).FriendlyName;
                    if (deviceName.ToLower().Contains("webos"))
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
