using System;

namespace interfaceIndustrialApi.Models
{
    public class SensorData
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public Guid SensorId { get; set; }
        public double Value { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
