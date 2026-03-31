using System;
using System.ComponentModel.DataAnnotations;

namespace interfaceIndustrialApi.DTOs
{
    public class CreateSensorDto
    {
        [Required]
        public string Name { get; set; } = null!;
        public string? Type { get; set; }
        public string? Unit { get; set; }
        public double? MinValue { get; set; }
        public double? MaxValue { get; set; }
    }

    public class SensorResponseDto
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string? Unit { get; set; }
        public double? CurrentValue { get; set; }
        public double? MinValue { get; set; }
        public double? MaxValue { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
