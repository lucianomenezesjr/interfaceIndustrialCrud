using System;
using System.ComponentModel.DataAnnotations;

namespace interfaceIndustrialApi.DTOs
{
    public class CreateDeviceDto
    {
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? SerialNumber { get; set; }
        public string? Protocol { get; set; }
        public string? IpAddress { get; set; }
        public int? Port { get; set; }
        public bool RequiresAuthorization { get; set; }
    }

    public class UpdateDeviceDto
    {
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? SerialNumber { get; set; }
        public string? Protocol { get; set; }
        public string? IpAddress { get; set; }
        public int? Port { get; set; }
        public bool RequiresAuthorization { get; set; }
        public string? Status { get; set; }
    }

    public class DeviceResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? SerialNumber { get; set; }
        public string Protocol { get; set; } = null!;
        public string? IpAddress { get; set; }
        public int? Port { get; set; }
        public string Status { get; set; } = null!;
        public bool RequiresAuthorization { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
