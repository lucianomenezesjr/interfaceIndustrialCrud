using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserCrudApi.Models;

namespace UserCrudApi.Repositories.Interfaces
{
    public interface IActuatorRepository
    {
        Task<IEnumerable<Actuator>> GetByDeviceAsync(Guid deviceId);
        Task<Actuator> AddAsync(Actuator actuator);
        Task<Actuator?> GetByIdAsync(Guid id);
        Task<Actuator?> UpdateAsync(Actuator actuator);
    }
}
