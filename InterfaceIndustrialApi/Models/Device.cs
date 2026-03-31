using System;
using System.Collections.Generic;

namespace interfaceIndustrialApi.Models
{
    public enum DeviceProtocol
    {
        OPC_UA,
        MODBUS,
        MQTT,
        HTTP
    }

    public enum DeviceStatus
    {
        ONLINE,
        OFFLINE,
        INACTIVE
    }

    public class Device
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? SerialNumber { get; set; }
        public DeviceProtocol Protocol { get; set; }
        public string? IpAddress { get; set; }
        public int? Port { get; set; }
        public DeviceStatus Status { get; set; }
        public bool RequiresAuthorization { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Sensor>? Sensors { get; set; }
        public ICollection<Actuator>? Actuators { get; set; }
    }
}
