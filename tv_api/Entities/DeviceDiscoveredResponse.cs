namespace tv_api.Entities
{
    class DeviceDiscoveredResponse
    {
        public bool Response { get; set; }
        public string Ip { get; set; }

        public DeviceDiscoveredResponse(bool response, string ip)
        {
            Response = response;
            Ip = ip;
        }

        public DeviceDiscoveredResponse()
        {
        }

        public static implicit operator string(DeviceDiscoveredResponse obj)
        {
            return obj.Ip;
        }
    }
}
