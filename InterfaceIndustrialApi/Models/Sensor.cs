using System;

namespace UserCrudApi.Models
{
    public enum SensorType
    {
        Temperature,
        Pressure,
        Speed,
        Status,
        Other
    }

    public class Sensor
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public string Name { get; set; } = null!;
        public SensorType Type { get; set; }
        public string? Unit { get; set; }
        public double? CurrentValue { get; set; }
        public double? MinValue { get; set; }
        public double? MaxValue { get; set; }
        public DateTime? LastUpdate { get; set; }

        public Device? Device { get; set; }
    }
}
