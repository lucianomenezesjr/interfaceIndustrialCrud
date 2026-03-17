using System;

namespace UserCrudApi.Models
{
    public enum SignalType
    {
        Digital,
        Analog,
        PWM
    }

    public class Actuator
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public string Name { get; set; } = null!;
        public string? Type { get; set; }
        public SignalType SignalType { get; set; }
        public double? CurrentValue { get; set; }
        public double? MinValue { get; set; }
        public double? MaxValue { get; set; }

        public Device? Device { get; set; }
    }
}
