using System;
using System.ComponentModel.DataAnnotations;

namespace UserCrudApi.DTOs
{
    public class CreateActuatorDto
    {
        [Required]
        public string Name { get; set; } = null!;
        public string? Type { get; set; }
        public string? SignalType { get; set; }
        public double? MinValue { get; set; }
        public double? MaxValue { get; set; }
    }

    public class UpdateActuatorDto
    {
        [Required]
        public string Name { get; set; } = null!;
        public string? Type { get; set; }
        public string? SignalType { get; set; }
        public double? CurrentValue { get; set; }
    }

    public class ActuatorResponseDto
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public string Name { get; set; } = null!;
        public string? Type { get; set; }
        public string SignalType { get; set; } = null!;
        public double? CurrentValue { get; set; }
        public double? MinValue { get; set; }
        public double? MaxValue { get; set; }
    }
}
