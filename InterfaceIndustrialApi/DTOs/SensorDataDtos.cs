using System;
using System.Collections.Generic;

namespace UserCrudApi.DTOs
{
    public class CreateSensorDataDto
    {
        public double Value { get; set; }
    }

    public class SensorDataResponseDto
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }
        public Guid SensorId { get; set; }
        public double Value { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; } = Array.Empty<T>();
        public int Page { get; set; }
        public int PageSize { get; set; }
        public long Total { get; set; }
    }
}
